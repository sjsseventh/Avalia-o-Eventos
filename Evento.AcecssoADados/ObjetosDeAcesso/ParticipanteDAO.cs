using Evento.AcecssoADados;
using Evento.AcessoADados.Modelos;
using Evento.AcessoADados.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evento.AcessoADados.ObjetosDeAcesso
{
    public class ParticipanteDAO
    {
        public void Inserir(Participante participante)
        {
            using (var _bancoDeDados = new BancoDeDados())
            {
                _bancoDeDados.Participantes.Add(participante);
                _bancoDeDados.SaveChanges();
            }
        }

        public Participante ObterPorId(int idParticipante)
        {
            using (var _bancoDeDados = new BancoDeDados())
            {
                return _bancoDeDados.Participantes.Find(idParticipante);
            }
        }

        public void Deletar(int idParticipante)
        {
            using (var _bancoDeDados = new BancoDeDados())
            {
                var participante = ObterPorId(idParticipante);
                _bancoDeDados.Participantes.Remove(participante);
                _bancoDeDados.SaveChanges();
            }
        }

        public void Atualizar(Participante participante)
        {
            using (var _bancoDeDados = new BancoDeDados())
            {
                _bancoDeDados.Participantes.Update(participante);
                _bancoDeDados.SaveChanges();
            }
        }

        public List<Participante> ObterTodos()
        {
            using (var _bancoDeDados = new BancoDeDados())
            {
                return _bancoDeDados.Participantes.ToList();
            }
        }
    }
}
