using CoffeeMachine.BL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine.BL.Interfaces
{
    public interface ICommandsGetterService
    {
        public IEnumerable<CommandDTOOutput> GetCommandsForUser(string userIdentifier);
    }
}
