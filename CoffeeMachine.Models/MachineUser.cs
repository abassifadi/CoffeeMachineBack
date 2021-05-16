using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoffeeMachine.Models
{
    public class MachineUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MachineUserId { get; set; }
        public string Identifier { get; set; }
        public DateTime AccountCreationDate { get; set; }
        public List<Command> Commands { get; set; }
    }
}
