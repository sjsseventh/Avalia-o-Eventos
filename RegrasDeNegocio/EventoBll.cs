using System;
using System.Collections.Generic;
using System.Text;
using Evento.AcecssoADados.ModelView;
using Evento.AcessoADados.ObjetosDeAcesso;
using Evento.AcessoADados.Modelos;

namespace RegrasDeNegocio
{
    public class EventoBll
    {

        public void Inserir(EventoModelView eventoModelView)
        {
            var evento = new Event();
            evento = PrepararEvento(eventoModelView, evento);
            var _eventoDAO = new EventoDAO();

            _eventoDAO.Inserir(evento);
        }

        public void Atualizar(int idEvento, EventoModelView eventoModelView)
        {
            var _eventoDAO = new EventoDAO();
            var evento = _eventoDAO.ObterPorId(idEvento);

            evento = PrepararEvento(eventoModelView, evento);
            _eventoDAO.Atualizar(evento);
        }

        public Event ObterPorId(int idEvento)
        {
            var _eventoDAO = new EventoDAO();
            return _eventoDAO.ObterPorId(idEvento);
        }

        public void Deletar(int id)
        {
            var _eventoDAO = new EventoDAO();
            _eventoDAO.Deletar(id);
        }

        public Event PrepararEvento(EventoModelView eventoModelView, Event evento)
        {
            evento.Nome = eventoModelView.Nome;
            evento.Data = eventoModelView.Data;
            evento.Local = eventoModelView.Local;
            evento.HoraInicio = eventoModelView.HoraInicio;
            evento.HoraFim = eventoModelView.HoraFim;
            evento.OpenBar = eventoModelView.OpenBar;
            evento.QtdAmbientes = eventoModelView.QtdAmbientes;
            evento.NMaximoIngressos = eventoModelView.NMaximoIngressos;

            if (evento.HoraInicio > 10 && evento.HoraFim < 20 && evento.QtdAmbientes > 2)
            {
                evento.FaixaEtaria = "Menor que 16 anos";
            }

            else if (evento.HoraInicio > 20 && evento.HoraFim < 2 && evento.OpenBar == false)
            {
                evento.FaixaEtaria = "Maior que 16 anos";
            }

            else
            {
                evento.FaixaEtaria = "Maior que 18 anos";
            }

            return evento;
        }

        public List<Event> ObterTodos()
        {
            var _eventoDAO = new EventoDAO();
            return _eventoDAO.ObterTodos();
        }
    }
}
