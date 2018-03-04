using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Evento.AcessoADados.Modelos;

namespace Evento.AcessoADados.Modelos
{
    public class Participante
    {
        [Key]
        public int IdParticipante { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "O tamanho mínimo do Nome são 1 caracteres.")]
        [MaxLength(100, ErrorMessage = "O tamanho máximo do Nome são 100 caracteres.")]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }

        public int IdEvento { get; set; }

        public Event Evento{ get; set; }
    }
}
