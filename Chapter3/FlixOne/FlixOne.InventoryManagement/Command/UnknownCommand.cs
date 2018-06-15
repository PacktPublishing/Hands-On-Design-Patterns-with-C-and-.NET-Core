using FlixOne.InventoryManagement.UserInterface;

namespace FlixOne.InventoryManagement.Command
{
    public class UnknownCommand : NonTerminatingCommand
    {
        public UnknownCommand(IUserInterface userInterface) : base(userInterface)
        {
        }

        protected override bool InternalCommand()
        {            
            Interface.WriteWarning("Unable to determine the desired command.");         

            return false;
        }
    }
}