using CoffeeMachine.BL.Interfaces;
using CoffeeMachine.DAL.Interfaces;
using CoffeeMachine.Models;

namespace CoffeeMachine.BL.Implementations
{
    public class MachineUserGetterService : IMachineUserGetterService
    {
        private IUnitOfWork _unitOfWork;
        public MachineUserGetterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool IsUserIdentifierExisting(string identifier)
        {
            return _unitOfWork.GetRepository<MachineUser>().Exists(u => u.Identifier == identifier);
        }
    }
}
