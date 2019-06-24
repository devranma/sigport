using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SigPort.Modelo;

namespace SigPort
{
    public partial class VisualizarAapRelatorioAluno : System.Web.UI.Page
    {
        private DataSet ds = new DataSet();
        private AlunoDAO aldao = new AlunoDAO();
        private int id_aluno = 0, semestre = 0;
        private string nome_usuario = "", projeto = "";
        private bool status_carregamento = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            semestre = Convert.ToInt32(Session["semestre"]);
            carregaAApsValidas();
        }

        protected void selecionarAap_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void consultaNotas()
        {
            nome_usuario = Session["nm_user"].ToString();
            id_aluno = aldao.pegaCodigoAluno(nome_usuario);
            
            if (selecionarAap.SelectedIndex != 8)
            {
                projeto = selecionarAap.SelectedItem.Text;
                ds = aldao.carregaNotas(projeto, id_aluno, ref status_carregamento);
                if (status_carregamento)
                {
                    gvAAP.DataSource = ds;
                    gvAAP.DataBind();
                }
            }
            else
            {
                projeto = "Todos";
                ds = aldao.carregaNotas(projeto, id_aluno, ref status_carregamento);
                if (status_carregamento)
                {
                    gvAAP.DataSource = ds;
                    gvAAP.DataBind();
                }
            }
        }

        private void carregaAApsValidas()
        {
            if (semestre > 1)
            {
                for (int i = 1; i <= semestre; i++)
                {
                    selecionarAap.Items[i - 1].Enabled = true;
                }
                if (semestre >= 5 && semestre < 6)
                {
                    selecionarAap.Items[6].Enabled = true;
                }
                else if (semestre == 6)
                {
                    selecionarAap.Items[6].Enabled = true;
                    selecionarAap.Items[7].Enabled = true;
                }
            }
        }


        protected void btnRevisaoNotas_Click(object sender, EventArgs e)
        {
            consultaNotas();
        }
    }
}