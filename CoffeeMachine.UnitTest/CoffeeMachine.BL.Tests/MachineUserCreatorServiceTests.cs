using CoffeeMachine.BL.DTO;
using CoffeeMachine.BL.Implementations;
using CoffeeMachine.DAL.Interfaces;
using Moq;
using NUnit.Framework;
using System;

namespace CoffeeMachine.UnitTests.CoffeeMachine.BL.Tests
{
    public class MachineUserCreatorServiceTests
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;

        [SetUp]
        public void Setup()
        {
            _mockUnitOfWork = MachineUserTestsUtils.SetupMachineUserMocks();
        }

        [Test]
        public void Should_Not_Throw_An_Exception_If_User_Does_Not_Exist()
        {
            var machineUserGetterService = new MachineUserCreatorService(_mockUnitOfWork.Object);
            Assert.DoesNotThrow(() => machineUserGetterService.RegisterUser(new MachineUserDTO() { Identifier = "new.identifier" }));
        }

        [Test]
        public void Should_Throw_An_Exception_If_User_Does_Exist()
        {
            //arrange 
            var machineUserGetterService = new MachineUserCreatorService(_mockUnitOfWork.Object);
            Assert.Throws<Exception>(() => machineUserGetterService.RegisterUser(new MachineUserDTO() { Identifier = "test1.identifier" }));
        }
    }
}
