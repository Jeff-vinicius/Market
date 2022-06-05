using Market.Core.Venda;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using Xunit;


namespace Market.Test.Venda
{
    [Binding]
    public class RemoverItemCarrinho_PedidoComUmOuMaisItens
    {       
        private Carrinho _carrinho;
        private Produto _produtoASerRemovido;
        private List<Produto> _produtos;

        [Given(@"que o cliente deseja remover um item")]
        public void DadoQueOClienteDesejaRemoverUmItem()
        {
            //Arrange = Cenário 
            _produtos = new();
            _produtos.Add(new Produto("Mouse", 29.90M, 2));
            _produtos.Add(new Produto("Fone", 59.90M , 1));
            _produtos.Add(new Produto("Monitor", 599.90M, 1));

            _carrinho = new();
            foreach (var produto in _produtos)
            {
                _carrinho.AdicionarProduto(produto);
            }

            var produtos = _carrinho.ObterProdutos();
            _produtoASerRemovido = produtos.First();
        }

        [When(@"o cliente clicar em excluir")]
        public void QuandoOClienteClicarEmExcluir()
        {
            //Act = o método a ser testado
            _carrinho.ExcluirProduto(_produtoASerRemovido);
        }

        [Then(@"remover o item do carrinho")]
        public void EntaoRemoverOItemDoCarrinho()
        {
            //Assert = resultado esperado 
            var valosEsperado = 2;
            var valorEncontrado = _carrinho.ObterProdutos().Count;

            Assert.Equal(valosEsperado, valorEncontrado);
        }
    }
}
