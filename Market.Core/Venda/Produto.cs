using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Core.Venda
{
    public class Produto
    {
        public string Nome { get; private set; }
        public decimal Valor { get; private set; }
        public int Quantidade { get; private set; }

        public Produto(string nome, decimal valor, int quantidade)
        {
            this.Nome = nome;
            this.Valor = valor;
            this.Quantidade = quantidade;
        }
    }
}
