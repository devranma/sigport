using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SigPort.Modelo;

namespace SigPort
{
    public partial class login___professor : System.Web.UI.Page
    {
        Usuario user = new Usuario();
        UsuarioDAO userdao = new UsuarioDAO();
        ProfessorDAO profdao = new ProfessorDAO();


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmitLogin_Click(object sender, EventArgs e)
        {
            int cd_user = 0;
            if (!txtInputLogin.Text.Equals(String.Empty))
            {
                user.nome = txtInputLogin.Text;
                if (!txtSenhaLogin.Text.Equals(String.Empty))
                {
                    user.senha = txtSenhaLogin.Text;
                    if (userdao.AutenticarProfessor(user.nome, user.senha, ref cd_user))
                    {
                        Session["nm_user"] = user.nome;
                        Session["cd_usuario"] = cd_user;
                        int cd_tipousuario = userdao.pegaCodigoTipoUsuario(Convert.ToInt32(Session["cd_usuario"]));
                        Session["cd_tipousuario"] = cd_tipousuario;

                        string nome_materia = profdao.pegaNomeMateria(Convert.ToInt32(Session["cd_usuario"]));
                        Session["nomemateria"] = nome_materia;
                        int cd_projeto = profdao.pegaCodigoProjeto(Session["nomemateria"].ToString());
                        Session["idprojeto"] = cd_projeto;
                        Response.Redirect("PainelProfessor.aspx");
                    }
                    else
                    {
                        Response.Redirect("loginProfessor.aspx");
                    }
                }
            }
        }
    }
}