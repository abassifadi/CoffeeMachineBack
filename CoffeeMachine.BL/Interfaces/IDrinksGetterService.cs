using CoffeeMachine.BL.DTOs;
using System.Collections.Generic;

namespace CoffeeMachine.BL.Interfaces
{
    public interface IDrinksGetterService
    {
        public IEnumerable<DrinkDTO> GetDrinks();
    }
}
