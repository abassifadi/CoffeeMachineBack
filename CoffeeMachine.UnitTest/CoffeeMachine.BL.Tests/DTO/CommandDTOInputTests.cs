using CoffeeMachine.BL.DTOs;
using CoffeeMachine.Models;
using NUnit.Framework;

namespace CoffeeMachine.UnitTests.CoffeeMachine.BL.Tests.DTO
{
    public class CommandDTOInputTests
    {
        [Test]
        public void Should_Correctly_Build_Command_Object_FromDTO()
        {
            var dtoInput = new CommandDTOInput() { DrinkName = "Coffee", MoneyInserted = 2 , SugarQuantity = 1, UseOwnMug = false };
            var drink = new Drink() { DrinkName = "Coffee", DrinkId = 1, ContainsSugar = true };
            var testUser = new MachineUser() { Identifier = "test.user", MachineUserId=1 };
            //
            var builtCommand = CommandDTOInput.BuildCommandFromDto(dtoInput, drink,testUser,CommandStatus.Received);
            //
            Assert.AreEqual(builtCommand.RequestedDrinkId, drink.DrinkId);
            Assert.AreEqual(builtCommand.UserId , testUser.MachineUserId);
            Assert.AreEqual(builtCommand.Status, CommandStatus.Received.ToString());
        }

    }
}
