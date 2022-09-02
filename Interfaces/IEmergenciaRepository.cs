using APISistemaVeterinario.Models;
using System.Collections.Generic;

namespace APISistemaVeterinario.Interfaces
{
    public interface IEmergenciaRepository
    {
        // Métodos CRUD
        // Create
        Emergencia Insert(Emergencia emergencia);

        // Read
        ICollection<Emergencia> GetAll();
        Emergencia GetById(int id);

        // Update
        Emergencia Update(int id, Emergencia emergencia);

        // Delete
        bool Delete(int id);
    }
}
