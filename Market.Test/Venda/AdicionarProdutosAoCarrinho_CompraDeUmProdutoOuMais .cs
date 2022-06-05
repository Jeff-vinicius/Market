using Market.Core.Venda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace Market.Test.Venda
{
    [Binding]
    public class AdicionarProdutosAoCarrinho_CompraDeUmProdutoOuMais
    {
        private Carrinho _carrinho = new();
        private List<Produto> _produtos = new();
        private readonly ScenarioContext _scenarioContext;

        public AdicionarProdutosAoCarrinho_CompraDeUmProdutoOuMais(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"que o cliente selecionou um produto ou mais")]
        public void DadoQueOClienteSelecionouUmProdutoOuMais()
        {
            //Arrange = Cenário 

            var produto = new Produto("Mouse", 29.99M, 1);
            var produto2 = new Produto("Fone de Ouvido", 99.99M, 1);
            _produtos.Add(produto);
            _produtos.Add(produto2);
        }

        [When(@"o cliente inclui-los ao carrinho")]
        public void QuandoOClienteInclui_LosAoCarrinho()
        {
            //Act = o método a ser testado

            foreach (var produto in _produtos)
            {
                _carrinho.AdicionarProduto(produto);
            }
        }

        [Then(@"listar os produtos no carrinho e o valor total do pedido")]
        public void EntaoListarOsProdutosNoCarrinhoEOValorTotalDoPedido()
        {
            //Assert = resultado esperado 

            var valorEsperado = 2;
            var valorEncontrato = _carrinho.ObterProdutos().Count;

            Assert.Equal(valorEsperado, valorEncontrato);
        }

        [Then(@"o valor total do pedido")]
        public void EntaoOValorTotalDoPedido()
        {
            //Assert = resultado esperado 

            var valorEsperado = 129.98M;
            var valorEncontrato = _carrinho.ValorTotal;

            Assert.Equal(valorEsperado, valorEncontrato);
        }
    }
}
