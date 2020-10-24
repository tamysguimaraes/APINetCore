using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINetCore.Entidades
{
    public class Produtos
    {
        private Produtos() { }

        public Produtos(string descricao, double valorUnitario)
        {
            Descricao = descricao;
            ValorUnitario = valorUnitario;
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public double ValorUnitario { get; set; }
    }
}
