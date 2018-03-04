using System;
using System.Collections.Generic;
using System.Text;
using Evento.AcecssoADados.ModelView;
using Evento.AcessoADados.ObjetosDeAcesso;
using Evento.AcessoADados.Modelos;
using Evento.AcessoADados.ModelView;

namespace RegrasDeNegocio
{
    public class ParticipanteBll : EventoBll
    {
        public void Inserir(ParticipanteModelView participanteModelView)
        {
            var participante = new Participante();
            participante = RetornaParticipante(participanteModelView, participante);
            var _participanteDAO = new ParticipanteDAO();

            _participanteDAO.Inserir(participante);
        }


        public Participante RetornaParticipante(ParticipanteModelView participanteModelView, Participante participante)
        {
            var evento = new Event();
            participante.Email = participanteModelView.Email;
            participante.Nome = participanteModelView.Nome;
            participante.IdEvento = participanteModelView.IdEvento;
            var _participanteDAO = new ParticipanteDAO();
            return participante;
        }

        public Participante ObterPorId(int idParticipante)
        {
            var _participanteDAO = new ParticipanteDAO();
            return _participanteDAO.ObterPorId(idParticipante);
        }

        public void Deletar(int idParticipante)
        {
            var _participanteDAO = new ParticipanteDAO();
            _participanteDAO.Deletar(idParticipante);
        }

        public void Atualizar(int idParticipante, ParticipanteModelView participanteModelView)
        {
            var _participanteDAO = new ParticipanteDAO();
            var participante = ObterPorId(idParticipante);
            participante = RetornaParticipante(participanteModelView, participante);
            _participanteDAO.Atualizar(participante);
        }

        public List<Participante> ObterTodos()
        {
            var _participanteDAO = new ParticipanteDAO();
            return _participanteDAO.ObterTodos();
        }
    }
}
