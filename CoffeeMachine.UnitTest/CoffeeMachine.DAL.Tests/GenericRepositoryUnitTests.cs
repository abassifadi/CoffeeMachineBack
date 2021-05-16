using CoffeeMachine.DAL.Implementations;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CoffeeMachine.UnitTest.CoffeeMachine.DAL.Tests
{
    public class GenericRepositoryUnitTests
    {
        Mock<CoffeeMachineDbContext> _mockDbContext;
        private IQueryable<TestType> _elementsList;
        private Mock<DbSet<TestType>> _mockSet;

        [SetUp]
        public void Setup()
        {
            
            var el1 =  new TestType() { Id = "el1" };
            var el2 = new TestType() { Id = "el2" };
            _elementsList = (new List<TestType> { el1,el2 } ).AsQueryable();
            _mockSet = new Mock<DbSet<TestType>>();
            _mockSet.As<IQueryable<TestType>>().Setup(m => m.Provider).Returns(_elementsList.Provider);
            _mockSet.As<IQueryable<TestType>>().Setup(m => m.Expression).Returns(_elementsList.Expression);
            _mockSet.As<IQueryable<TestType>>().Setup(m => m.ElementType).Returns(_elementsList.ElementType);
            _mockSet.As<IQueryable<TestType>>().Setup(m => m.GetEnumerator()).Returns(_elementsList.GetEnumerator());

            _mockDbContext = new Mock<CoffeeMachineDbContext>();
            _mockDbContext.Setup(m => m.Set<TestType>()).Returns(_mockSet.Object);
        }


        [Test]
        public void Should_Correctly_Return_Count_Of_Elements()
        {
            //arrange
            var repository = new GenericRepository<TestType>(_mockDbContext.Object);
            //act
            var all = repository.GetAll().ToList();
            //assert
            Assert.AreEqual(2,all.Count);
        }

        [Test]
        public void Should_Return_True_If_Element_Exist_In_The_Set()
        {
            //arrange
            var repository = new GenericRepository<TestType>(_mockDbContext.Object);
            //act
            var elementExisting = repository.Exists(e => e.Id == "el1");
            //assert
            Assert.IsTrue(elementExisting);
        }

        [Test]
        public void Should_Return_False_If_Element_Exist_In_The_Set()
        {   
            //arrange
            var repository = new GenericRepository<TestType>(_mockDbContext.Object);
            //act
            var elementExisting = repository.Exists(e => e.Id == "el100");
            //assert
            Assert.IsFalse(elementExisting);
        }

        [Test]
        public void Should_Return_The_Correct_Element_Within_Set()
        {
            //arrange
            var repository = new GenericRepository<TestType>(_mockDbContext.Object);
            //act
            var el = repository.GetFirstOrDefault(e => e.Id == "el1");
            //assert
            Assert.AreEqual(el.Id, "el1");

        }

        [Test]
        public void Should_Return_Null_If_Element_Not_Existing_Within_Set()
        {
            //arrange
            var repository = new GenericRepository<TestType>(_mockDbContext.Object);
            //act
            var el = repository.GetFirstOrDefault(e => e.Id == "el100");
            //assert
            Assert.IsNull(el);
        }


        public class TestType
        {
            [Key]
            public string Id; 
        }
    }
}
