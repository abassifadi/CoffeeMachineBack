using CoffeeMachine.BL.Implementations;
using CoffeeMachine.BL.Interfaces;
using CoffeeMachine.DAL.Implementations;
using CoffeeMachine.DAL.Interfaces;
using CoffeeMachine.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeMachine.UnitTests.CoffeeMachine.BL.Tests
{
    public class MachineUserGetterServiceTests
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;

        [SetUp]
        public void Setup()
        {
            _mockUnitOfWork = MachineUserTestsUtils.SetupMachineUserMocks();
        }

        [Test]
        public void Should_Return_True_If_User_Identifier_Exists()
        {
            //arrange 
            var machineUserGetterService = new MachineUserGetterService(_mockUnitOfWork.Object);
            //act 
            bool exists = machineUserGetterService.IsUserIdentifierExisting("test1.identifier");
            //assert
            Assert.IsTrue(exists);
        }

        [Test]
        public void Should_Return_False_If_User_Identifier_Does_Not_Exists()
        {
            //arrange 
            var machineUserGetterService = new MachineUserGetterService(_mockUnitOfWork.Object);
            //act 
            bool exists = machineUserGetterService.IsUserIdentifierExisting("unexsting.identifier");
            //assert
            Assert.IsFalse(exists);
        }


    }
}
