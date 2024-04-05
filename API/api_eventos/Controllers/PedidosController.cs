using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DAO;
using api_eventos.Models;
using Microsoft.AspNetCore.Mvc;

namespace api_eventos.Controllers
{
    [ApiController]
    [Route("api_eventos/[controller]")]
    public class PedidosController : ControllerBase
    {
        private PedidosDAO _PedidosDAO;

        public PedidosController()
        {
            _PedidosDAO = new PedidosDAO();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pedidos = _PedidosDAO.GetAll();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        { var pedido = _PedidosDAO.GetId(id);
 
            if (pedido == null)
            {
                return NotFound();
            }
 
            return Ok(pedido);
        }

        [HttpPost]
        public IActionResult CriarPedidos(Pedidos pedido)
        {
            _PedidosDAO.CriarPedidos(pedido);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarPedidos(int id, Pedidos pedido)
        {
            if (_PedidosDAO.GetId(id) == null)
            {
                return NotFound();
            }

            _PedidosDAO.AtualizarPedidos(id, pedido);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarPedidos(int id)
        {
            if (_PedidosDAO.GetId(id) == null)
            {
                return NotFound();
            }
            _PedidosDAO.DeletarPedidos(id);
            return Ok();
        }
    }
}
