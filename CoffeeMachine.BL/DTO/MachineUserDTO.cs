using CoffeeMachine.Models;
using System;

namespace CoffeeMachine.BL.DTO
{
    public class MachineUserDTO
    {
        public string Identifier { get; set; }

        public static MachineUserDTO FromMachineUser(MachineUser user)
        {
            return new MachineUserDTO() { Identifier = user.Identifier };
        }

        public static MachineUser CreateRecord(MachineUserDTO input)
        {
            return new MachineUser()
            {
                Identifier = input.Identifier,
                AccountCreationDate = DateTime.Now
            };
        }
    }
}
