using CoffeeMachine.BL.DTOs;
using CoffeeMachine.DAL.Interfaces;
using CoffeeMachine.Models;
using CoffeeMachine.Models.Constants;
using System;

namespace CoffeeMachine.BL.Implementations.CommandPipeline
{
    public class BuildCommandStepHandler : AbstractCommandStep
    {
        private IUnitOfWork _unitOfWork;
        private IGenericRepository<Drink> _drinksRepository;
        private IGenericRepository<MachineUser> _machineUserRepository;
        public BuildCommandStepHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _drinksRepository = _unitOfWork.GetRepository<Drink>();
            _machineUserRepository = _unitOfWork.GetRepository<MachineUser>();
        }

        public override void Handle(CommandPreparationContext context)
        {
            var commandDto = context.CommandDTO;
            var drink = _drinksRepository.GetFirstOrDefault(x => x.DrinkName == commandDto.DrinkName);
            context.Drink = drink;
            MachineUser user = null ;
            if (!string.IsNullOrWhiteSpace(commandDto.UserIdentifier))
            {
                user = _machineUserRepository.GetFirstOrDefault(u => u.Identifier == commandDto.UserIdentifier);
                context.MachineUser = user;
                if (user == default(MachineUser))
                {
                    throw new Exception(string.Format(ExceptionMessages.UserNotFound, commandDto.UserIdentifier));
                }
            }
            
            if (drink == default(Drink))
            {
                throw new Exception(ExceptionMessages.DrinkNotFound);
            }
            if (commandDto.MoneyInserted < drink.Price)
            {
                throw new Exception(ExceptionMessages.MonyInsertedIsNotSufficient);
            }
            context.Command = CommandDTOInput.BuildCommandFromDto(commandDto,drink,user,CommandStatus.Received);

            if (this.NextHandler != null)
            {
                NextHandler.Handle(context);
            }

        }
    }

}