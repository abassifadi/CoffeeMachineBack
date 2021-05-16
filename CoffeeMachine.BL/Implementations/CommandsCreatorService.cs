using CoffeeMachine.BL.DTO;
using CoffeeMachine.BL.DTOs;
using CoffeeMachine.BL.Implementations.CommandPipeline;
using CoffeeMachine.BL.Interfaces;
using CoffeeMachine.DAL.Interfaces;
using CoffeeMachine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine.BL.Implementations
{
    class CommandsCreatorService : ICommandsCreatorService
    {
        private BuildCommandStepHandler _buildCommandFromDto;
        private RegisterCommandStepHandler _registerCommandHandler;
        private CommandPreparationContext _context; 
        public CommandsCreatorService (IUnitOfWork unitOfWork)
        {
            _buildCommandFromDto = new BuildCommandStepHandler(unitOfWork);
            _registerCommandHandler = new RegisterCommandStepHandler(unitOfWork);
            _buildCommandFromDto.SetNextHandler(_registerCommandHandler);
        }
        public CommandDTOOutput CreateCommand(CommandDTOInput commandDto)
        {
            _context = new CommandPreparationContext() { CommandDTO = commandDto  };
            _buildCommandFromDto.Handle(_context);
            return CommandDTOOutput.FromCommand(_context.Command,_context.Drink,_context.MachineUser);
        }

      
    }
}
