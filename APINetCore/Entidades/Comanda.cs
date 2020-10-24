using APINetCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINetCore.Entidades
{
    public class Comanda
    {
        protected Comanda() { }

        public Comanda(DateTime dtAbertura)
        {
            this.dtAbertura = dtAbertura;
            this.dtFechamento = DateTime.MaxValue;
            this.statusComanda = StatusComandaEnum.Aberta;
        }

        public int Id { get; set; }
        public StatusComandaEnum statusComanda { get; set; }
        public DateTime dtAbertura { get; set; }
        public DateTime dtFechamento { get; set; }

        public List<ItensComanda> ComandaItens { get; private set; }
    }
}
