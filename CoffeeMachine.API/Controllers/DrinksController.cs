using CoffeeMachine.BL.DTOs;
using CoffeeMachine.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeMachine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinksController : ControllerBase
    {
        private IDrinksGetterService _getDrinksService; 

        public DrinksController(IDrinksGetterService getDrinksService)
        {
            _getDrinksService = getDrinksService;
        }

        [HttpGet]
        public IEnumerable<DrinkDTO> GetDrinks()
        {
            return _getDrinksService.GetDrinks();
        }
    }
}
