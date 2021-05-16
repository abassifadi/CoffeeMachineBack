namespace CoffeeMachine.BL.Implementations.CommandPipeline
{
    public abstract class AbstractCommandStep
    {
        protected AbstractCommandStep NextHandler;


        public void SetNextHandler(AbstractCommandStep next)
        {
            this.NextHandler = next; 
        }

        public abstract void Handle(CommandPreparationContext context);


    }
}
