using System.Collections;

namespace Market.Core.Venda
{
    public class Carrinho
    {
        public decimal ValorTotal => _produtos.Sum(x => x.Valor);
        private readonly List<Produto> _produtos = new();

        public void AdicionarProduto(Produto produto)
        {

            if (produto.Valor <= 0)
                throw new ArgumentException("produto com valor inválido");

            _produtos.Add(produto);
        }

        public List<Produto> ObterProdutos()
        {
            return _produtos;
        }

        public void ExcluirProduto(Produto produtoASerRemovido)
        {
            _produtos.Remove(produtoASerRemovido);
        }
    }
}
