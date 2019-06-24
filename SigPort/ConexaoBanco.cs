using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;


namespace SigPort.Modelo
{
    public class ConexaoBanco
    {

        private string caminho = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\\Users\\matgu\\OneDrive\\Área de Trabalho\\teste.mdb";

        OleDbConnection conexao = new OleDbConnection();

        public OleDbConnection abrirConexao()
        {
            conexao.ConnectionString = caminho;
            conexao.Open();
            return conexao;
        }

        public OleDbConnection fecharConexao()
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
            
            return conexao;
        }
        
    }
}