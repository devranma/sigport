using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;

namespace SigPort.Modelo
{
    public class ConexaoBanco
    {

        private string conexao = "Server = 127.0.0.1; Port = 5432; Database = sigportdb; User id = sigportuser; password = Zt44TbV9LZFdGz7";

        NpgsqlConnection con = new NpgsqlConnection();

        public NpgsqlConnection abrirConexao()
        {
            con.ConnectionString = conexao;
            try
            {
                con.Open();
            }
            catch (Exception)
            {
                con = null;
            }
            return con;
        }

        public NpgsqlConnection fecharConexao()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    con.Close();
                }
                catch (Exception)
                {
                    con = null;
                }

            }

            return con;
        }

    }
}