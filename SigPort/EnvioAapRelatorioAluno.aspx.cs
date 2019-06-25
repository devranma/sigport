using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SigPort.Modelo;
namespace SigPort
{
    public partial class EnvioAapRelatorioAluno : System.Web.UI.Page
    {
        private string nm_arquivo = "";
        private string nome_aluno = "";
        private string nome_aap = "";
        private string mensagem = "";
        private bool aap_enviada = false; //verifica se a aap em questão já foi enviada
        private int codigo_aluno = 0;
        private int codigo_grupo = 0;
        private List<string> integrantes = new List<string>();
        private bool status = false;
        private string nome_usuario = "";
        private int semestre = 0;
        private DateTime dt = new DateTime();

        AlunoDAO aldao = new AlunoDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            dt = DateTime.Now;
            semestre = Convert.ToInt32(Session["semestre"]);
            carregaAApsValidas();
            if (!Page.IsPostBack)
            {
                semestre = Convert.ToInt32(Session["semestre"]);
                codigo_aluno = aldao.pegaCodigoAluno(Session["nm_user"].ToString());
                if (codigo_aluno != 0)
                {
                    Session["codigo_aluno"] = codigo_aluno;
                }
            }
            else
            {
                codigo_aluno = aldao.pegaCodigoAluno(Session["nm_user"].ToString());
                if (codigo_aluno != 0)
                {
                    Session["codigo_aluno"] = codigo_aluno;
                    nome_aluno = aldao.pegaNomeAluno(codigo_aluno);
                    if (!nome_aluno.Equals(String.Empty))
                    {
                        //nome_usuario = Session["nm_user"].ToString();
                        if (aldao.verificaAapEnviada(selecionarAapeRelatorio.Text))
                        {
                            integrantes = aldao.CarregaIntegrantesGrupo(codigo_aluno, ref status, nome_aluno, ref nome_aap);
                            if (!nome_aap.Equals("") && status)
                            {
                                selecionarAapeRelatorio.SelectedValue = nome_aap;
                                int qtde_alunos = integrantes.Count;
                                switch (qtde_alunos)
                                {
                                    case 1:
                                        txtNomeIntegrante1.Text = integrantes[0];
                                        break;

                                    case 2:
                                        txtNomeIntegrante1.Text = integrantes[0];
                                        txtNomeIntegrante2.Text = integrantes[1];
                                        break;

                                    case 3:
                                        txtNomeIntegrante1.Text = integrantes[0];
                                        txtNomeIntegrante2.Text = integrantes[1];
                                        txtNomeIntegrante3.Text = integrantes[2];
                                        break;

                                    case 4:
                                        txtNomeIntegrante1.Text = integrantes[0];
                                        txtNomeIntegrante2.Text = integrantes[1];
                                        txtNomeIntegrante3.Text = integrantes[2];
                                        txtNomeIntegrante4.Text = integrantes[3];
                                        break;
                                    default:
                                        break;
                                }
                                aap_enviada = true;
                            }
                        }
                        
                    }
                }
            }
            
        }

        private void carregaAApsValidas()
        {
            if (semestre > 1)
            {
                for (int i = 1; i <= semestre; i++)
                {
                    selecionarAapeRelatorio.Items[i-1].Enabled = true;
                }
                if (semestre == 5)
                {
                    selecionarAapeRelatorio.Items[6].Enabled = false;
                }
                else if (semestre == 6)
                {
                    selecionarAapeRelatorio.Items[6].Enabled = false;
                    selecionarAapeRelatorio.Items[7].Enabled = false;
                }
            }
        }


        

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            string[] ras;
            string[] nomes;
            string aluno1 = "", aluno2 = "", aluno3 = "", aluno4 = "";
            string ra1 = "", ra2 = "", ra3 = "", ra4 = "";
            int qtde_alunos = 1;

            if (!fuArquivoAAP.PostedFile.FileName.Equals(String.Empty))
            {
                if (fuArquivoAAP.PostedFile.FileName.EndsWith(".pdf") || fuArquivoAAP.PostedFile.FileName.EndsWith(".PDF"))
                {
                    if (txtNomeIntegrante1.Text.Where(c => char.IsLetter(c)).Count() > 0)
                    {
                        qtde_alunos++;
                        ra1 = txtRaIntegrante1.Text;
                        aluno1 = txtNomeIntegrante1.Text;
                    }


                    if (txtNomeIntegrante2.Text.Where(c => char.IsLetter(c)).Count() > 0)
                    {
                        qtde_alunos++;
                        ra2 = txtRaIntegrante2.Text;
                        aluno2 = txtNomeIntegrante2.Text;
                    }

                    if (txtNomeIntegrante3.Text.Where(c => char.IsLetter(c)).Count() > 0)
                    {
                        qtde_alunos++;
                        ra3 = txtRaIntegrante3.Text;
                        aluno3 = txtNomeIntegrante3.Text;
                    }

                    if (txtNomeIntegrante4.Text.Where(c => char.IsLetter(c)).Count() > 0)
                    {
                        qtde_alunos++;
                        ra4 = txtRaIntegrante4.Text;
                        aluno4 = txtNomeIntegrante4.Text;
                    }

                    ras = new string[qtde_alunos];
                    nomes = new string[qtde_alunos];

                    switch (qtde_alunos)
                    {
                        case 1:
                            ras[0] = aldao.pegaRaAluno(codigo_aluno);
                            nomes[0] = nome_aluno;
                            break;

                        case 2:
                            ras[0] = aldao.pegaRaAluno(codigo_aluno);
                            ras[1] = ra1;
                            nomes[0] = nome_aluno;
                            nomes[1] = aluno1;
                            break;

                        case 3:
                            ras[0] = aldao.pegaRaAluno(codigo_aluno);
                            ras[1] = ra1;
                            ras[2] = ra2;

                            nomes[0] = nome_aluno;
                            nomes[1] = aluno1;
                            nomes[2] = aluno2;
                            break;

                        case 4:
                            ras[0] = aldao.pegaRaAluno(codigo_aluno);
                            ras[1] = ra1;
                            ras[2] = ra2;
                            ras[3] = ra3;
                            nomes[0] = nome_aluno;
                            nomes[1] = aluno1;
                            nomes[2] = aluno2;
                            nomes[3] = aluno3;
                            break;

                        case 5:
                            ras[0] = aldao.pegaRaAluno(codigo_aluno);
                            ras[1] = ra1;
                            ras[2] = ra2;
                            ras[3] = ra3;
                            ras[4] = ra4;
                            nomes[0] = nome_aluno;
                            nomes[1] = aluno1;
                            nomes[2] = aluno2;
                            nomes[3] = aluno3;
                            nomes[4] = aluno4;
                            break;
                        default:
                            break;
                    }

                    if (aldao.ValidaIntegrantesGrupo(ras, nomes))
                    {

                        if (!aap_enviada)
                        {
                            string arquivo = "";
                            if (dt.Month <= 6)
                            {
                                nm_arquivo = "alunos_" + selecionarAapeRelatorio.SelectedItem.Value + "_" + dt.Year + "_1.xls";
                            }
                            else
                            {
                                nm_arquivo = "alunos_" + selecionarAapeRelatorio.SelectedItem.Value + "_" + dt.Year + "_2.xls";
                            }
                            if (aldao.VerificaAlunosAAP(ras, nomes, nm_arquivo, selecionarAapeRelatorio.Text))
                            {
                                if (aldao.InserirAAP(ras, nomes, selecionarAapeRelatorio.Text, ref mensagem, codigo_aluno, ref codigo_grupo) && (!mensagem.Equals("")))
                                {
                                    string arquivo_aap = fuArquivoAAP.PostedFile.FileName;
                                    arquivo_aap = selecionarAapeRelatorio.Text + codigo_grupo;
                                    string caminho = "C:\\Users\\matgu\\OneDrive\\Documents\\AAPs\\Listas Alunos\\" + selecionarAapeRelatorio.Text + "\\Arquivos_AAPs\\" + arquivo_aap + ".pdf";
                                    fuArquivoAAP.SaveAs(caminho);
                                    lblMensagem.Text = "AAP registrada no sistema!";
                                }
                            }
                        }
                        else
                        {
                            aldao.InserirAAP(ras, nomes, selecionarAapeRelatorio.Text, ref mensagem, codigo_aluno, ref codigo_grupo);
                            lblMensagem.Text = mensagem;
                        }
                    }
                    else
                    {
                        lblMensagem.Text = "Falha ao inserir AAP. Verifique se os nomes e RA's dos integrantes estão corretos!";
                    }
                }
                else
                {
                    lblMensagem.Text = "Somente arquivos do tipo PDF são aceitos!";
                }

            }
            else
            {
                lblMensagem.Text = "Selecione um arquivo!";
            }

        }

        protected void selecionarAapeRelatorio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}