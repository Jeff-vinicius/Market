# language: pt
Funcionalidade: Adicionar produtos ao carrinho
  O cliente deve ser capaz de cadastrar uma compra com apenas um item ou mais.

 Regras:
  Não deve ser possível cadastrar produtos com valor igual ou inferior a 0

  Cenário: Compra de um produto ou mais 
    Dado que o cliente selecionou um produto ou mais 
    Quando o cliente inclui-los ao carrinho 
    Então listar os produtos no carrinho e o valor total do pedido 
    E o valor total do pedido 

  Cenário: Compra de produtos com valor igual ou inferior a 0
    Dado que o cliente selecionou um produto com valor zerado 
    Quando o cliente tentar incluir o produto no carrinho 
    Então eu verei a mensagem de erro: "produto com valor inválido"
    E não incluir o produto