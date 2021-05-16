using CoffeeMachine.DAL.Interfaces;
using CoffeeMachine.Models;

namespace CoffeeMachine.BL.Implementations.CommandPipeline
{
    class RegisterCommandStepHandler : AbstractCommandStep
    {
        private IUnitOfWork _uow;
        private IGenericRepository<Command> _commandRepository;

        public RegisterCommandStepHandler(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
            _commandRepository = _uow.GetRepository<Command>();
        }

        public override void Handle(CommandPreparationContext context)
        {
            context.Command.Status = CommandStatus.Ready.ToString();
            context.Command.MoneyReturned = context.Command.MoneyInserted - context.Drink.Price;
            _commandRepository.Add(context.Command);
            _uow.Save();

            if (NextHandler != null)
            {
                NextHandler.Handle(context);
            }
        }
    }
}
