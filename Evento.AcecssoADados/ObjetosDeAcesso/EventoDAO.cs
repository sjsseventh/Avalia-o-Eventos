using Evento.AcecssoADados;
using Evento.AcessoADados.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evento.AcessoADados.ObjetosDeAcesso
{
    public class EventoDAO
    {
        public void Inserir(Event evento)
        {
            using (var _bancoDeDados = new BancoDeDados())
            {
                _bancoDeDados.Eventos.Add(evento);
                _bancoDeDados.SaveChanges();
            }
        }

        public Event ObterPorId(int id)
        {
            using (var _bancoDeDados = new BancoDeDados())
            {
                return _bancoDeDados.Eventos.Find(id);
            }
        }

        public void Deletar(int id)
        {
            using (var _bancoDeDados = new BancoDeDados())
            {
                var evento = ObterPorId(id);
                _bancoDeDados.Eventos.Remove(evento);
                _bancoDeDados.SaveChanges();
            }
        }

        public void Atualizar(Event evento)
        {
            using (var _bancoDeDados = new BancoDeDados())
            {
                _bancoDeDados.Eventos.Update(evento);
                _bancoDeDados.SaveChanges();
            }
        }

        public List<Event> ObterTodos()
        {
            using (var _bancoDeDados = new BancoDeDados())
            {
                return _bancoDeDados.Eventos.ToList();
            }
        }
    }
}
