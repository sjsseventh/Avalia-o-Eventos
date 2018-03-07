using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evento.AcessoADados.ModelView;
using Evento.AcecssoADados.ModelView;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegrasDeNegocio;

namespace Eventos.Controllers
{
    [Route("api/Participante")]
    public class ParticipanteController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody] ParticipanteModelView participanteModelView)
        {
            try
            {
                var _participanteBll = new ParticipanteBll();
                _participanteBll.Inserir(participanteModelView);
                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }
        }

        [HttpGet("{idParticipante}")]
        public IActionResult ObterPorId(int idParticipante)
        {
            try
            {
                var _participanteBll = new ParticipanteBll();
                var participante = _participanteBll.ObterPorId(idParticipante);
                return Json(participante);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        public IActionResult RetornarTodos()
        {
            try
            {
                var _participanteBll = new ParticipanteBll();
                var listaParcipantes = _participanteBll.ObterTodos();
                return Json(listaParcipantes);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{idParticipante}")]
        public IActionResult Atualizar(int idParticipante, [FromBody] ParticipanteModelView participanteModelView)
        {
            try
            {
                var _participanteBll = new ParticipanteBll();
                _participanteBll.Atualizar(idParticipante, participanteModelView);
                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete("{idParticipante}")]
        public IActionResult Delete(int idParticipante)
        {
            try
            {
                var _participanteBll = new ParticipanteBll();
                _participanteBll.Deletar(idParticipante);
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