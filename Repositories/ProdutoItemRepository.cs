using Microsoft.EntityFrameworkCore;
using Senai_Aula6.Context;
using Senai_Aula6.Domains;
using Senai_Aula6.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Aula6.Repositories
{
    public class ProdutoItemRepository : IProdutoItemRepository
    {
        private readonly PedidoContext _ctx;

        public ProdutoItemRepository()
        {
            _ctx = new PedidoContext();
        }

        /// <summary>
        /// Adiciona um novo pedido
        /// </summary>
        /// <returns>Objeto Pedido</returns>
        public Pedido Adicionar(List<Domains.ProdutoItem> produtoItens)
        {
            try
            {
                //Crio um objeto do tipo pedido
                Pedido pedido = new Pedido
                {
                    Status = "Pedido Efetuado",
                    OrderData = DateTime.Now,
                    ProdutoItens = new List<Domains.ProdutoItem>()
                };

                //Adiciono itens ao meu pedidoItens
                foreach (var item in produtoItens)
                {
                    pedido.ProdutoItens.Add(new ProdutoItem
                    {
                        IdPedido = pedido.Id, //Id do pedido criado acima
                        IdProduto = item.IdProduto, //Item da lista recebida como parametro
                        Quantidade = item.Quantidade //Item da lista recebida como parametro
                    });
                }

                //Adiciona ao contexto
                _ctx.Pedido.Add(pedido);
                //Salva as alterações do contexto no banco de dados
                _ctx.SaveChanges();

                return pedido;
            }
            catch (System.Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Pedido> Listar()
        {
            try
            {
                //return _ctx.Pedidos.Include("PedidosItens").ToList();
                // SQL - Inner Join
                return _ctx.Pedido
                        .Include(i => i.ProdutoItens)
                        .ThenInclude(x => x.Produto)
                        .ToList();
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
