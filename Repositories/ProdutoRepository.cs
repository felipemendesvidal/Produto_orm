using Senai_Aula6.Context;
using Senai_Aula6.Domains;
using Senai_Aula6.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Aula6.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly PedidoContext _ctx;

        public ProdutoRepository()
        {
            _ctx = new PedidoContext();
        }

        public void Adicionar(Produto produto)
        {
            try
            {
                //Dados salvos no contexto em memória
                _ctx.Produto.Add(produto);
                //_ctx.Set<Produto>().Add(produto);
                //_ctx.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                //Persisti os dados no banco de dados
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Produto BuscarPorId(Guid id)
        {
            try
            {
                //List<Produto> produto = _ctx.Produtos.Where(c => c.Nome == "produto").ToList();
                //Produto produto = _ctx.Produtos.FirstOrDefault(c => c.Id == id);
                Produto produto = _ctx.Produto.Find(id);
                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Produto> BuscarPorNome(string nome)
        {
            try
            {
                List<Produto> produtos = _ctx.Produto.Where(c => c.Nome.Contains(nome)).ToList();
                return produtos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Produto produto)
        {
            try
            {
                //Busco um produto pelo seu Id
                Produto produtoTemp = BuscarPorId(produto.Id);

                //Verifica se o produto existe, caso não exista gera uma exception
                if (produtoTemp == null)
                    throw new Exception("Produto não encontrado");

                //Altera as propriedades do produto
                produtoTemp.Nome = produto.Nome;
                produtoTemp.Preco = produto.Preco;

                //Altera o produto no contexto
                _ctx.Produto.Update(produtoTemp);
                //Salva o produto
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Produto> Listar()
        {
            try
            {
                List<Produto> produtos = _ctx.Produto.ToList();
                return produtos;
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
                //Busco um produto pelo seu Id
                Produto produto = BuscarPorId(id);

                //Verifica se o produto existe, caso não exista gera uma exception
                if (produto == null)
                    throw new Exception("Produto não encontrado");

                //Caso exista remove o produto
                _ctx.Produto.Remove(produto);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
