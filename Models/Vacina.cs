using System;
using System.ComponentModel.DataAnnotations;

namespace APISistemaVeterinario.Models
{
    public class Vacina
    {
        public int Id { get; set; }

        // [Required] = Valida que a propriedade tenha um valor
        [Required(ErrorMessage = "Informe o nome da vacina.")]
        public string Nome { get; set; }

        public DateTime Aplicacao { get; set; }


        [Required(ErrorMessage = "Informe a dose.")]
        public string Dose { get; set; }

        public DateTime Retorno { get; set; }


        [Required(ErrorMessage = "Informe o Id do animal.")]
        public int AnimalId { get; set; }

        // Faz a associação da chave estrangeira
        public Animal Animal { get; set; }
    }
}
