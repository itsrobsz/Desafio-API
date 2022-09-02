using System;
using System.ComponentModel.DataAnnotations;

namespace APISistemaVeterinario.Models
{
    public class Emergencia
    {
        public int Id { get; set; }

        // [Required] = Valida que a propriedade tenha um valor
        [Required(ErrorMessage = "Informe uma data")]
        public DateTime DataHora { get; set; }

        [Required(ErrorMessage = "Informe o tipo de emergência.")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "Informe a classificação de gravidade. Leve, moderada ou grave.")]
        public string Gravidade { get; set; }
    }
}
