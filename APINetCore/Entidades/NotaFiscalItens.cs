using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINetCore.Entidades
{
    public class NotaFiscalItens
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public double ValorTotalItem { get; set; }
        public double ValorDesconto { get; set; }
        public double ValorComDesconto { get; set; }

        public int IdNotaFiscal { get; set; }
        public NotaFiscal NotaFiscal { get; set; }
        public int IdProduto { get; set; }
        public Produtos Produto { get; set; }
    }
}
