using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senai_Aula6.Domains;
using Senai_Aula6.Interfaces;
using Senai_Aula6.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Senai_Aula6.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoItemController : ControllerBase
    {

        private readonly IProdutoItemRepository _repo;
        public ProdutoItemController()
        {
            _repo = new ProdutoItemRepository();
        }

        // GET: api/<ProdutoItemController>
     [HttpGet]
   
        public IActionResult Get()
        {
            try
            {
                var pedidos = _repo.Listar();

                if (pedidos.Count == 0)
                    return NoContent();

                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Post(List<ProdutoItem> pedidosItens)
        {
            try
            {
                //Adiciona um novo pedido com os itens do pedido
                Pedido pedido = _repo.Adicionar(pedidosItens);

                //Caso ok retorna o pedido
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

      
    }
}
