using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Evento.AcessoADados.Modelos
{
    public class Event
    {
        [Key]
        public int IdEvento { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "O tamanho mínimo do Nome são 1 caracteres.")]
        [MaxLength(100, ErrorMessage = "O tamanho máximo do Nome são 100 caracteres.")]
        public string Nome { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "O tamanho mínimo do Local são 1 caracteres.")]
        [MaxLength(100, ErrorMessage = "O tamanho máximo do Local são 100 caracteres.")]
        public string Local { get; set; }

        [Required]
        [Range(0, 24,ErrorMessage = "O valor da hora início deve estar entre 0 e 24")]
        public int HoraInicio { get; set; }

        [Required]
        [Range(0, 24, ErrorMessage = "O valor da hora fim deve estar entre 0 e 24")]
        public int HoraFim { get; set; }

        [Required]
        public bool OpenBar { get; set; }

        [Required]
        public int QtdAmbientes { get; set; }

        [Required]
        public string FaixaEtaria { get; set; }

        [Required]
        public int NMaximoIngressos { get; set; }

        [DefaultValue(true)]
        public int NIngressosVendidos { get; set; }

        public List<Participante> Participantes { get; set; }

    }
}
