using System;
using FlixOne.InventoryManagement.UserInterface;

namespace FlixOne.InventoryManagement.Command
{
    public class AddInventoryCommand : NonTerminatingCommand, IParameterisedCommand
    {
        public AddInventoryCommand(IUserInterface userInterface) : base(userInterface)
        {
        }

        public string InventoryName { get; private set; }

        /// <summary>
        /// AddInventoryCommand requires name
        /// </summary>
        /// <returns></returns>
        public bool GetParameters()
        {
            if (string.IsNullOrWhiteSpace(InventoryName))
                InventoryName = GetParameter("name");

            return !string.IsNullOrWhiteSpace(InventoryName);
        }

        protected override bool InternalCommand()
        {
            throw new NotImplementedException("Implemented in next chapter!");
        }
    }
}