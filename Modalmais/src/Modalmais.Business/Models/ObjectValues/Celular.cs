﻿using Modalmais.Business.Models.Enums;

namespace Modalmais.Business.Models.ObjectValues
{
    public class Celular
    {
        public Celular(DDDBrasil ddd, string numero)
        {
            DDD = ddd;
            Numero = numero;
        }

        public DDDBrasil DDD { get; set; }
        public string Numero { get; set; }
    }
}
