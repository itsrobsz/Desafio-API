using System.ComponentModel.DataAnnotations;

namespace APISistemaVeterinario.Models
{
    public class Veterinario
    {
        public int Id { get; set; }

        // [Required] = Valida que a propriedade tenha um valor
        [Required(ErrorMessage = "Informe o CRMV do veterinário.")]
        public int CRMV { get; set; }

        [Required(ErrorMessage = "Informe o nome do veterinário.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o endereço do veterinário.")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Informe o telefone do veterinário.")]
        public int Telefone { get; set; }

        [Required(ErrorMessage = "Informe a especialidade do veterinário.")]
        public string Especialidade { get; set; }

        [Required(ErrorMessage = "Informe o turno do veterinário.")]
        public string Turno { get; set; }
    }
}
