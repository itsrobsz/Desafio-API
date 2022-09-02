using System.ComponentModel.DataAnnotations;

namespace APISistemaVeterinario.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        // [Required] = Valida que a propriedade tenha um valor
        [Required(ErrorMessage = "Informe o nome do cliente.")]
        // Define um tamanho máximo a ser digitado
        [MaxLength(200)]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Informe um endereço.")]
        // Define um tamanho máximo a ser digitado
        [MaxLength(200)]
        public string Endereco { get; set; }


        [Required(ErrorMessage = "Informe um email.")]
        // Define um tamanho máximo a ser digitado
        [MaxLength(160)]
        // Valida o formato do email 
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Favor informar um email válido.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Informe um número de telefone para contato.")]
        public int Telefone { get; set; }


        [Required(ErrorMessage = "Informe o CPF.")]
        // Define um tamanho mínimo a ser digitado
        [MinLength(11)]
        // Define um tamanho máximo a ser digitado
        [MaxLength(11)]
        public string CPF { get; set; }

        public string Imagem { get; set; }
    }
}
