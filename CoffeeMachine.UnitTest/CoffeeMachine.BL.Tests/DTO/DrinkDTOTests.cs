using CoffeeMachine.BL.DTOs;
using CoffeeMachine.Models;
using NUnit.Framework;

namespace CoffeeMachine.UnitTests.CoffeeMachine.BL.Tests.DTO
{
    public class DrinkDTOTests
    {
        [Test]
        public void Should_Correctly_Convert_DTO_To_Drink()
        {
            //arrange
            var dto = new DrinkDTO() { DrinkName = "TestDrink", ContainsSugar = true, Price = 20f };
            //act
            var drink = DrinkDTO.ToDrink(dto);
            //assert
            Assert.AreEqual(drink.DrinkName, "TestDrink");
            Assert.AreEqual(drink.ContainsSugar, true);
            Assert.AreEqual(drink.Price, 20f);
        }

        [Test]
        public void Should_Correctly_Convert_Drink_To_DTO()
        {
            //arrange
            var drink = new Drink() { DrinkName = "TestDrink", ContainsSugar = true, Price = 20f };
            //act
            var dto = DrinkDTO.FromDrink(drink);
            //assert
            Assert.AreEqual(dto.DrinkName, "TestDrink");
            Assert.AreEqual(dto.ContainsSugar, true);
            Assert.AreEqual(dto.Price, 20f);
        }
    }
}
