using AutoMapper;
using Comanda_API.Data;
using Comanda_API.Dtos;
using Comanda_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comanda_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandAPIRepo repo;
        private readonly IMapper mapper;

        public CommandsController(ICommandAPIRepo _repo, IMapper mapper)
        {
            repo = _repo;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CommandCreatedDto command)
        {
            var commandModel = mapper.Map<Command>(command);
            await repo.Create(commandModel);
            await repo.SaveChangesAsync();
            var commandReadDto = mapper.Map<CommandReadDto>(commandModel);
            return Created("", commandModel);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var commands = await repo.GetAll();
            return Ok(mapper.Map<IEnumerable<CommandReadDto>>(commands));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var command = await repo.GetById(id);
            if (command == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<CommandReadDto>(command));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var commandModelFromRepo = await repo.GetById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            repo.Delete(commandModelFromRepo);
            await repo.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,CommandUpdatedDto updatedDto)
        {
            var commandModelFromRepo = await repo.GetById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            mapper.Map(updatedDto, commandModelFromRepo);
            await   repo.Update(commandModelFromRepo);
            await repo.SaveChangesAsync();
            return NoContent();
        }
    }
}
