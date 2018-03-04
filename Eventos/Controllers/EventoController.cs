using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evento.AcecssoADados.ModelView;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegrasDeNegocio;

namespace Eventos.Controllers
{
    [Route("api/Evento")]
    public class EventoController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody] EventoModelView eventoModelView)
        {
            try
            {
                var _eventoBll = new EventoBll();
                _eventoBll.Inserir(eventoModelView);
                return NoContent();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }
        }


        [HttpGet("{idEvento}")]
        public IActionResult GetComId(int idEvento)
        {
            try
            {
                var _eventoBll = new EventoBll();
                var evento = _eventoBll.ObterPorId(idEvento);
                return Json(evento);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var _eventoBll = new EventoBll();
                var listaDeEventos = _eventoBll.ObterTodos();
                return Json(listaDeEventos);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }
        }

        [HttpPut("{idEvento}")]
        public IActionResult Put(int idEvento, [FromBody] EventoModelView eventoModelView)
        {
            try
            {
                var _eventoBll = new EventoBll();
                _eventoBll.Atualizar(idEvento, eventoModelView);
                return NoContent();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }
        }
    }
}