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

        public bool InserirAlunos(List<string> ra, List<string> nomes, ref string registros_identicos)
        {
            bool status = false;
            List<string> ra_alunos = new List<string>();
            List<string> nome_alunos = new List<string>();
            List<string> ra_aux = new List<string>();
            List<string> nome_aux = new List<string>();
            ra_alunos = ra;
            nome_alunos = nomes;
            NpgsqlConnection con = new NpgsqlConnection();
            con.ConnectionString = "Server = 127.0.0.1; Port = 5432; Database = sigportdb; User id = sigportuser; password = Zt44TbV9LZFdGz7";
            NpgsqlCommand cmd = new NpgsqlCommand();
            try
            {
                cmd.Connection = con;
                con.Open();

                for (int i = 0; i < ra_alunos.Count; i++)
                {
                    
                    cmd.CommandText = "select * from alunos where ra = @ra and nomealuno = @nome";
                    cmd.Parameters.AddWithValue("@ra", ra_alunos[i]);
                    cmd.Parameters.AddWithValue("@nome", nome_alunos[i]);
                    NpgsqlDataReader dr = cmd.ExecuteReader();
                    if (!dr.Read())
                    {
                        ra_aux.Add(ra_alunos[i]);
                        nome_aux.Add(nome_alunos[i]);
                    }
                    dr.Close();
                }
                con.Close();
                
                    con.Open();
                if (ra_aux.Count != 0)
                {
                    for (int i = 0; i < ra_alunos.Count; i++)
                    {
                        cmd.CommandText = "insert into alunos (ra,nomealuno,emailaluno,semestre,ativonosistema,dataprecarregamento,datacadastro,dataconclusao,datavalidadealuno,fk_idusuario) values (@ra,@nome,null,null,null,null,null,null,null,null)";
                        cmd.Parameters.AddWithValue("@ra", ra_alunos[i]);
                        cmd.Parameters.AddWithValue("@nome", nome_alunos[i]);
                        cmd.ExecuteScalar();
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