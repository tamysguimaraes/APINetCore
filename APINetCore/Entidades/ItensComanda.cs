using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINetCore.Entidades
{
    public class ItensComanda
    {
        private ItensComanda() { }

        public ItensComanda(int idComanda,int idProduto, int qtde)
        {
            this.IdComanda = idComanda;
            this.IdProduto = idProduto;
            this.quantidade = qtde;
        }

        public int Id { get; set; }
        public int IdComanda { get; set; }
        public Comanda Comanda { get; set; }
        public int IdProduto { get; set; }
        public Produtos Produto { get; set; }
        public int quantidade { get; set; }
    }
}
