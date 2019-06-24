using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using Npgsql;

namespace SigPort.Modelo
{
    public class Administrador:Usuario
    {
        private bool flgAdm { get; set; }

        public DataSet carregarAlunosGridView(string caminho, ref bool status, ref string formato_invalido)
        {
            DataTable planilhas;
            string nome_planilha = "";
            OleDbConnection conexao = new OleDbConnection();
            conexao.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source = " + caminho + ";Extended Properties='Excel 8.0; HDR=Yes;'";
            try
            {
                conexao.Open();
                planilhas = conexao.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                nome_planilha = planilhas.Rows[0]["TABLE_NAME"].ToString();
                conexao.Close();
            }
            catch (Exception)
            {
                formato_invalido = "O arquivo do Excel selecionado é inválido. Por favor, selecione um arquivo no formato 2003";
            }
            
            OleDbDataAdapter da = new OleDbDataAdapter("select * from [" + nome_planilha + "]", conexao);
            DataSet ds = new DataSet();

            try
            {
                conexao.Open();
                da.Fill(ds);
            }
            catch (Exception)
            {
                status = false;
            }
            conexao.Close();
            return ds;
        }

        public bool InserirAlunos(string[] ra, string[] nomes, ref string registros_identicos)
        {
            bool status = false;
            int qtde_registros_identicos = 0;
            string[] ra_alunos = new string[ra.Length];
            string[] nome_alunos = new string[nomes.Length];
            string[] ra_aux = new string[ra_alunos.Length];
            string[] nome_aux = new string[nome_alunos.Length];
            for (int i = 0; i < ra.Length; i++)
            {
                ra_alunos[i] = ra[i];
                nome_alunos[i] = nomes[i];
            }
            
            NpgsqlConnection con = new NpgsqlConnection();
            ConexaoBanco conex = new ConexaoBanco();
            NpgsqlCommand cmd = new NpgsqlCommand();
            try
            {
                con = conex.abrirConexao();
                cmd.Connection = con;
                string nome = "";
                string ra_al = "";
                for (int i = 0; i < ra_alunos.Length; i++)
                {
                    ra_al = ra_alunos[i];
                    nome = nome_alunos[i];
                    cmd.CommandText = "select * from alunos where ra = @ra and nomealuno = @nome";
                    cmd.Parameters.AddWithValue("@ra", ra_al);
                    cmd.Parameters.AddWithValue("@nome", nome);
                    NpgsqlDataReader dr = cmd.ExecuteReader();
                    if (!dr.Read())
                    {
                        ra_aux[i] = ra_al;
                        nome_aux[i] = nome;
                    }
                    else
                    {
                        ra_aux[i] = "";
                        nome_aux[i] = "";
                        qtde_registros_identicos++;
                    }
                    ra_al = "";
                    nome = "";
                    cmd.Parameters.Clear();
                    dr.Close();
                }
                con.Close();
                if (qtde_registros_identicos != ra_aux.Length)
                {
                    con.Open();
                    for (int i = 0; i < ra_aux.Length; i++)
                    {
                        if (!ra_aux[i].Equals(""))
                        {
                            cmd.Parameters.Clear();
                            cmd.CommandText = "insert into alunos (ra,nomealuno,emailaluno,semestre,dataprecarregamento,datacadastro,dataconclusao,datavalidadealuno,fk_idusuario,ativonosistema) values (@ra,@nome,null,null,null,null,null,null,null,0)";
                            cmd.Parameters.AddWithValue("@ra", ra_aux[i]);
                            cmd.Parameters.AddWithValue("@nome", nome_aux[i]);
                            cmd.ExecuteScalar();
                        }
                    }
                    status = true;
                }
                else
                {
                    registros_identicos = "Não há novos registros para inserir!";
                }
                  
            }
            catch (Exception)
            {
                status = false;
            }
            con.Close();
            cmd.Dispose();
            return status;
        }
    }
}