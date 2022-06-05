using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Core.Venda
{
    public class Carrinho
    {
        public decimal ValorTotal => _produtos.Sum(x => x.Valor);
        private readonly List<Produto> _produtos = new();

        public void AdicionarProduto(Produto produto)
        {
            _produtos.Add(produto);
        }

        public IList ObterProdutos()
        {
            return _produtos;
        }
    }
}
