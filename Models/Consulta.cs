using System;
using System.ComponentModel.DataAnnotations;

namespace APISistemaVeterinario.Models
{
    public class Consulta
    {
        // [Required] = Valida que a propriedade tenha um valor
        public int Id { get; set; }

        public DateTime DataHora { get; set; }


        [Required(ErrorMessage = "Informe o valor da consulta.")]
        public float Valor { get; set; }


        [Required(ErrorMessage = "Informe o Id do veterinário.")]
        public int VeterinarioId { get; set; }
        public Veterinario Veterinario { get; set; }


        [Required(ErrorMessage = "Informe o Id do animal.")]
        public int AnimalId { get; set; }

        // Faz a associação da chave estrangeira
        public Animal Animal { get; set; }
    }
}
