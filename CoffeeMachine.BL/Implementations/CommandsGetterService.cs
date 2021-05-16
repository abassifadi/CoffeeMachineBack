using CoffeeMachine.BL.DTO;
using CoffeeMachine.BL.Interfaces;
using CoffeeMachine.DAL.Interfaces;
using CoffeeMachine.Models;
using CoffeeMachine.Models.Constants;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeMachine.BL.Implementations
{
    class CommandsGetterService : ICommandsGetterService
    {
        private IUnitOfWork _unitOfWork;
        public CommandsGetterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<CommandDTOOutput> GetCommandsForUser(string userIdentifier)
        {
            var user = _unitOfWork.GetRepository<MachineUser>().GetFirstOrDefault( predicate : x => x.Identifier == userIdentifier, 
                include : u => u.Include(u => u.Commands).ThenInclude(c => c.RequestedDrink));

            if (user == null)
                throw new System.Exception(string.Format(ExceptionMessages.UserNotFound, userIdentifier));
            return user.Commands.ToList().Select( c => CommandDTOOutput.FromCommand(c));
        }
    }
}
