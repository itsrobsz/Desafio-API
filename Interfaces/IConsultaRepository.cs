using APISistemaVeterinario.Models;
using System.Collections.Generic;

namespace APISistemaVeterinario.Interfaces
{
    public interface IConsultaRepository
    {
        // Métodos CRUD
        // Create
        Consulta Insert(Consulta consulta);

        // Read
        ICollection<Consulta> GetAll();
        Consulta GetById(int id);

        // Update
       Consulta Update(int id, Consulta consulta);

        // Delete
        bool Delete(int id);
    }
}
