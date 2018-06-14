using System;
using FlixOne.InventoryManagement.UserInterface;

namespace FlixOne.InventoryManagement.Command
{
    public class GetInventoryCommand : NonTerminatingCommand
    {
        public GetInventoryCommand(IUserInterface userInterface) : base(userInterface)
        {            
        }

        protected override bool InternalCommand()
        {
            throw new NotImplementedException("Implemented in next chapter!");
        }
    }
}