using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Npgsql;
using SigPort.Modelo;

namespace SigPort
{
    public partial class cadastrarProfessor : System.Web.UI.Page
    {
        Professor professor = new Professor();
        ProfessorDAO profdao = new ProfessorDAO();
        UsuarioDAO userdao = new UsuarioDAO();
        private int id_user = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            id_user = Convert.ToInt32(Session["cd_usuario"]);
        }

        protected void btnSubmitLogin_Click(object sender, EventArgs e)
        {
            if (!txtNomeProfessor.Text.Equals(String.Empty))
            {
                professor.nomeProfessor = txtNomeProfessor.Text;
                if (!disciplinas.Text.Equals("Selecione"))
                {
                    professor.disciplina = disciplinas.Text;
                    if (!txtNomeUsuario.Text.Equals(String.Empty))
                    {
                        if (txtSenhaUsuario.Text.Equals(txtConfirmacaoSenhaUsuario.Text))
                        {
                           string retorno = profdao.CadastrarProfessor(professor, txtNomeUsuario.Text, txtSenhaUsuario.Text, ref id_user);
                            if (retorno == "Cadastro efetuado com sucesso!")
                            {
                                Response.Redirect("loginProfessor.aspx");
                            }
                        }
                    }
                    
                }
            }
        }
    }
}