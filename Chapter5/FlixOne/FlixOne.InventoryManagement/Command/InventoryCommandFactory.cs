using FlixOne.InventoryManagement.Repository;
using FlixOne.InventoryManagement.UserInterface;

namespace FlixOne.InventoryManagement.Command
{
    public interface IInventoryCommandFactory
    {
        InventoryCommand GetCommand(string input);
    }

    public class InventoryCommandFactory : IInventoryCommandFactory
    {
        private readonly IUserInterface _userInterface;
        private readonly IInventoryReadContext _readContext;
        private readonly IInventoryWriteContext _writeContext;

        public InventoryCommandFactory(IUserInterface userInterface, IInventoryReadContext readContext, IInventoryWriteContext writeContext)
        {
            _userInterface = userInterface;
            _readContext = readContext;
            _writeContext = writeContext;
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
                    return new AddInventoryCommand(_userInterface, _writeContext);
                case "g":
                case "getinventory":
                    return new GetInventoryCommand(_userInterface, _readContext);
                case "u":
                case "updatequantity":
                    return new UpdateQuantityCommand(_userInterface, _writeContext);
                case "?":
                    return new HelpCommand(_userInterface);
                default:
                    return new UnknownCommand(_userInterface);
            }
        }
    }
}