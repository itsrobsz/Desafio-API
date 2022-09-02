using APISistemaVeterinario.Models;
using System.Collections.Generic;

namespace APISistemaVeterinario.Interfaces
{
    public interface IVeterinarioEmergenciaRepository
    {
        // Métodos CRUD
        // Create - Criar
        VeterinarioEmergencia Insert(VeterinarioEmergencia veterinarioEmergencia);

        // Read - Listar
        ICollection<VeterinarioEmergencia> GetAll();
        VeterinarioEmergencia GetById(int id);

        // Update - Alterar
        VeterinarioEmergencia Update(int id, VeterinarioEmergencia veterinarioEmergencia);

        // Delete - Deletar
        bool Delete(int id);
    }
}
