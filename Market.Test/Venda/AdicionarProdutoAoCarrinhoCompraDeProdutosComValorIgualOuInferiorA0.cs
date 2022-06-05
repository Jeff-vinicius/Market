using Market.Core.Venda;
using System;
using TechTalk.SpecFlow;
using Xunit;


namespace Market.Test.Venda
{
    [Binding]
    public class AdicionarProdutoAoCarrinhoCompraDeProdutosComValorIgualOuInferiorA0
    {

        private Produto _produto;
        private Carrinho _carrinho;
        private Action _action;

        [Given(@"que o cliente selecionou um produto com valor zerado")]
        public void DadoQueOClienteSelecionouUmProdutoComValorZerado()
        {
            //Arrange = Cenário 
            _produto = new("Caneta", 0, 1);
        }

        [When(@"o cliente tentar incluir o produto no carrinho")]
        public void QuandoOClienteTentarIncluirOProdutoNoCarrinho()
        {
            //Act = o método a ser testado
            _carrinho = new();

            // usado dessa forma para verificar o resultado no Assert
            _action = () => _carrinho.AdicionarProduto(_produto);
        }

        [Then(@"eu verei a mensagem de erro: ""(.*)""")]
        public void EntaoEuVereiAMensagemDeErro(string valorEsperado)
        {
            //Assert = resultado esperado
            var exception = Assert.Throws<ArgumentException>(_action);

            Assert.Equal(valorEsperado, exception.Message);
        }

        [Then(@"não incluir o produto")]
        public void EntaoNaoIncluirOProduto()
        {
            //Assert = resultado esperado
            var valorEncontrado = 0;
            var valorEsperado = _carrinho.ObterProdutos().Count;

            Assert.Equal(valorEncontrado, valorEsperado);
        }
    }
}
