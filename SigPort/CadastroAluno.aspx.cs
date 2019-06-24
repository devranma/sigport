using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SigPort.Modelo;

namespace SigPort
{
    public partial class CadastroAluno : System.Web.UI.Page
    {
        private string ra = "";
        UsuarioDAO userdao = new UsuarioDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                consultaRaNomeAluno();
            }
        }

        protected void btnSubmitLogin_Click(object sender, EventArgs e)
        {
            Aluno al = new Aluno();
            if (txtSenhaUsuario.Text.Equals(txtConfirmacaoSenhaUsuario.Text))
            {
                al.senha = txtSenhaUsuario.Text;
                al.raAluno = txtRaUsuario.Text;
                al.email = txtEmailUsuario.Text;
                al.semestre = Convert.ToInt32(txtSemestreUsuario.Text);
                userdao.CadastrarAluno(al);        
            }
            
            
        }

        private void consultaRaNomeAluno()
        {
            bool status = false;
            ra = Session["ra"].ToString();
            UsuarioDAO userdao = new UsuarioDAO();
            List<string> informacoes = new List<string>();
            informacoes = userdao.infosAluno(ra, ref status);
            if (status)
            {
                txtRaUsuario.Text = informacoes[0];
                txtNomeUsuario.Text = informacoes[1];
            }
        }
    }
}