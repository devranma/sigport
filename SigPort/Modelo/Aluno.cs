using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        


        
       
    }
}