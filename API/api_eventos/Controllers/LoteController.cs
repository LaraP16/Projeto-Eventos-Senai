using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using api_eventos.DAO;
using api_eventos.Models; 


namespace api_eventos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoteController : ControllerBase
    {
        private LoteDAO _loteDAO;

        public LoteController()
        {
            _loteDAO = new LoteDAO();
        }
        
        [HttpGet]
        public IActionResult GetLotes()
        {
            var lotes= _loteDAO.GetAll();
            return Ok(lotes);
        }

        [HttpGet("{id}")]
        public IActionResult GetLote(int id)
        {
            var lote = _loteDAO.GetId(id);

            if (lote == null)
            {
                return NotFound();
            }

            return Ok (lote);
        }

        [HttpPost]
        public IActionResult CriarLote(Lote lote)
        {
            _loteDAO.CriarLote(lote);
            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult AtualizarLote(int id, Lote lote)
        {
            if (_loteDAO.GetId(id) == null)
            {
                return NotFound();
            }

            _loteDAO.AtualizarLote(id, lote);

            return Ok();

        
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarLote(int id)
        {
           
            if (_loteDAO.GetId(id) == null)
            {
                return NotFound();
            }

           _loteDAO.DeletarLote(id);
           return Ok();
          
        
        }
    }
}
