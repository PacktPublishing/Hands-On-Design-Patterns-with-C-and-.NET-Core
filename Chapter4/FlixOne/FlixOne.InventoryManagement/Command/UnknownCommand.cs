using FlixOne.InventoryManagement.UserInterface;
using System;

namespace FlixOne.InventoryManagement.Command
{
    internal class UnknownCommand : NonTerminatingCommand
    {        
        internal UnknownCommand(IUserInterface userInterface) : base(userInterface)
        {
        }

        protected override bool InternalCommand()
        {            
            Interface.WriteWarning("Unable to determine the desired command.");         

            return false;
        }
    }
}