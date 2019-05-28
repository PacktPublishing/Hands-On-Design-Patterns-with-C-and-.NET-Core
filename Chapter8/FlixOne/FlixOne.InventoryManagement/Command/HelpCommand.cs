using FlixOne.InventoryManagement.UserInterface;

namespace FlixOne.InventoryManagement.Command
{
    internal class HelpCommand : NonTerminatingCommand
    {
        internal HelpCommand(IUserInterface userInterface) : base(userInterface)
        {
        }

        protected override bool InternalCommand()
        {
            Interface.WriteMessage("USAGE:");
            Interface.WriteMessage("\taddinventory (a)");
            Interface.WriteMessage("\tgetinventory (g)");
            Interface.WriteMessage("\tupdatequantity (u)");
            Interface.WriteMessage("\tquit (q)");
            Interface.WriteMessage("\t?");
            Interface.WriteMessage("Examples:");
            Interface.WriteMessage("\tNew Inventory");
            Interface.WriteMessage("\t> addinventory");
            Interface.WriteMessage("\tEnter name:The Meaning of Life");
            Interface.WriteMessage("");
            Interface.WriteMessage("\tGet Inventory");
            Interface.WriteMessage("\t> getinventory");
            Interface.WriteMessage("\tThe Meaning of Life        Quantity:10");
            Interface.WriteMessage("\tThe Life of a Ninja        Quantity:2");
            Interface.WriteMessage("");
            Interface.WriteMessage("\tUpdate Quantity (Increase)");
            Interface.WriteMessage("\t> updatequantity");
            Interface.WriteMessage("\tEnter name:The Meaning of Life");
            Interface.WriteMessage("\t11");
            Interface.WriteMessage("\t11 added to quantity");
            Interface.WriteMessage("");
            Interface.WriteMessage("\tUpdate Quantity (Decrease)");
            Interface.WriteMessage("\t> updatequantity");
            Interface.WriteMessage("\tEnter name:The Life of a Ninja");
            Interface.WriteMessage("\t-3");
            Interface.WriteMessage("\t3 removed from quantity");
            Interface.WriteMessage("");

            return true;
        }
    }
}