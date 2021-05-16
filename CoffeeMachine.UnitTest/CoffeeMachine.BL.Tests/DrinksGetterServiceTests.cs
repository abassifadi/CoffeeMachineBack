using CoffeeMachine.BL.Implementations;
using CoffeeMachine.DAL.Implementations;
using CoffeeMachine.DAL.Interfaces;
using CoffeeMachine.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeMachine.UnitTests.CoffeeMachine.BL.Tests
{
    public class DrinksGetterServiceTests
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;

        [SetUp]
        public void SetupMachineUserMocks()
        {
            var drink1 = new Drink() { DrinkName="Coffee", DrinkId=1,Price=1 };
            var drink2 = new Drink() { DrinkName = "Coffee", DrinkId = 1, Price = 1 };
            var elementsList = (new List<Drink> { drink1,drink2 }).AsQueryable();
            var mockSet = new Mock<DbSet<Drink>>();
            mockSet.As<IQueryable<Drink>>().Setup(m => m.Provider).Returns(elementsList.Provider);
            mockSet.As<IQueryable<Drink>>().Setup(m => m.Expression).Returns(elementsList.Expression);
            mockSet.As<IQueryable<Drink>>().Setup(m => m.ElementType).Returns(elementsList.ElementType);
            mockSet.As<IQueryable<Drink>>().Setup(m => m.GetEnumerator()).Returns(elementsList.GetEnumerator());

            var mockDbContext = new Mock<CoffeeMachineDbContext>();
            mockDbContext.Setup(m => m.Set<Drink>()).Returns(mockSet.Object);
            var repository = new Mock<GenericRepository<Drink>>(mockDbContext.Object);
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockUnitOfWork.Setup(uow => uow.GetRepository<Drink>()).Returns(repository.Object);
        }


        [Test]
        public void Should_Return_Correctly_The_List_Of_Users()
        {

            //arrange 
            var drinkGetterService = new DrinksGetterService(_mockUnitOfWork.Object);
            //act 
            var drinks = drinkGetterService.GetDrinks();
            //assert
            Assert.AreEqual(drinks.Count(),2);
        }
    }
}
