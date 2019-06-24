using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SigPort.Modelo;

namespace SigPort
{
    public partial class loginAdministrador : System.Web.UI.Page
    {
        Usuario user = new Usuario();
        UsuarioDAO userdao = new UsuarioDAO();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmitLogin_Click(object sender, EventArgs e)
        {
            if (!txtInputLogin.Text.Equals(String.Empty))
            {
                user.nome = txtInputLogin.Text;
                if (!txtSenhaLogin.Text.Equals(String.Empty))
                {
                    user.senha = txtSenhaLogin.Text;

                    if (userdao.autenticarAdministrador(user.nome, user.senha))
                    {
                        Session["cd_tipousuario"] = 3;
                        Response.Redirect("PainelAdm.aspx");
                    }
                    else
                    {
                        Response.Redirect("loginAdministrador.aspx");
                    }
                }

            }
        }
    }
}