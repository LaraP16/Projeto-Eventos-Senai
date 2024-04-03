using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api_eventos.DAO;
using api_eventos.Models;
using ZstdSharp.Unsafe;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        
        private EventosUsuariosDAO _eventosusuariosDAO;

        public EventosController()
        {
            _eventosusuariosDAO = new EventosUsuariosDAO();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var usuario = _eventosusuariosDAO.GetAll();
            return Ok(usuario);
        }

        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            var usuario = _eventosusuariosDAO.GetId(id);
            if(usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        
        public IActionResult CriarUsuario(Usuario usuario)
        {
            _eventosusuariosDAO.CriarUsuario(usuario);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarUsuario(int id, Usuario usuario)
        {
            if(_eventosusuariosDAO.GetId(id) == null)
            {
                return NotFound();
            }
            _eventosusuariosDAO.AtualizarUsuario(id, usuario);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeletarUsuario(int id)
        {
            if (_eventosusuariosDAO.GetId(id) == null)
            {
                return NotFound();
            }
            _eventosusuariosDAO.DeletarUsuario(id);
            return Ok();
        }
    }
}