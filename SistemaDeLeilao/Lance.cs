﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeLeilao
{
    public class Lance
    {
        public Interessada Cliente { get; }
        public double Valor { get; }

        public Lance(Interessada cliente, double valor)
        {
            Cliente = cliente;
            Valor = valor;
        }
    }
}
