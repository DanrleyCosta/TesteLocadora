﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaDeLeilao
{
    public class Leilao
    {
        private IList<Lance> _lances;
        public Lance Ganhador { get; private set; }
        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }

        public Leilao(string peca)
        {
            Peca = peca;
            _lances = new List<Lance>();
        }

        public void RecebeLance(Interessada cliente, double valor)
        {
            _lances.Add(new Lance(cliente, valor));
        }

        public void IniciaPregao()
        {

        }

        public void TerminaPregao()
        {
            Ganhador = Lances.OrderBy(l => l.Valor).Last();
        }
    }
}
