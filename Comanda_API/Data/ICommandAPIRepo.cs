using Comanda_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comanda_API.Data
{
   public interface ICommandAPIRepo
    {
        Task<IEnumerable<Command>> GetAll();
        Task<Command> GetById(int id);
        Task Create(Command command);
        Task Update(Command command);
        void Delete(Command command);
        public Task<bool> SaveChangesAsync();

    }
}
