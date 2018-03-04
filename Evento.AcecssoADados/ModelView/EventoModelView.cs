using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.AcecssoADados.ModelView
{
    public class EventoModelView
    {
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public string Local { get; set; }
        public int HoraInicio { get; set; }
        public int HoraFim { get; set; }
        public bool OpenBar { get; set; }
        public int QtdAmbientes { get; set; }
        public int NMaximoIngressos { get; set; }
    }
}
