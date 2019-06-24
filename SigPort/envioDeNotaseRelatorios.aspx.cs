using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using SigPort.Modelo;

namespace SigPort
{
    public partial class envioDeNotaseRelatorios : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private void carregaAapAluno()
        {
            
            //fuAppAluno.SaveAs(caminho);
        }

        protected void btnVisualizar_Click(object sender, EventArgs e)
        {
            //caminho = "C:\\Users\\matgu\\OneDrive\\Documents\\AAPs\\" + fuAppAluno.PostedFile.FileName;
            /*if (!fuAppAluno.PostedFile.FileName.Equals(String.Empty))
            {
                StreamReader sr = File.OpenText(caminho);
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                string conteudo = "";
                while (sr.Peek() > -1)
                {
                    conteudo = conteudo + sr.ReadLine();
                }
                sr.Close();
                lblConteudoArquivo.Text = conteudo;
            }
            */
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            
        }

        protected void rblOpcoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}