using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FlixOne.InventoryManagementTests.ImplemenationFactoryTests
{
    public abstract class InventoryCommand
    {
        protected abstract string[] CommandStrings { get; }
        public virtual bool IsCommandFor(string input)
        {
            return CommandStrings.Contains(input.ToLower());
        }        
    }

    public class QuitCommand : InventoryCommand
    {
        protected override string[] CommandStrings => new[] { "q", "quit" };
    }

    public class GetInventoryCommand : InventoryCommand
    {
        protected override string[] CommandStrings => new[] { "g", "getinventory" };
    }

    public class AddInventoryCommand : InventoryCommand
    {
        protected override string[] CommandStrings => new[] { "a", "addinventory" };
    }

    public class UpdateQuantityCommand : InventoryCommand
    {
        protected override string[] CommandStrings => new[] { "u", "updatequantity" };
    }

    public class HelpCommand : InventoryCommand
    {
        protected override string[] CommandStrings => new[] { "?" };
    }

    public class UnknownCommand : InventoryCommand
    {
        protected override string[] CommandStrings => new string[0];

        public override bool IsCommandFor(string input)
        {
            return true;
        }
    }
}
