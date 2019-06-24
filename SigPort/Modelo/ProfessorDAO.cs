using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using System.Data;
using System.Data.OleDb;
namespace SigPort.Modelo
{
    public class ProfessorDAO
    {
        private bool status = false;
        private int id_projeto = 0;

        ConexaoBanco conex = new ConexaoBanco();
        private NpgsqlConnection con = new NpgsqlConnection();
        private NpgsqlCommand cmd = new NpgsqlCommand();


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

        public string CadastrarProfessor(Professor professor, string nome_usuario,string senha, ref int cd_user)
        {
            int cd_usuario = 0;
            string nm_user = nome_usuario;
            string senha_user = senha;
            string mensagem = "";
            try
            {
                cd_usuario = pegaCodigoUsuarioProfessor(nm_user, senha_user);

                if (cd_usuario != 0)
                {
                    mensagem = "Usuário já cadastrado!";
                }
                else
                {
                    con.Open();
                    cmd.CommandText = "insert into usuarios (nomeusuario, senha,fk_idtipo) values (@nome,@senha,@fkidtipo)";
                    cmd.Parameters.AddWithValue("@nome", nome_usuario);
                    cmd.Parameters.AddWithValue("@senha", senha);
                    cmd.Parameters.AddWithValue("@fkidtipo", 2);
                    cd_user = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.Parameters.Clear();

                    con.Close();

                    id_projeto = pegaCodigoProjeto(professor.disciplina);

                    cd_usuario = pegaCodigoUsuarioProfessor(nm_user, senha_user);

                    con.Open();
                    if (id_projeto != 0)
                    {
                        cmd.CommandText = "insert into professores (nomerepresentante,projeto_id,fk_idusuario) values (@nomerepresentante,@projeto_id,@fk_idusuario)";
                        cmd.Parameters.AddWithValue("@nomerepresentante", professor.nomeProfessor);
                        cmd.Parameters.AddWithValue("@projeto_id", id_projeto);
                        cmd.Parameters.AddWithValue("@fk_idusuario", cd_usuario);
                        cmd.ExecuteNonQuery();
                        mensagem = "Cadastro efetuado com sucesso!";
                        cd_user = cd_usuario;
                    }
                    else
                    {
                        mensagem = "erro ao cadastrar. Projeto não encontrado!";
                    }
                    con.Close();
                    cmd.Dispose();
                }

                
            }
            catch (Exception)
            {
                mensagem = "Ocorreu um erro ao cadastrar. Tente novamente!";
            }

            return mensagem;
        }
        
        public int pegaCodigoProjeto(string nome_projeto)
        {
            try
            {
                con = conex.abrirConexao();
                cmd.Connection = con;

                cmd.CommandText = "select idprojeto from projetos where nomemateria ~* @nomeprojeto; ";
                cmd.Parameters.AddWithValue("@nomeprojeto", nome_projeto);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    id_projeto = Convert.ToInt32(dr["idprojeto"]);
                }
                else
                {
                    id_projeto = 0;
                }
                dr.Close();
                con.Close();
                cmd.Dispose();
            }
            catch (Exception)
            {
                id_projeto = 0;
            }
            
            return id_projeto;
        }


        public string pegaNomeMateria(int codigo_usuario)
        {
            string nome_projeto = "";
            try
            {
                con = conex.abrirConexao();
                cmd.Connection = con;

                cmd.CommandText = "select projeto_id from professores where fk_idusuario=@fk_idusuario";
                cmd.Parameters.AddWithValue("@fk_idusuario", codigo_usuario);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    id_projeto = Convert.ToInt32(dr["projeto_id"]);
                }
                else
                {
                    id_projeto = 0;
                }
                
                dr.Close();
                cmd.Parameters.Clear();

                cmd.CommandText = "select nomemateria from projetos where idprojeto=@idprojeto";
                cmd.Parameters.AddWithValue("@idprojeto", id_projeto);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    nome_projeto = dr["nomemateria"].ToString();
                }
                dr.Close();
                con.Close();
                cmd.Dispose();
            }
            catch (Exception)
            {
                nome_projeto = "";
            }
            return nome_projeto;
        }
        private int pegaCodigoUsuarioProfessor(string nome_usuario, string senha)
        {
            int codigo_usuario = 0;

            try
            {
                con = conex.abrirConexao();
                cmd.Connection = con;

                cmd.CommandText = "select idusuario from usuarios where nomeusuario = @nome and senha = @senha and fk_idtipo = 2";
                cmd.Parameters.AddWithValue("@nome", nome_usuario);
                cmd.Parameters.AddWithValue("@senha", senha);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    codigo_usuario = Convert.ToInt32(dr["idusuario"]);
                }
                else
                {
                    codigo_usuario = 0;
                }
                dr.Close();
                con.Close();
                cmd.Dispose();
            }
            catch (Exception)
            {
                codigo_usuario = 0;
            }

            return codigo_usuario;
        }

        public DataTable carregarDadosAap(int projetoId) {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            try {
                ds.Tables.Add(dt);
                con = conex.abrirConexao();
                cmd.Connection = con;
                cmd.CommandText = "select idaap , nomeaap from arquivoentradaaap where fk_idprojeto = @idprojeto";
                cmd.Parameters.AddWithValue("@idprojeto", projetoId);
                NpgsqlDataAdapter nda = new NpgsqlDataAdapter(cmd.CommandText, cmd.Connection);

                nda.Fill(ds, "aap");

                dt = ds.Tables[0];
            }
            catch (Exception) {
                
            }
            con.Close();
            cmd.Dispose();
            return dt;
        }
    }
}