# language: pt
Funcionalidade: Remover um item do carrinho
  O cliente deve ser capaz de excluir um item por vez do carrinho de compras.

  Cenário: Pedido com um ou mais itens  
    Dado que o cliente deseja remover um item 
    Quando o cliente clicar em excluir
    Então remover o item do carrinho

  Cenário: Pedido com item inexistente 
    Dado que o cliente deseja remover um item que não existe no carrinho
    Quando o cliente tentar excluir o item 
    Então enviar a mensagem de erro: "Item não encontrato"
    E manter os produtos no carrinho