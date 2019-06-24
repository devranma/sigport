using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using System.Data;
using System.Data.OleDb;
namespace SigPort.Modelo
{
    public class AlunoDAO
    {
        ConexaoBanco conex = new ConexaoBanco();
        NpgsqlConnection con = new NpgsqlConnection();
        NpgsqlCommand cmd = new NpgsqlCommand();
        private bool status = false;
        private string caminho = "";
        private int id_projeto = 0;
        public bool VerificaAlunosAAP(string[] ras, string[] alunos, string arquivo, string nomemateria)
        {
            string formato_invalido = "";
            string[] listaras;
            string[] listanomes;
            caminho = "C:\\Users\\matgu\\OneDrive\\Documents\\AAPs\\Listas Alunos\\" + nomemateria + "\\Alunos\\" + arquivo;
            if (!caminho.Contains(".xls"))
            {
                caminho = caminho + ".xls";    
            }
            
            DataTable planilhas;
            string nome_planilha = "";
            OleDbConnection conexao = new OleDbConnection();
            conexao.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source = " + caminho + ";Extended Properties='Excel 8.0; HDR=Yes;'";
            try
            {
                conexao.Open();
                planilhas = conexao.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                nome_planilha = planilhas.Rows[0]["TABLE_NAME"].ToString();
                conexao.Close();
            }
            catch (Exception)
            {
                formato_invalido = "O arquivo do Excel selecionado é inválido. Por favor, selecione um arquivo no formato 2003";
            }
            
            try
            {
                
                conexao.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conexao;
                listaras = new string[ras.Length];
                listanomes = new string[alunos.Length];
                int cont_vazias = 0;
                for (int i = 0; i < listaras.Length; i++)
                {
                    listaras[i] = ras[i];
                    listanomes[i] = alunos[i];
                }
                int contador_registros = 0;
                for (int i = 0; i < listaras.Length; i++)
                {
                    if (!listaras[i].Equals(" "))
                    {
                        cmd.CommandText = "select * from [" + nome_planilha + "] where ra=@ra and nome=@nome";
                        cmd.Parameters.AddWithValue("@ra", listaras[i]);
                        cmd.Parameters.AddWithValue("@nome", listanomes[i]);
                        OleDbDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            contador_registros++;
                        }
                        cmd.Parameters.Clear();
                        dr.Close();
                    }
                    else
                    {
                        cont_vazias++;
                    }
                    
                }

                if (contador_registros == (listaras.Length - cont_vazias))
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception)
            {
                status = false;
            }
            conexao.Close();
            
            return status;
        }

        public string pegaRaAluno(int codigo_aluno)
        {
            string ra = "";

            try
            {
                con = conex.abrirConexao();
                cmd.Connection = con;

                cmd.CommandText = "select ra from Alunos where idaluno=@idaluno";
                cmd.Parameters.AddWithValue("@idaluno", codigo_aluno);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    ra = dr["ra"].ToString();
                }
                dr.Close();
                con.Close();
                cmd.Dispose();
            }
            catch (Exception)
            {
                ra = "";
            }
            return ra;
        }

        public bool InserirAAP(string[] ra, string[]nome, string nome_projeto,ref string mensagem, int codigo_aluno, ref int codigo_grupo)
        {
            status = false;
            string[] ra_aux = new string[ra.Length];
            string[] nome_aux = new string[nome.Length];
            
            for (int i = 0; i < ra_aux.Length; i++)
            {
                ra_aux[i] = ra[i];
                nome_aux[i] = nome[i];
            }
            int cd_projeto = 0;

            try
            {
                con = conex.abrirConexao();
                cmd.Connection = con;
                
                cmd.CommandText = "select idprojeto from projetos where nomemateria ~* @param;";
                cmd.Parameters.AddWithValue("@param", nome_projeto);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                     cd_projeto = Convert.ToInt32(dr["idprojeto"]);
                }
                    dr.Close();

                    cmd.Parameters.Clear();

                    DateTime dt = DateTime.Now;
                    string dataupload = dt.Year + "/" + dt.Month + "/" + dt.Day;

                    cmd.CommandText = "insert into arquivoentradaaap(nomeaap,diretorioaap,notaaap,datauploadaap,fk_idprojeto) values (@nomeaap,@diraap,0,@dataupload,@fk_idprojeto)";
                    cmd.Parameters.AddWithValue("@nomeaap", nome_projeto);
                    cmd.Parameters.AddWithValue("@diraap", caminho);
                    cmd.Parameters.AddWithValue("@dataupload", dataupload);
                    cmd.Parameters.AddWithValue("@fk_idprojeto", cd_projeto);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();

                    int cd_aap = 0;
                    cmd.CommandText = "select idaap from arquivoentradaaap where fk_idprojeto = @fk_idprojeto";
                    cmd.Parameters.AddWithValue("@fk_idprojeto", cd_projeto);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        cd_aap = Convert.ToInt32(dr["idaap"]);
                        dr.Close();
                    }
                    cmd.Parameters.Clear();


                    cmd.CommandText = "insert into grupos(fk_idaap) values(@fk_idaap)";
                    cmd.Parameters.AddWithValue("@fk_idaap", cd_aap);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();

                    int cd_grupo = 0;

                    cmd.CommandText = "select idgrupo from grupos join arquivoentradaaap on grupos.fk_idaap = arquivoentradaaap.idaap where arquivoentradaaap.fk_idprojeto=@fk_idprojeto and arquivoentradaaap.idaap = @idaap;";
                    cmd.Parameters.AddWithValue("@fk_idprojeto", cd_projeto);
                    cmd.Parameters.AddWithValue("@idaap", cd_aap);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        cd_grupo = Convert.ToInt32(dr["idgrupo"]);
                    }

                    codigo_grupo = cd_grupo;

                    dr.Close();
                    cmd.Parameters.Clear();

                    string nome_aap = nome_projeto + "_" + cd_grupo;
                    string diretorio_aap = "C:\\Users\\matgu\\OneDrive\\Documents\\AAPs\\Listas Alunos\\" + nome_projeto + "\\Arquivos_AAPs\\" + nome_aap + ".xls";
                    cmd.CommandText = "update arquivoentradaaap set nomeaap=@nome, diretorioaap=@diretorioaap where idaap=@idaap";
                    cmd.Parameters.AddWithValue("@nome", nome_aap);
                    cmd.Parameters.AddWithValue("@diretorioaap", diretorio_aap);
                    cmd.Parameters.AddWithValue("@idaap", cd_aap);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();


                    int[] codigos = new int[ra.Length]; //vetor que armazena os códigos de cada aluno

                    for (int i = 0; i < ra.Length; i++)
                    {
                        if (!ra[i].Equals(" "))
                        {
                            cmd.CommandText = "select idaluno from Alunos where ra=@ra";
                            cmd.Parameters.AddWithValue("@ra", ra_aux[i]);
                            dr = cmd.ExecuteReader();
                            if (dr.Read())
                            {
                                codigos[i] = Convert.ToInt32(dr["idaluno"]);
                            }
                        }
                        dr.Close();
                        cmd.Parameters.Clear();
                    }

                    for (int i = 0; i < codigos.Length; i++)
                    {
                        if (codigos[i] != 0)
                        {
                            cmd.CommandText = "insert into integrantes(aluno_id,fk_idgrupo) values (@alid,@fkidgrupo)";
                            cmd.Parameters.AddWithValue("@alid", codigos[i]);
                            cmd.Parameters.AddWithValue("@fkidgrupo", cd_grupo);
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                    }

                    for (int i = 0; i < codigos.Length; i++)
                    {
                        if (codigos[i] != 0)
                        {
                            cmd.CommandText = "insert into pesquisas (aluno_id,aap_id,relatorio_id,projeto_id,situacao) values (@aluno_id,@aap_id,0,@projeto_id,@situacao)";
                            cmd.Parameters.AddWithValue("@aluno_id", codigos[i]);
                            cmd.Parameters.AddWithValue("@aap_id", cd_aap);
                            cmd.Parameters.AddWithValue("@projeto_id", cd_projeto);
                            cmd.Parameters.AddWithValue("@situacao", "Aguardando");
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                    }
                mensagem = "AAP inserida com sucesso!";
                    con.Close();
                    cmd.Dispose();
                    status = true;
                }
            
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public bool inserirPortfolio(string[] aaps, string nome_materia, int codigo_aluno, int codigo_projeto, string caminho)
        {
            DateTime dt = new DateTime();
            dt = DateTime.Now;

            int[] aaps_aux = new int[aaps.Length];

            string datacriacao = dt.Year + "-" + dt.Month + "-" + dt.Day;
            try
            {
                con = conex.abrirConexao();
                cmd.Connection = con;
                NpgsqlDataReader dr;
                for (int i = 0; i < aaps_aux.Length; i++)
                {
                    cmd.CommandText = "select projeto_id from pesquisas join projetos on projetos.idprojeto = pesquisas.projeto_id where projetos.nomemateria=@nomemateria and pesquisas.aluno_id = @aluno_id";
                    cmd.Parameters.AddWithValue("@nomemateria", aaps[i]);
                    cmd.Parameters.AddWithValue("@aluno_id", codigo_aluno);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        aaps_aux[i] = Convert.ToInt32(dr["projeto_id"]);
                    }
                    dr.Close();
                    cmd.Parameters.Clear();
                }

                cmd.CommandText = "insert into arquivoentradarelatorio (nomerelatorio, notarelatorio, datacriacaorelatorio,fk_idaluno, portfolio_id, caminho_relatorio) values (@nomerelatorio, @notarelatorio, @datacriacaorelatorio,@fk_idaluno,@portfolio_id, @caminho_relatorio)";
                cmd.Parameters.AddWithValue("@nomerelatorio", nome_materia);
                cmd.Parameters.AddWithValue("@notarelatorio", 0);
                cmd.Parameters.AddWithValue("@datacriacaorelatorio", datacriacao);
                cmd.Parameters.AddWithValue("@fk_idaluno", codigo_aluno);
                cmd.Parameters.AddWithValue("@portfolio_id", codigo_projeto);
                cmd.Parameters.AddWithValue("@caminho_relatorio", caminho);
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();

                int codigo_relatorio = 0;

                cmd.CommandText = "select arquivoentradarelatorio.idrelatorio where fk_idaluno=@fk_idaluno and portfolio_id=@portfolio_id;";
                cmd.Parameters.AddWithValue("@fk_idaluno", codigo_aluno);
                cmd.Parameters.AddWithValue("@portfolio_id", codigo_projeto);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    codigo_relatorio = Convert.ToInt32(dr["idrelatorio"]);
                }
                dr.Close();

                cmd.Parameters.Clear();

                for (int i = 0; i < aaps_aux.Length; i++)
                {
                    cmd.CommandText = "update pesquisas set relatorio_id = @relatorio_id where aluno_id=@aluno_id and projeto_id=@projeto_id;";
                    cmd.Parameters.AddWithValue("@relatorio_id", codigo_relatorio);
                    cmd.Parameters.AddWithValue("@aluno_id", codigo_aluno);
                    cmd.Parameters.AddWithValue("@projeto_id", aaps_aux[i]);
                    cmd.Parameters.Clear();
                }
                con.Close();
                cmd.Dispose();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }

            return status;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="projeto">Parâmetro que verifica se um projeto em específico foi apontado como parâmetro de pesquisa</param>
        /// <param name="id_aluno">Parâmetro que contém um código de um aluno (aluno logado)</param>
        /// <param name="status_carregamento">True - Dados carregados com sucesso
        ///                                   False - Falha ao carregar os dados</param>
        /// <returns></returns>
        public DataSet carregaNotas(string projeto, int id_aluno,ref bool status_carregamento)
        {
            NpgsqlDataAdapter da = new NpgsqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con = conex.abrirConexao();
                cmd.Connection = con;

                if (projeto.Equals("Todos"))
                {
                    cmd.CommandText = "select projetos.nomemateria as Nome, arquivoentradaaap.notaaap as Nota, pesquisas.situacao as Situacao from arquivoentradaaap join pesquisas on pesquisas.aap_id = arquivoentradaaap.idaap join projetos on projetos.idprojeto = fk_idprojeto where pesquisas.aluno_id = @idaluno;";
                    cmd.Parameters.AddWithValue("@idaluno", id_aluno);
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();
                    cmd.Dispose();
                    status_carregamento = true;
                }
                else
                {
                    con.Close();
                    id_projeto = pegaCodigoProjeto(projeto);

                    con = conex.abrirConexao();
                    cmd.CommandText = "select projetos.nomemateria as Nome, arquivoentradaaap.notaaap as Nota, pesquisas.situacao as Situacao from arquivoentradaaap join pesquisas on pesquisas.aap_id = arquivoentradaaap.idaap join projetos on projetos.idprojeto = fk_idprojeto where pesquisas.aluno_id = @idaluno and arquivoentradaaap.fk_idprojeto = @fk_idprojeto;";
                    cmd.Parameters.AddWithValue("@idaluno", id_aluno);
                    cmd.Parameters.AddWithValue("@fk_idprojeto", id_projeto);
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();
                    cmd.Dispose();
                    status_carregamento = true;
                }
                
            }
            catch (Exception)
            {
                status_carregamento = false;
            }
            return ds;
        }


        public bool ValidaIntegrantesGrupo(string[] ras, string[] nomes)
        {
            string[] ra_aux = new string[ras.Length];
            string[] nome_aux = new string[nomes.Length];
            int qtde_alunos = 0, qtde_registros = 0; 


            for (int i = 0; i < ra_aux.Length; i++)
            {
                ra_aux[i] = ras[i];
                nome_aux[i] = nomes[i];
                if (!ra_aux[i].Equals(" "))
                {
                    qtde_registros++;
                }   
            }

            try
            {
                con = conex.abrirConexao();
                cmd.Connection = con;
                NpgsqlDataReader dr;
                for (int i = 0; i < ra_aux.Length; i++)
                {
                    cmd.CommandText = "select * from alunos where ra=@ra and nomealuno=@nomealuno";
                    cmd.Parameters.AddWithValue("@ra", ra_aux[i]);
                    cmd.Parameters.AddWithValue("@nomealuno", nome_aux[i]);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        qtde_alunos++;
                    }
                    dr.Close();
                    cmd.Parameters.Clear();
                }

                if (qtde_alunos == qtde_registros)
                {
                    status = true;
                }
                con.Close();
                cmd.Dispose();
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public bool verificaAapEnviada(string nome_projeto)
        {
            int codigo_projeto = 0;
            try
            {
                codigo_projeto = pegaCodigoProjeto(nome_projeto);

                con = conex.abrirConexao();
                cmd.Connection = con;

                cmd.CommandText = "select * from arquivoentradaaap where fk_idprojeto=@fk_idprojeto";
                cmd.Parameters.AddWithValue("@fk_idprojeto", codigo_projeto);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
                dr.Close();
                con.Close();
                cmd.Dispose();
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }


        public List<string> CarregaIntegrantesGrupo(int cd_aluno, ref bool status, string nome_aluno, ref string aap)
        {
            int codigo_aluno = cd_aluno;
            int codigo_grupo = 0;
            int codigo_aap = 0;
            string nm_aluno = nome_aluno;
            List<string> integrantes = new List<string>();
            try
            {
                con = conex.abrirConexao();
                cmd.Connection = con;
                
                cmd.CommandText = "select fk_idgrupo from integrantes where aluno_id=@cd_aluno";
                cmd.Parameters.AddWithValue("@cd_aluno", codigo_aluno);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    status = true;
                    codigo_grupo = Convert.ToInt32(dr["fk_idgrupo"]);
                }
                else
                {
                    status = false;
                }
                dr.Close();

                //limpa os parâmetros do NpgsqlCommand
                cmd.Parameters.Clear();

                //Monta a lista de integrantes 
                cmd.CommandText = "select alunos.nomealuno from alunos join integrantes on integrantes.aluno_id = alunos.idaluno where integrantes.fk_idgrupo=@fk_idgrupo and alunos.nomealuno != @userlogado;";
                cmd.Parameters.AddWithValue("@fk_idgrupo", codigo_grupo);
                cmd.Parameters.AddWithValue("@userlogado", nm_aluno);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    integrantes.Add(dr["nomealuno"].ToString());
                }
                status = true;
                dr.Close();

                cmd.Parameters.Clear();
                cmd.CommandText = "select grupos.fk_idaap from grupos join arquivoentradaaap on arquivoentradaaap.idaap = grupos.fk_idaap where grupos.idgrupo=@idgrupo;";
                cmd.Parameters.AddWithValue("@idgrupo", codigo_grupo);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    codigo_aap = Convert.ToInt32(dr["fk_idaap"]);
                }
                dr.Close();

                cmd.Parameters.Clear();
                cmd.CommandText = "select arquivoentradaaap.nomeaap from arquivoentradaaap join grupos on grupos.fk_idaap = arquivoentradaaap.idaap where idaap=@idaap;";
                cmd.Parameters.AddWithValue("@idaap", codigo_aap);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    aap = dr["nomeaap"].ToString();
                    status = true;
                }
                dr.Close();
                con.Close();
                cmd.Dispose();
            }
            catch (Exception)
            {
                status = false;
            }
            return integrantes;
        }

        public string pegaNomeAluno(int codigo_aluno)
        {
            string nome_aluno = "";
            try
            {
                con = conex.abrirConexao();
                cmd.Connection = con;
                cmd.CommandText = "select alunos.nomealuno from alunos where idaluno = @idaluno";
                cmd.Parameters.AddWithValue("@idaluno", codigo_aluno);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    nome_aluno = dr["nomealuno"].ToString();
                }
                dr.Close();
                con.Close();
                cmd.Dispose();
            }
            catch (Exception)
            {
                nome_aluno = "";
            }
            
            return nome_aluno;
        }


        public int pegaCodigoAluno(string nome_usuario)
        {
            int cd_aluno = 0;
            string nm_user = nome_usuario;
            try
            {
                con = conex.abrirConexao();
                cmd.Connection = con;
                cmd.CommandText = "select alunos.idaluno from alunos join usuarios on alunos.ra = usuarios.nomeusuario where usuarios.nomeusuario=@nomeusuario;";
                cmd.Parameters.AddWithValue("@nomeusuario", nm_user);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    cd_aluno = Convert.ToInt32(dr["idaluno"]);
                }
                dr.Close();
                con.Close();
                cmd.Dispose();
            }
            catch (Exception)
            {
                cd_aluno = 0;
            }
            return cd_aluno;
        }

        public int pegaCodigoProjeto(string nome_projeto)
        {
            try
            {
                con = conex.abrirConexao();
                cmd.Connection = con;

                cmd.CommandText = "select idprojeto from projetos where nomemateria ~* @nomeprojeto; ";
                cmd.Parameters.AddWithValue("@nomeprojeto", nome_projeto);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    id_projeto = Convert.ToInt32(dr["idprojeto"]);
                }
                else
                {
                    id_projeto = 0;
                }
                dr.Close();
                con.Close();
                cmd.Dispose();
            }
            catch (Exception)
            {
                id_projeto = 0;
            }

            return id_projeto;
        }
        
        public string[] carregaAAps(string nome_usuario, ref int semestre)
        {
            string[] aapsConcluidas = new string[1];
            string mensagem = "";
            int id_aluno = 0;
            int qtde_materias = 0;
            try
            {
                
                id_aluno = pegaCodigoAluno(nome_usuario);
                con = conex.abrirConexao();
                cmd.Connection = con;
                cmd.CommandText = "select alunos.semestre from alunos where idaluno=@idaluno";
                cmd.Parameters.AddWithValue("@idaluno", id_aluno);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    semestre = Convert.ToInt32(dr["semestre"]);
                }
                dr.Close();
                cmd.Parameters.Clear();

                cmd.CommandText = "select count(*) from projetos join pesquisas on pesquisas.projeto_id = projetos.idprojeto where pesquisas.aluno_id = 22 and pesquisas.situacao = 'Aprovado';";
                cmd.Parameters.AddWithValue("@idaluno", id_aluno);
                dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    qtde_materias = Convert.ToInt32(dr.GetValue(0));
                }
                dr.Close();
                cmd.Parameters.Clear();

                if (qtde_materias > 0)
                {
                    int i = 0;
                    aapsConcluidas = new string[qtde_materias];
                    cmd.CommandText = "select projetos.nomemateria from projetos join pesquisas on pesquisas.projeto_id = projetos.idprojeto where pesquisas.aluno_id=@aluno_id and pesquisas.situacao = 'Aprovado';";
                    cmd.Parameters.AddWithValue("@aluno_id", id_aluno);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        aapsConcluidas[i] = dr[i].ToString();
                        i++;
                    }
                    dr.Close();
                    con.Close();
                    cmd.Dispose();
                    mensagem = "AAps carregadas!";
                }
                else
                {
                    aapsConcluidas[0] = "Não há AAPs para este aluno!";
                    mensagem = "Nenhuma AAP identificada como concluída!";
                }
            }
            catch (Exception)
            {
                mensagem = "Falha ao carregar as AAPS";
            }

            return aapsConcluidas;
        }
    }
}