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
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepository _repo;

        public PedidoController()
        {
            _repo = new PedidoRepository();
        }
        // GET: api/<PedidoController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var pedido = _repo.Listar();

                if (pedido.Count == 0)
                    return NoContent();

                return Ok(pedido);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET api/<PedidoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
               Pedido pedido = _repo.BuscarPorId(id);

                if (pedido == null)
                    return NotFound();

                return Ok(pedido);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message); 
            }
        }

        // POST api/<PedidoController>
        [HttpPost]
        public IActionResult Post(Pedido pedido)
        {
            try
            {
                _repo.Adicionar(pedido);


                return Ok(pedido);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PedidoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id,Pedido pedido)
        {
            try
            {
                pedido.Id = id;

                _repo.Editar(id, pedido);

                return Ok(pedido);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<PedidoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var pedido =_repo.BuscarPorId(id);

                if (pedido == null)
                    return NotFound();

                _repo.Remover(id);
                return Ok(pedido);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
