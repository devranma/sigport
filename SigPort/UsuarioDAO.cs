using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Data.OleDb;

namespace SigPort.Modelo
{
    public class UsuarioDAO
    {
        ConexaoBanco conex = new ConexaoBanco();
        Workbook wb;
        Worksheet ws;
        _Application excel = new Excel.Application();
        string caminho = "C:\\Users\\matgu\\OneDrive\\Área de Trabalho\\planilha_alunos.xlsx";
        string usuario;
        string senha;
        private OleDbCommand cmd = new OleDbCommand();

        public bool AutenticarUsuario(string usuario, string senha)
        {
            this.usuario = usuario;
            this.senha = senha;
            bool status_autenticacao = false;
            try
            {
                cmd.Connection = conex.abrirConexao();
                cmd.CommandText = "select * from usuarios where nome_usuario = @nome and senha_usuario = @senha";
                cmd.Parameters.AddWithValue("@nome", usuario);
                cmd.Parameters.AddWithValue("@senha", senha);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    status_autenticacao = true;
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                    dr.Close();
                    conex.fecharConexao();
                }
                else
                {
                    dr.Close();
                    cmd.CommandText = "select ativoNoSistema from Alunos where nome = @nome and ra = @ra";
                    cmd.Parameters.AddWithValue("@nome", usuario);
                    cmd.Parameters.AddWithValue("@ra", senha);
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Close();
                        cmd.Dispose();
                        conex.fecharConexao();
                        wb = excel.Workbooks.Open(caminho);
                        ws = wb.Worksheets[1];
                        Excel.Range tamanho_planilha = ws.UsedRange;
                        string aux_usuario = "";
                        string aux_senha = "";
                        for (int i = 2; i <= tamanho_planilha.Rows.Count; i++)
                        {
                            
                                aux_senha = Convert.ToString(ws.Cells[i, 1].Value);
                                aux_usuario = Convert.ToString(ws.Cells[i, 2].Value);
                                if (usuario.Equals(aux_usuario) && senha.Equals(aux_senha))
                                {
                                    OleDbCommand cmdinserirn = new OleDbCommand();
                                    cmdinserirn.Parameters.Clear();
                                    cmdinserirn.CommandText = "";
                                    cmdinserirn.Connection = conex.abrirConexao();
                                    cmdinserirn.CommandText = "insert into usuarios (nome_usuario,senha_usuario) values (@nome,@senha)";
                                    string novo_nome_usuario = usuario + senha[10] + senha[11] + senha[12];
                                    string nova_senha = "123456789";
                                    cmdinserirn.Parameters.AddWithValue("@nome", novo_nome_usuario);
                                    cmdinserirn.Parameters.AddWithValue("@senha", nova_senha);
                                    cmdinserirn.ExecuteNonQuery();
                                    status_autenticacao = true;
                                    cmdinserirn.Dispose();
                                    conex.fecharConexao();
                                    break;
                                }
                                else
                                {
                                    status_autenticacao = false;
                                }
                            
                        }
                        wb.Close();

                    }



                }
            }
            catch (Exception)
            {

                wb.Close();
            }

            return status_autenticacao;
        }
        

        
    }
}