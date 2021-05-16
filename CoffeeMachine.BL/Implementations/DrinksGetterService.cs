using CoffeeMachine.BL.DTOs;
using CoffeeMachine.BL.Interfaces;
using CoffeeMachine.DAL.Interfaces;
using CoffeeMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeMachine.BL.Implementations
{
    public class DrinksGetterService : IDrinksGetterService
    {
        IUnitOfWork _uof;
        IGenericRepository<Drink> _drinksRepository;

        public DrinksGetterService(IUnitOfWork unitOfWork)
        {
            _uof = unitOfWork;
            _drinksRepository = _uof.GetRepository<Drink>();
        }

        public IEnumerable<DrinkDTO> GetDrinks()
        {
            return _drinksRepository.GetAll().Select(d => DrinkDTO.FromDrink(d));
        }
    }
}
