using Comanda_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comanda_API.Data
{
    public class SQLCommand : ICommandAPIRepo
    {
        private readonly CommandContext repository;

        public SQLCommand(CommandContext _repository)
        {
            repository = _repository;
        }
        public async Task Create(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            await repository.AddAsync(command);
        }

      
        public void Delete(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            repository.Commands.Remove(command);
        }

        public async Task<IEnumerable<Command>> GetAll()
        {
           return await repository.Commands.ToListAsync();
        }

        public async Task<Command> GetById(int id)
        {
            return await repository.Commands.FirstOrDefaultAsync(a => a.Id.Equals(id));
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await repository.SaveChangesAsync() >= 0;
        }

        public async Task Update(Command command)
        {
           ////
        }
    }
}
