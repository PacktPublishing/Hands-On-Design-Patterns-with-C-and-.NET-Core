using FlixOne.InventoryManagement.UserInterface;

namespace FlixOne.InventoryManagement.Command
{
    public class QuitCommand : InventoryCommand
    {
        public QuitCommand(IUserInterface userInterface) : base(true, userInterface)
        {
        }

        protected override bool InternalCommand()
        {
            Interface.WriteMessage("Thank you for using FlixOne Inventory Management System");

            return true;
        }
    }
}