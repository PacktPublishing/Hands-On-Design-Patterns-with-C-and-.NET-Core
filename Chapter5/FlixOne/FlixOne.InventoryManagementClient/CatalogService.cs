using System;
using System.Reflection;
using FlixOne.InventoryManagement.Command;
using FlixOne.InventoryManagement.UserInterface;

namespace FlixOne.InventoryManagementClient
{
    interface ICatalogService
    {
        void Run();
    }
    public class CatalogService : ICatalogService
    {
        private readonly IUserInterface _userInterface;
        private readonly Func<string, InventoryCommand> _commandFactory;

public CatalogService(IUserInterface userInterface, Func<string, InventoryCommand> commandFactory)
{
    _userInterface = userInterface;
    _commandFactory = commandFactory;
}

        public void Run()
        {
            Greeting();

            var response = _commandFactory("?").RunCommand();

            while (!response.shouldQuit)
            {
                // look at this mistake with the ToLower()
                var input = _userInterface.ReadValue("> ").ToLower();
                var command = _commandFactory(input);

                response = command.RunCommand();

                if (!response.wasSuccessful)
                {
                    _userInterface.WriteMessage("Enter ? to view options.");
                }
            }
        }

        private void Greeting()
        {
            // get version and display
            var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();            

            _userInterface.WriteMessage( "*********************************************************************************************");
            _userInterface.WriteMessage( "*                                                                                           *");
            _userInterface.WriteMessage( "*               Welcome to FlixOne Inventory Management System                              *");
            _userInterface.WriteMessage($"*                                                                                v{version}   *");
            _userInterface.WriteMessage( "*********************************************************************************************");
            _userInterface.WriteMessage( "");
        }
    }
}
