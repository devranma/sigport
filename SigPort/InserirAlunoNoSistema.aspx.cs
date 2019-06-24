using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using SigPort.Modelo;

namespace SigPort
{
    public partial class InserirAlunoNoSistema : System.Web.UI.Page
    {
        private string caminho = "";
        private string nome_arquivo = "";
        private string arquivo_adm = "";
        private string arquivo_prof = "";
        DateTime dt = new DateTime();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            dt = DateTime.Now;
            if (Convert.ToInt32(Session["cd_tipousuario"]) == 2)
            {
                lblFormatoArquivo.Text = "alunos_nomedisciplina_ano_semestre. \n Exemplo: alunos_Modelagem de Processos_20190_2";
            }
            else if (Convert.ToInt32(Session["cd_tipousuario"]) == 3)
            {
                lblFormatoArquivo.Text = "alunos_matricula_ano_semestre. \n Exemplo: alunos_matricula_2019_2";
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            lblMensagem.Text = "";
            if (fuListaAlunos.PostedFile.FileName != "")
            {
                nome_arquivo = fuListaAlunos.PostedFile.FileName;
                if (Convert.ToInt32(Session["cd_tipousuario"]) == 2)
                {
                    if (dt.Month <= 6)
                    {
                        arquivo_prof = "alunos_" + Session["nomemateria"].ToString() + "_" + dt.Year.ToString() + "_1.xls";
                    }
                    else
                    {
                        arquivo_prof = "alunos_" + Session["nomemateria"].ToString() + "_" + dt.Year.ToString() + "_2.xls";
                    }
                    
                    if (nome_arquivo.Equals(arquivo_prof))
                    {
                        caminho = "C:\\Users\\matgu\\OneDrive\\Documents\\AAPs\\Listas Alunos\\" + Session["nomemateria"].ToString() + "\\" + nome_arquivo;
                        fuListaAlunos.SaveAs(caminho);
                        Ler();
                        Session["nome_arquivo"] = nome_arquivo;
                    }
                    else
                    {
                        lblMensagem.Text = "Nome do arquivo é inválido!";
                    }

                }
                else if (Convert.ToInt32(Session["cd_tipousuario"]) == 3)
                {
                    if (dt.Month <= 6)
                    {
                        arquivo_adm = "alunos_matricula_" + dt.Year.ToString() + "_1.xls";
                    }
                    else
                    {
                        arquivo_adm = "alunos_matricula_" + dt.Year.ToString() + "_2.xls";
                    }
                    Session["arquivo_adm"] = arquivo_adm;
                    if (nome_arquivo.Equals(arquivo_adm))
                    {
                        caminho = "C:\\Users\\matgu\\OneDrive\\Documents\\AAPs\\Arquivos Alunos\\" + nome_arquivo;
                        fuListaAlunos.SaveAs(caminho);
                        Ler();
                        Session["nome_arquivo"] = nome_arquivo;
                    }
                    else
                    {
                        lblMensagem.Text = "Nome de arquivo inválido!";
                    }
                    
                }
                
            }
            else
            {
                lblMensagem.Text = "Selecione um arquivo.";
            }
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            string registros = "";
            Administrador adm = new Administrador();
            AlunoDAO aldao = new AlunoDAO();
            string[] ra;
            string[] nomes;
            if (Convert.ToInt32(Session["cd_tipousuario"]) == 3)
            {
                if (gvAlunosInserir.Rows.Count != 0)
                {
                    ra = new string[gvAlunosInserir.Rows.Count];
                    nomes = new string[gvAlunosInserir.Rows.Count];
                    for (int i = 0; i < gvAlunosInserir.Rows.Count; i++)
                    {
                        ra[i] = gvAlunosInserir.Rows[i].Cells[0].Text;
                        nomes[i] = gvAlunosInserir.Rows[i].Cells[1].Text;
                    }
                    if (Session["nome_arquivo"].Equals(Session["arquivo_adm"]))
                    {
                        if (adm.InserirAlunos(ra, nomes, ref registros) && registros.Equals(String.Empty))
                        {
                            lblMensagem.Text = "Alunos inseridos no sistema!";
                        }
                        else if (registros != "")
                        {
                            lblMensagem.Text = registros;
                        }
                        else
                        {
                            lblMensagem.Text = "Falha ao inserir os alunos, tente novamente!";
                        }
                    }
                    else
                    {
                        if (aldao.VerificaAlunosAAP(ra,nomes, Session["nome_arquivo"].ToString(), Session["nomemateria"].ToString()))
                        {
                            lblMensagem.Text = "Alunos inseridos no sistema!";
                        }
                        else
                        {
                            lblMensagem.Text = "Falha ao inserir os alunos!";
                        }
                    }

                }
                else
                {
                    lblMensagem.Text = "Não há dados para inserir!";
                }
            }
            
        }

        private void Ler()
        {
            string formato_invalido = "";
            bool status = true;
            ProfessorDAO profdao = new ProfessorDAO();
            DataSet dsalunos = new DataSet();
            dsalunos = profdao.carregarAlunosGridView(caminho,ref status,ref formato_invalido);
            if (formato_invalido != "")
            {
                lblMensagem.Text = formato_invalido;
            }
            else if (status == false)
            {
                lblMensagem.Text = "Falha no upload. Tente novamente!";
            }
            else
            {
                gvAlunosInserir.DataSource = dsalunos;
                gvAlunosInserir.DataBind();
            }
        }
    }
}