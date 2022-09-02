using System.ComponentModel.DataAnnotations;

namespace APISistemaVeterinario.Models
{
    public class Animal
    {   
        public int Id { get; set; }

        // [Required] = Valida que a propriedade tenha um valor

        [Required(ErrorMessage = "Informe o nome do animal.")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Informe a espécie.")]
        public string Especie { get; set; }


        [Required(ErrorMessage = "Informe a raça do animal ou se é SRD.")]
        public string Raca { get; set; }


        [Required(ErrorMessage = "Informe a data de nascimento.")]
        public string Nascimento { get; set; }


        [Required(ErrorMessage = "Informe a altura do animal(em cm).")]
        public decimal Altura { get; set; }


        [Required(ErrorMessage = "Informe o peso do animal(em kg).")]
        public decimal Peso { get; set; }


        [Required(ErrorMessage = "Informe se possui alergia(s) e qual(is) ou se não possui.")]
        public string Alergia { get; set; }



        [Required(ErrorMessage = "Informe o Id do cliente a qual o animal pertence.")]
        public int ClienteId { get; set; }

        // Faz a associação da chave estrangeira
        public Cliente Cliente { get; set; }
    }
}
