using FlixOne.InventoryManagement.Repository;
using FlixOne.InventoryManagement.UserInterface;
using System;

namespace FlixOne.InventoryManagement.Command
{
    public interface IInventoryCommandFactory
    {
        InventoryCommand GetCommand(string input);
    }

    public class InventoryCommandFactory : IInventoryCommandFactory
    {
        private readonly IUserInterface _userInterface;
        private readonly IInventoryContext _context;        

        public InventoryCommandFactory(IUserInterface userInterface, IInventoryContext context)
        {
            _userInterface = userInterface;
            _context = context;            
        }

        public InventoryCommand GetCommand(string input)
        {
            switch (input.ToLower())
            {
                case "q":
                case "quit":
                    return new QuitCommand(_userInterface);
                case "a":
                case "addinventory":
                    return new AddInventoryCommand(_userInterface, _context);
                case "g":
                case "getinventory":
                    return new GetInventoryCommand(_userInterface, _context);
                case "u":
                case "updatequantity":
                    return new UpdateQuantityCommand(_userInterface, _context);
                case "?":
                    return new HelpCommand(_userInterface);
                default:
                    return new UnknownCommand(_userInterface);
            }
        }
    }
}