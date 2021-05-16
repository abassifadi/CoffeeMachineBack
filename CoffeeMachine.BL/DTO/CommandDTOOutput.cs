using CoffeeMachine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine.BL.DTO
{
    public class CommandDTOOutput 
    {
        public string UserIdentifier { get; set; }
        public string DrinkName { get; set; }
        public string CommandIdentifier { get; set; }
        public int? SugarQuantity { get; set; }
        public bool? UseOwnMug { get; set; } = false;
        public float MoneyInserted { get; set; }
        public float MoneyReturned { get; set; }

        public static CommandDTOOutput FromCommand(Command cmd, Drink drink = null ,MachineUser user= null)
        {
            return new CommandDTOOutput()
            {
                UserIdentifier = cmd.User?.Identifier ?? user?.Identifier,
                DrinkName = cmd.RequestedDrink?.DrinkName ?? drink?.DrinkName,
                CommandIdentifier = cmd.CommandIdentifier,
                SugarQuantity = cmd.SugarQuantity,
                UseOwnMug = cmd.UseOwnMug,
                MoneyInserted = cmd.MoneyInserted,
                MoneyReturned = cmd.MoneyReturned
            };
        }
    }
}
