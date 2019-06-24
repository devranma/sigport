using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SigPort.Modelo;

namespace SigPort
{
    public partial class login : System.Web.UI.Page
    {
        private int semestre = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmitLogin_Click(object sender, EventArgs e)
        {
            Usuario user = new Usuario();
            UsuarioDAO userdao = new UsuarioDAO();
            AlunoDAO aldao = new AlunoDAO();
            bool novoUser = false;
            int cd_user = 0;
            user.nome = txtInputLogin.Text;
            user.senha = txtSenhaLogin.Text;
            if (userdao.AutenticarAluno(user.nome, user.senha, ref novoUser, ref cd_user) && novoUser == true)
            {
                Session["ra"] = user.senha;
                Session["cd_usuario"] = cd_user;
                Session["nm_user"] = userdao.pegaNomeUsuario(cd_user);
                Response.Redirect("CadastroAluno.aspx");
            }
            else if (userdao.AutenticarAluno(user.nome, user.senha, ref novoUser, ref cd_user) && novoUser == false)
            {
                Session["cd_usuario"] = cd_user;
                Session["nm_user"] = userdao.pegaNomeUsuario(cd_user);
                string[] aapsConcluidas = aldao.carregaAAps(user.nome, ref semestre);
                Session["semestre"] = semestre;
                Session["aapsConcluidas"] = aapsConcluidas;
                Response.Redirect("PainelAluno.aspx");
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
    }
}