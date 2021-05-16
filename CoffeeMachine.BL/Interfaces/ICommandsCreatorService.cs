using CoffeeMachine.BL.DTO;
using CoffeeMachine.BL.DTOs;
using CoffeeMachine.Models;

namespace CoffeeMachine.BL.Interfaces
{
    public interface ICommandsCreatorService
    {
        CommandDTOOutput CreateCommand(CommandDTOInput command);
    }
}
