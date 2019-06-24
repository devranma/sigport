using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Npgsql;

namespace SigPort
{
    public partial class CadastrarPortfolio : System.Web.UI.Page
    {
        private int semestre = 0;
        private string[] aapsConcluidas;
        protected void Page_Load(object sender, EventArgs e)
        {
            semestre = Convert.ToInt32(Session["semestre"]);
            aapsConcluidas = (string[])Session["aapsConcluidas"];
            carregaAApsConcluidas();
            
            if (semestre >= 4 && semestre < 6)
            {
                ddlSelecionaPortfolio.Items[0].Enabled = true;

            }
            else if (semestre == 6)
            {
                ddlSelecionaPortfolio.Items[0].Enabled = true;
                ddlSelecionaPortfolio.Items[1].Enabled = true;
            }
        }


        private void carregaAApsConcluidas()
        {
            for (int i = 0; i < aapsConcluidas.Length; i++)
            {
                switch (aapsConcluidas[i])
                {
                    case "Modelagem de Processos":
                        cbModelagemDeProcessos.Enabled = true;
                        break;

                    case "Engenharia de Software e Aplicações":
                        cbEngenhariaDeSoftware.Enabled = true;
                        break;

                    case "Banco de Dados e Aplicações":
                        cbBancoDeDados.Enabled = true;
                        break;

                    case "Programação para Internet":
                        cbProgramacaoInternet.Enabled = true;
                        break;

                    case "Sistemas Integrados de Gestão e Aplicações":
                        cbSistemasIntegrados.Enabled = true;
                        break;

                    case "Projetos de Tecnologia da Informação II":
                        cbProjetosTi2.Enabled = true;
                        break;
                    default:
                        break;
                }
            }
        }
        protected void btnCadastrarPortfolio1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection();
            NpgsqlCommand cmd = new NpgsqlCommand();
            conn.ConnectionString = "Server = 127.0.0.1; Port = 5432; Database = sigportdb; User id = root; password = root";
            cmd.Connection = conn;
            cmd.CommandText = "select aluno_id from Pesquisas where aluno_id = 'valor1'";
            cmd.CommandType = CommandType.Text;
            conn.Open();

            NpgsqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                //lblRespBanco.Text = "Aluno já cadastrado nessa AAP";

            }
            else
            {
                string respostaFinal = "";
                conn.Close();
                cmd.CommandText = "insert into Pesquisas (aluno_id, aap_id, relatorio_id, materia_id, situacao) values('valor1', 'valor2', 'valor3', 'valor4', 'valor5')";
                cmd.CommandType = CommandType.Text;
                conn.Open();
                cmd.ExecuteScalar();
                respostaFinal += "A AAP de valor1 foi inserida, ";
                conn.Close();
                cmd.CommandText = "insert into Pesquisas (aluno_id, aap_id, relatorio_id, materia_id, situacao) values('valor1', 'valor2', 'valor3', 'valor4', 'valor5')";
                cmd.CommandType = CommandType.Text;
                conn.Open();
                cmd.ExecuteScalar();
                respostaFinal += "A AAP de valor2 foi inserida, ";
                conn.Close();
                cmd.CommandText = "insert into Pesquisas (aluno_id, aap_id, relatorio_id, materia_id, situacao) values('valor1', 'valor2', 'valor3', 'valor4', 'valor5')";
                cmd.CommandType = CommandType.Text;
                conn.Open();
                cmd.ExecuteScalar();
                respostaFinal += "A AAP de valor3 foi inserida.-";
                //lblRespBanco.Text = "Registro incluído com sucesso!";

            }

            conn.Close();
            conn.Dispose();

            
        }
    }
}