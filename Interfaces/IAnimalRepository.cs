using APISistemaVeterinario.Models;
using System.Collections.Generic;

namespace APISistemaVeterinario.Interfaces
{
    public interface IAnimalRepository 
    {
        // Métodos CRUD
        // Create
        Animal Insert(Animal animal);

        // Read
        ICollection<Animal> GetAll();
        Animal GetById(int id);

        // Update
        Animal Update(int id, Animal animal);

        // Delete
        bool Delete(int id);
    }
}
