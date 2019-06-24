using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Npgsql;

namespace SigPort.Modelo
{
    public class UsuarioDAO
    {

        private bool status = false;

        ConexaoBanco conex = new ConexaoBanco();
        ProfessorDAO profdao = new ProfessorDAO();
        NpgsqlCommand cmd = new NpgsqlCommand();
        NpgsqlConnection con = new NpgsqlConnection();
        public bool AutenticarAluno(string usuario, string senha, ref bool novoUsuario, ref int cd_user)
        {
            bool status_autenticacao = false;
            con = conex.abrirConexao();
            if (con != null)
            {
                try
                {
                    cmd.Connection = con;
                    cmd.CommandText = "select * from usuarios where nomeusuario = @nome and senha = @senha";
                    cmd.Parameters.AddWithValue("@nome", usuario);
                    cmd.Parameters.AddWithValue("@senha", senha);
                    NpgsqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        status_autenticacao = true;
                        cd_user = Convert.ToInt32(dr["idusuario"]);
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                        dr.Close();
                        conex.fecharConexao();
                    }
                    else
                    {
                        dr.Close();
                        cmd.CommandText = "select ativoNoSistema from Alunos where nomealuno = @nome and ra = @ra";
                        cmd.Parameters.AddWithValue("@nome", usuario);
                        cmd.Parameters.AddWithValue("@ra", senha);
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            int ativo = dr.GetInt32(0);
                            if (ativo == 0)
                            {
                                status_autenticacao = true;
                                novoUsuario = true;
                            }
                            else
                            {
                                novoUsuario = false;
                            }
                        }
                        else
                        {
                            status_autenticacao = false;
                            novoUsuario = false;
                        }
                        dr.Close();
                        cmd.Dispose();
                        conex.fecharConexao();
                    }
                }
                catch (Exception)
                {
                    status_autenticacao = false;
                }
            }
            else
            {
                status = false;
            }
            
            return status_autenticacao;
        }

        public bool autenticarAdministrador(string nome_usuario, string senha)
        {
            try
            {
                con = conex.abrirConexao();
                cmd.Connection = con;

                cmd.CommandText = "select * from usuarios where nomeusuario=@nome_usuario and senha=@senha";
                cmd.Parameters.AddWithValue("@nome_usuario", nome_usuario);
                cmd.Parameters.AddWithValue("@senha", senha);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
                dr.Close();
                con.Close();
                cmd.Dispose();
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }




        public bool AutenticarProfessor(string usuario, string senha, ref int cd_user)
        {
            con = conex.abrirConexao();
            try
            {
                cmd.Connection = con;
                cmd.CommandText = "select * from usuarios join tipousuario on usuarios.fk_idtipo = tipousuario.idtipo where usuarios.nomeusuario=@nome and senha=@senha and idtipo=2;";
                cmd.Parameters.AddWithValue("@nome", usuario);
                cmd.Parameters.AddWithValue("@senha", senha);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    status = true;
                    cd_user = Convert.ToInt32(dr["idusuario"]);
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                    dr.Close();
                    conex.fecharConexao();
                }
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        
        public List<string> infosAluno(string ra, ref bool status)
        {
            List<string> infos = new List<string>();
            con = conex.abrirConexao();
            cmd.Connection = con;
            try
            {
                cmd.CommandText = "select nomealuno from alunos where ra = @ra";
                cmd.Parameters.AddWithValue("@ra", ra);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    infos.Insert(0,ra);
                    infos.Insert(1, dr["nomealuno"].ToString());
                    dr.Close();
                    status = true;
                }
                con.Close();
            }
            catch (Exception)
            {
                status = false;
            }
            return infos;
        }

        public bool CadastrarAluno(Aluno aluno)
        {
            DateTime dt = DateTime.Now;
            bool status = false;
            con = conex.abrirConexao();
            cmd.Connection = con;

            int ano = Convert.ToInt32(dt.Year);
            ano = ano + 5;
            string data_conc = string.Format("{0}/{1}/{2}", ano.ToString(), dt.Month, dt.Day);
            try
            {
                cmd.CommandText = "insert into usuarios (nomeusuario, senha,fk_idtipo) values (@nome,@senha,@fkidtipo)";
                cmd.Parameters.AddWithValue("@nome", aluno.raAluno);
                cmd.Parameters.AddWithValue("@senha", aluno.senha);
                cmd.Parameters.AddWithValue("@fkidtipo", 1);
                cmd.ExecuteNonQuery();
                int cd_user = pegaCodigoUsuario(aluno.raAluno);
                cmd.Parameters.Clear();
                int cd_aluno = pegaCodigoAluno(aluno.raAluno);
                cmd.CommandText = "update alunos set emailaluno=@emailaluno, semestre=@semestre, datacadastro=@datacad, dataconclusao=@dataconc, datavalidadealuno=@dataval, fk_idusuario=@fkiduser, ativonosistema=@ativonosistema where idaluno = @idaluno";
                cmd.Parameters.AddWithValue("@emailaluno", aluno.email);
                cmd.Parameters.AddWithValue("@semestre", aluno.semestre);
                cmd.Parameters.AddWithValue("@datacad", dt);
                cmd.Parameters.AddWithValue("@dataconc", data_conc);
                cmd.Parameters.AddWithValue("@dataval", data_conc);
                cmd.Parameters.AddWithValue("@fkiduser", cd_user);
                cmd.Parameters.AddWithValue("@ativonosistema", 1);
                cmd.Parameters.AddWithValue("@idaluno", cd_aluno);
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                status = true; 
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public int pegaCodigoAluno(string ra)
        {
            int codigo = 0;
            NpgsqlDataReader dr;
            try
            {
                cmd.Connection = con;
                cmd.CommandText = "select idaluno from alunos where ra=@ra";
                cmd.Parameters.AddWithValue("@ra", ra);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    codigo = Convert.ToInt32(dr["idaluno"]);
                }
                dr.Close();
            }
            catch (Exception)
            {
                codigo = 0;
            }
            cmd.Dispose();
            return codigo;
        }

        public int pegaCodigoTipoUsuario(int codigo_usuario)
        {
            int codigo_tipo_usuario = 0;
            try
            {
                con = conex.abrirConexao();
                cmd.Connection = con;

                cmd.CommandText = "select usuarios.fk_idtipo from usuarios join tipousuario on usuarios.fk_idtipo = tipousuario.idtipo where idusuario=@idusuario";
                cmd.Parameters.AddWithValue("@idusuario", codigo_usuario);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    codigo_tipo_usuario = Convert.ToInt32(dr["fk_idtipo"]);
                }
                dr.Close();
                con.Close();
                cmd.Dispose();
            }
            catch (Exception)
            {
                codigo_tipo_usuario = 0;
            }
            return codigo_tipo_usuario;
        }


        public int pegaCodigoUsuario(string ra)
        {
            int codigo = 0;
            try
            {
                cmd.Connection = con;
                cmd.CommandText = "select idusuario from usuarios join alunos on usuarios.nomeusuario = alunos.ra where alunos.ra = @ra";
                cmd.Parameters.AddWithValue("@ra", ra);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    codigo = Convert.ToInt32(dr["idusuario"]);
                }
                dr.Close();
            }
            catch (Exception)
            {
                codigo = 0;
            }
            return codigo;
        }

        public string pegaNomeUsuario(int cd_usuario)
        {
            string nome_usuario = "";
            NpgsqlDataReader dr;
            NpgsqlConnection conexao = new NpgsqlConnection();
            try
            {
                conexao = conex.abrirConexao();
                cmd.Connection = conexao;
                cmd.CommandText = "select nomeusuario from usuarios where usuarios.idusuario=@idusuario";
                cmd.Parameters.AddWithValue("@idusuario", cd_usuario);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    nome_usuario = dr["nomeusuario"].ToString();
                }
                dr.Close();
            }
            catch (Exception)
            {
                nome_usuario = "";
            }
            return nome_usuario;
        }
      
    }
}