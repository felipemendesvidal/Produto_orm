using Senai_Aula6.Context;
using Senai_Aula6.Domains;
using Senai_Aula6.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Aula6.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidoContext _ctx;

        public PedidoRepository()
        {
            _ctx = new PedidoContext();
        }

        public void Adicionar(Pedido pedido)
        {
            try
            {
                _ctx.Pedido.Add(pedido);

                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Pedido BuscarPorId(Guid id)
        {
            try
            {
                Pedido pedido = _ctx.Pedido.Find(id);
                return pedido;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Pedido> BuscarPorStatus(string status)
        {
            try
            {
                List<Pedido> pedido = _ctx.Pedido.Where(x => x.Status.Contains(status)).ToList();
                return pedido;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Editar(Guid id,Pedido pedido)
        {
            try
            {
                Pedido pedidoTemp = BuscarPorId(pedido.Id);

                if (pedidoTemp == null)
                {
                    throw new Exception("Não foi possível achar o Id");
                }

                pedidoTemp.Status = pedido.Status;
                pedidoTemp.OrderData = pedido.OrderData;

                _ctx.Update(pedidoTemp);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Pedido> Listar()
        {
            try
            {
                List<Pedido> pedido = _ctx.Pedido.ToList();
                return pedido;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Remover(Guid id)
        {
            try
            {
                Pedido pedido = BuscarPorId(id);

                if (pedido == null)
                {
                    throw new Exception("Não foi possível achar o Id");
                }

                _ctx.Remove(pedido);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
