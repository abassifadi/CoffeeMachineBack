using CoffeeMachine.BL.DTO;
using CoffeeMachine.BL.Interfaces;
using CoffeeMachine.DAL.Interfaces;
using CoffeeMachine.Models;
using CoffeeMachine.Models.Constants;
using System;
namespace CoffeeMachine.BL.Implementations
{
    public class MachineUserCreatorService : IMachineUserCreatorService
    {
        private IUnitOfWork _unitOfWork;

        public MachineUserCreatorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void RegisterUser(MachineUserDTO input)
        {
            var mu_repo = _unitOfWork.GetRepository<MachineUser>();
            if(!mu_repo.Exists(m => m.Identifier == input.Identifier))
            {
                mu_repo.Add(MachineUserDTO.CreateRecord(input));
                _unitOfWork.Save();
            }
            else
            {
                throw new Exception(ExceptionMessages.UserAlreadyExists);
            }
        }
    }
}
