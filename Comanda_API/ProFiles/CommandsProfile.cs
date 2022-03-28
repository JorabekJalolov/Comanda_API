using AutoMapper;
using Comanda_API.Dtos;
using Comanda_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comanda_API.ProFiles
{
    public class CommandsProfile:Profile
    {
        public CommandsProfile()
        {
            CreateMap<CommandCreatedDto, Command>();
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandUpdatedDto, Command>();
        }
    }
}
