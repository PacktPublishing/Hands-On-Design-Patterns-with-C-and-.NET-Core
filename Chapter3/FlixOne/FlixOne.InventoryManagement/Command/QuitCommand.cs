using FlixOne.InventoryManagement.UserInterface;

namespace FlixOne.InventoryManagement.Command
{
internal class QuitCommand : InventoryCommand
{
    internal QuitCommand(IUserInterface userInterface) : base(true, userInterface) { }

    protected override bool InternalCommand()
    {
        Interface.WriteMessage("Thank you for using FlixOne Inventory Management System");
            
        return true;
    }
}
}