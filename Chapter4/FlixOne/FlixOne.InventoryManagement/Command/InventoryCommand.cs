using FlixOne.InventoryManagement.UserInterface;

namespace FlixOne.InventoryManagement.Command
{    
    public abstract class InventoryCommand
    {
        private readonly bool _isTerminatingCommand;
        protected IUserInterface Interface { get; }

        protected InventoryCommand(bool commandIsTerminating, IUserInterface userInteface)
        {
            _isTerminatingCommand = commandIsTerminating;
            Interface = userInteface;
        }

        public (bool wasSuccessful, bool shouldQuit) RunCommand()
        {
            if (this is IParameterisedCommand parameterisedCommand)
            {
                var allParametersCompleted = false;

                while (allParametersCompleted == false)
                {
                    allParametersCompleted = parameterisedCommand.GetParameters();
                }
            }

            return (InternalCommand(), _isTerminatingCommand);
        }

        protected abstract bool InternalCommand();

        protected string GetParameter(string parameterName)
        {
            return Interface.ReadValue($"Enter {parameterName}:");            
        }
    }
}