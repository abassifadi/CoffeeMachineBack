using CoffeeMachine.BL.DTOs;
using CoffeeMachine.Models;

namespace CoffeeMachine.BL.Implementations.CommandPipeline
{
    public class CommandPreparationContext
    {
        public CommandDTOInput CommandDTO { get; set; }
        public Command Command { get; set; }
        public Drink Drink { get; set; }
        public MachineUser MachineUser { get; set; }
    }
}
