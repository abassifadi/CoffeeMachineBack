using CoffeeMachine.BL.DTO;

namespace CoffeeMachine.BL.Interfaces
{
    public interface IMachineUserCreatorService
    {
        public void RegisterUser(MachineUserDTO input);
    }
}
