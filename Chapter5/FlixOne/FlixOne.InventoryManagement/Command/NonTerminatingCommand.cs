using FlixOne.InventoryManagement.UserInterface;

namespace FlixOne.InventoryManagement.Command
{
    public abstract class NonTerminatingCommand : InventoryCommand
    {
        protected NonTerminatingCommand(IUserInterface userInterface) : base(commandIsTerminating: false, userInteface: userInterface)
        {
        }
    }
}