using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeMachine.Models
{
    public class Command
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CommandId { get; set; }
        public string CommandIdentifier { get; set; }
        public int? SugarQuantity { get; set; }
        public bool? UseOwnMug { get; set; }
        public float MoneyInserted { get; set; }
        public float MoneyReturned { get; set; }
        public string Status { get; set; }

        [ForeignKey("Drink")]
        public int RequestedDrinkId { get; set; }
        public Drink RequestedDrink { get; set; }
        public DateTime CommandTime { get; set; }

        [ForeignKey("MachineUser")]
        public int? UserId { get; set; }
        public MachineUser? User { get; set; }
    }
}
