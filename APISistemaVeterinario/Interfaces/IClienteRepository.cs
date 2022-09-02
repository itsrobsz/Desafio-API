using APISistemaVeterinario.Models;
using System.Collections.Generic;

namespace APISistemaVeterinario.Interfaces
{
    public interface IClienteRepository
    {
        // Métodos CRUD
        // Create - Criar
        Cliente Insert(Cliente cliente);

        // Read - Listar
        ICollection<Cliente> GetAll();
        Cliente GetById(int id);

        // Update - Alterar
        Cliente Update(int id, Cliente cliente);

        // Delete - Deletar
        bool Delete(int id);
    }
}

