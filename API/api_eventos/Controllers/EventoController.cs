using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api.DAO;
using api.Models;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private EventoDao _eventoDao;

        public EventosController()
        {
            _eventoDao = new EventoDao();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var eventos = _eventoDao.GetAll();
            return Ok(eventos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var evento = _eventoDao.GetById(id);

            if (evento == null)
            {
                return NotFound();
            }

            return Ok(evento);
        }

        [HttpPost]
        public IActionResult CreateEvento(Evento evento)
        {
            _eventoDao.CreateEvento(evento);
            return CreatedAtAction(nameof(GetById), new { id = evento.IdEvento }, evento);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEvento(int id, Evento evento)
        {
            if (_eventoDao.GetById(id) == null)
            {
                return NotFound();
            }

            _eventoDao.UpdateEvento(id, evento);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvento(int id)
        {
            if (_eventoDao.GetById(id) == null)
            {
                return NotFound();
            }

            _eventoDao.DeleteEvento(id);
            return NoContent();
        }
    }
}
