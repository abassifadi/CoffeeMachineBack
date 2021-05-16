using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeMachine.Models
{
    public class Drink
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DrinkId { get; set; }
        public string DrinkName { get; set; }
        public bool ContainsSugar { get; set; }
        public float Price { get; set; }
    }
}
