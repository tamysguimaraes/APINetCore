using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINetCore.Entidades
{
    public class NotaFiscal
    {
        protected NotaFiscal() { }

        public NotaFiscal(int idComanda,DateTime dtEmissao)
        {
            this.IdComanda = idComanda;
            this.dtEmissao = dtEmissao;
        }

        public int Id { get; set; }
        public int IdComanda { get; set; }
        public DateTime dtEmissao { get; set; }
        public double valorTotal { get; set; }
        public double valorDesconto { get; set; }
        public double valorPago { get; set; }

        public List<NotaFiscalItens> notaFiscalItens { get; private set; }
    }
}
