using System;
using System.Collections.Generic;
using System.Linq;
using FlixOne.InventoryManagement.Command;
using FlixOne.InventoryManagement.Models;
using FlixOne.InventoryManagementTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlixOne.InventoryManagementTests
{
    [TestClass]
    public class CommandFactoryTests
    {
        //[TestMethod]
        //public void Factory_AddInventoryCommand_Successful()
        //{
        //    // verify short version returns an AddInventoryCommand

        //    // verify long version of the AddInventoryCommand

        //    // verify long version of the command is not case sensitive

        //    Assert.Inconclusive("Factory_AddInventoryCommand_Successful has not been implemented yet.");
        //}        

        private void RunSuccessfulCommand(string input)
        {
            const string expectedBookName = "AddInventoryUnitTest";
            var expectedInterface = new Helpers.TestUserInterface(
                new List<Tuple<string, string>>
                {
                    new Tuple<string, string>("Enter name:", expectedBookName)
                },
                new List<string>(),
                new List<string>()
            );

            var context = new TestInventoryContext(new Dictionary<string, Book>
            {
                { "Gremlins", new Book { Id = 1, Name = "Gremlins", Quantity = 7 } } 
            });

            var factory = new InventoryCommandFactory(expectedInterface);

            var command = factory.GetCommand(input);

            var result = command.RunCommand();

            Assert.IsFalse(result.shouldQuit, "AddInventory is not a terminating command.");
            Assert.IsTrue(result.wasSuccessful, "AddInventory did not complete Successfully.");

            Assert.AreEqual(1, context.GetAddedBooks().Length, "AddInventory should have added one new book.");

            var newBook = context.GetAddedBooks().First();

            Assert.AreEqual(expectedBookName, newBook.Name, "AddInventory did not add book successfully.");
        }
    }
}
