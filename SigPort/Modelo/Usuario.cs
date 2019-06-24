using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SigPort.Modelo
{
    public class Usuario
    {
        //Atributos e encapsulamento
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public int tipo_usuario { get; set; }
        
    }
}