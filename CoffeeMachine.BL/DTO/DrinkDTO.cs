using CoffeeMachine.Models;

namespace CoffeeMachine.BL.DTOs
{
    public class DrinkDTO
    {
        public string DrinkName { get; set; }
        public bool ContainsSugar { get; set; }
        public float Price { get; set; }

        public static DrinkDTO FromDrink(Drink p)
        {
            return new DrinkDTO() { DrinkName = p.DrinkName, Price = p.Price, ContainsSugar = p.ContainsSugar };
        }

        public static Drink ToDrink(DrinkDTO dto)
        {
            return new Drink() { DrinkName = dto.DrinkName, Price = dto.Price, ContainsSugar = dto.ContainsSugar };
        }

    }
}
