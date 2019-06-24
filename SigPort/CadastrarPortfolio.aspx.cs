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
        private int semestre = 0, qtde_aaps = 0;
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
                        qtde_aaps++;
                        break;

                    case "Engenharia de Software e Aplicações":
                        cbEngenhariaDeSoftware.Enabled = true;
                        qtde_aaps++;
                        break;

                    case "Banco de Dados e Aplicações":
                        cbBancoDeDados.Enabled = true;
                        qtde_aaps++;
                        break;

                    case "Programação para Internet":
                        cbProgramacaoInternet.Enabled = true;
                        qtde_aaps++;
                        break;

                    case "Sistemas Integrados de Gestão e Aplicações":
                        cbSistemasIntegrados.Enabled = true;
                        qtde_aaps++;
                        break;

                    case "Projetos de Tecnologia da Informação II":
                        cbProjetosTi2.Enabled = true;
                        qtde_aaps++;
                        break;
                    default:
                        break;
                }
            }
        }
        protected void btnCadastrarPortfolio1_Click(object sender, EventArgs e)
        {
            
        }
    }
}