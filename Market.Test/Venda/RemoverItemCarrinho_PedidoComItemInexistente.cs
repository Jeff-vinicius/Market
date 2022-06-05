using Market.Core.Venda;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using Xunit;

namespace Market.Test.Venda
{
    [Binding]
    public class RemoverItemCarrinho_PedidoComItemInexistente
    {
        private Carrinho _carrinho;
        private Produto _produtoASerRemovido;
        private List<Produto> _produtos;
        private Action _action;


        [Given(@"que o cliente deseja remover um item que não existe no carrinho")]
        public void DadoQueOClienteDesejaRemoverUmItemQueNaoExisteNoCarrinho()
        {
            //Arrange = Cenário 
            _produtos = new();
            _produtos.Add(new Produto("Mouse", 29.90M, 2));
            _produtos.Add(new Produto("Fone", 59.90M, 1));
            _produtos.Add(new Produto("Monitor", 599.90M, 1));

            _carrinho = new();
            foreach (var produto in _produtos)
            {
                _carrinho.AdicionarProduto(produto);
            }

            _produtoASerRemovido = new("Caneta", 2, 1);
        }

        [When(@"o cliente tentar excluir o item")]
        public void QuandoOClienteTentarExcluirOItem()
        {
            //Act = o método a ser testado
            _action = () => _carrinho.ExcluirProduto(_produtoASerRemovido);
        }

        [Then(@"enviar a mensagem de erro: ""(.*)""")]
        public void EntaoEnviarAMensagemDeErro(string valorEsperado)
        {
            //Assert = resultado esperado
            var exception = Assert.Throws<ArgumentException>(_action);

            Assert.Equal(valorEsperado, exception.Message);

        }

        [Then(@"manter os produtos no carrinho")]
        public void EntaoManterOsProdutosNoCarrinho()
        {
            //Assert = resultado esperado
            var valorEsperado = 3;
            var valorEncontrado = _carrinho.ObterProdutos().Count;

            Assert.Equal(valorEsperado, valorEncontrado);
        }
    }
}
