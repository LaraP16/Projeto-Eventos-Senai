using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_eventos.DAO;
using api_eventos.Models;
using Microsoft.AspNetCore.Mvc;

namespace api_eventos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngressoController : ControllerBase
    {
        private IngressoDAO _ingressoDAO;
 
        public IngressoController(IngressoDAO ingressoDAO)
        {
            _ingressoDAO = ingressoDAO;
        }
       
        [HttpGet]
        public IActionResult GetIngresso()
        {
            var ingressos = _ingressoDAO.GetAll();
            return Ok(ingressos);
        }
 
        [HttpGet("{id}")]
        public IActionResult GetIngresso(int id)
        {
            var ingresso = _ingressoDAO.GetId(id);
 
            if (ingresso == null)
            {
                return NotFound();
            }
 
            return Ok(ingresso);
        }
 
        [HttpPost]
        public IActionResult CriarIngresso(Ingresso ingresso)
        {
            _ingressoDAO.CriarIngresso(ingresso);
            return Ok();
        }
 
        [HttpPut("{id}")]
        public IActionResult UpDateIngresso(int id, Ingresso ingresso)
        {
            if (_ingressoDAO.GetId(id) == null)
            {
                return NotFound();
            }
 
            _ingressoDAO.UpDateIngresso(id, ingresso);
 
            return Ok();
        }
 
        [HttpDelete("{id}")]
        public IActionResult DeletarIngresso(int id)
        {
            if (_ingressoDAO.GetId(id) == null)
            {
                return NotFound();
            }
 
            _ingressoDAO.DeletarIngresso(id);
            return Ok();
        }
    }
}