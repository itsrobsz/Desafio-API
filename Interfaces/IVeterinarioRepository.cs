using APISistemaVeterinario.Models;
using System.Collections.Generic;

namespace APISistemaVeterinario.Interfaces
{
    public interface IVeterinarioRepository
    {
        // Métodos CRUD
        // Create
        Veterinario Insert(Veterinario veterinario);

        // Read
        ICollection<Veterinario> GetAll();
        Veterinario GetById(int id);

        // Update
        Veterinario Update(int id, Veterinario veterinario);

        // Delete
        bool Delete(int id);
    }
}
