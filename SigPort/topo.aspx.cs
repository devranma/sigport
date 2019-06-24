using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SigPort
{
    public partial class topo : System.Web.UI.Page
    {
        public string nome_usuario = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.nome_usuario = Session["nome_aluno"].ToString();
            
            
        }
    }
}