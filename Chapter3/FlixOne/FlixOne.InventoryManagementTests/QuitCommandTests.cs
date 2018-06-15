using System;
using System.Collections.Generic;
using FlixOne.InventoryManagement.Command;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlixOne.InventoryManagementTests
{
    /// <summary>
    /// Quit Command Tests
    /// </summary>
    /// <remarks>
    /// A quit command ("q", "quit") is available
    ///     prints a farewell message
    ///     ends the application
    /// </remarks>
    [TestClass]
    public class QuitCommandTests
    {
        [TestMethod]
        public void QuitCommand_Successful()
        {
            var expectedInterface = new Helpers.TestUserInterface(
                new List<Tuple<string, string>>(), // ReadValue()
                new List<string> // WriteMessage()
                {
                    "Thank you for using FlixOne Inventory Management System"
                },
                new List<string>() // WriteWarning()
            );

            // create an instance of the command
            var command = new QuitCommand(expectedInterface);

            // add a new book with parameter "name"
            var result = command.RunCommand();

            expectedInterface.Validate();

            Assert.IsTrue(result.shouldQuit, "Quit is a terminating command.");
            Assert.IsTrue(result.wasSuccessful, "Quit did not complete Successfully.");
        }
    }
}
