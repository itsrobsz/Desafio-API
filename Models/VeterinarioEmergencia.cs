using System.ComponentModel.DataAnnotations;

namespace APISistemaVeterinario.Models
{
    public class VeterinarioEmergencia
    {
        public int Id { get; set; }

        // [Required] = Valida que a propriedade tenha um valor
        [Required(ErrorMessage = "Informe o Id do veterinário.")]
        public int VeterinarioId { get; set; }

        // Faz a associação da chave estrangeira e seu conteúdo
        public Veterinario Veterinario { get; set; }


        [Required(ErrorMessage = "Informe o Id da emergência.")]
        public int EmergenciaId { get; set; }

        // Faz a associação da chave estrangeira e seu conteúdo
        public Emergencia Emergencia { get; set; }

    }
}
