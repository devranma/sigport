using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;

namespace SigPort.Modelo
{
    public class Aluno:Usuario
    {

        //Atributos e encapsulamento
        public int idaluno { get; set; }
        public string raAluno { get; set; }
        public string nomeAluno { get; set; }
        public int semestre { get; set; }
        public bool ativoNoSistema { get; set; }

        ConexaoBanco conex = new ConexaoBanco();
        NpgsqlConnection con = new NpgsqlConnection();
        NpgsqlCommand cmd = new NpgsqlCommand();


        //Métodos
        public bool enviarAap(int idaluno, string[] listaalunos)
        {
            bool status = false;
            string[] lista;
            try
            {
                cmd.Connection = conex.abrirConexao();
                lista = new string[listaalunos.Length];
                cmd.CommandText = "select ";
                for (int i = 0; i < lista.Length; i++)
                {
                    
                }
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
    }
}