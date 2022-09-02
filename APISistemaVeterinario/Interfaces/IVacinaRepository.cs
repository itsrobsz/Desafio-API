using APISistemaVeterinario.Models;
using System.Collections.Generic;

namespace APISistemaVeterinario.Interfaces
{
    public interface IVacinaRepository
    {
        // Métodos CRUD
        // Create - Criar
        Vacina Insert(Vacina vacina);

        // Read - Listar
        ICollection<Vacina> GetAll();
        Vacina GetById(int id);

        // Update - Alterar
        Vacina Update(int id, Vacina vacina);

        // Delete - Deletar
        bool Delete(int id);
    }
}
