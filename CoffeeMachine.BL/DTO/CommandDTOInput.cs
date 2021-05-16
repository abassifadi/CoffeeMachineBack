using CoffeeMachine.BL.DTO;
using CoffeeMachine.DAL.Interfaces;
using CoffeeMachine.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CoffeeMachine.BL.DTOs
{
    public class CommandDTOInput
    {
        [Required]
        public string DrinkName { get; set; }
        public string UserIdentifier { get; set; }

        public int? SugarQuantity { get; set; }
        public bool? UseOwnMug { get; set; } = false;
        [Required]
        public float MoneyInserted { get; set; }





        public static Command BuildCommandFromDto( CommandDTOInput dto ,Drink requestedDrink , MachineUser user, CommandStatus status)
        {
            return new Command()
            {
                CommandIdentifier = Guid.NewGuid().ToString(),
                SugarQuantity = dto.SugarQuantity,
                MoneyInserted = dto.MoneyInserted,
                UseOwnMug = dto.UseOwnMug,
                Status = status.ToString(),
                CommandTime = DateTime.Now,
                RequestedDrinkId = requestedDrink.DrinkId,
                UserId = user?.MachineUserId 

            };

        }

    }
}
