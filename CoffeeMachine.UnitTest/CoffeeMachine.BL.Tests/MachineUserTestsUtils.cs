using CoffeeMachine.DAL.Implementations;
using CoffeeMachine.DAL.Interfaces;
using CoffeeMachine.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeMachine.UnitTests.CoffeeMachine.BL.Tests
{
    public static class MachineUserTestsUtils
    {
        public static Mock<IUnitOfWork> SetupMachineUserMocks()
        {
            var user1 = new MachineUser() { Identifier = "test1.identifier" };
            var elementsList = (new List<MachineUser> { user1 }).AsQueryable();
            var mockSet = new Mock<DbSet<MachineUser>>();
            mockSet.As<IQueryable<MachineUser>>().Setup(m => m.Provider).Returns(elementsList.Provider);
            mockSet.As<IQueryable<MachineUser>>().Setup(m => m.Expression).Returns(elementsList.Expression);
            mockSet.As<IQueryable<MachineUser>>().Setup(m => m.ElementType).Returns(elementsList.ElementType);
            mockSet.As<IQueryable<MachineUser>>().Setup(m => m.GetEnumerator()).Returns(elementsList.GetEnumerator());

            var mockDbContext = new Mock<CoffeeMachineDbContext>();
            mockDbContext.Setup(m => m.Set<MachineUser>()).Returns(mockSet.Object);
            var repository = new Mock<GenericRepository<MachineUser>>(mockDbContext.Object);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.GetRepository<MachineUser>()).Returns(repository.Object);

            return mockUnitOfWork;
        }
    }
}
