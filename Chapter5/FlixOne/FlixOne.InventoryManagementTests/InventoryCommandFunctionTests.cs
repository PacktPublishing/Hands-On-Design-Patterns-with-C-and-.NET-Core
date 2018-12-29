using System;
using System.Collections.Generic;
using FlixOne.InventoryManagement.Command;
using FlixOne.InventoryManagement.Models;
using FlixOne.InventoryManagement.Repository;
using FlixOne.InventoryManagementTests.Helpers;
using Microsoft.Extensions.DependencyInjection;
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
    public class InventoryCommandFunctionTests
    {
        ServiceProvider Services { get; set; }

        [TestInitialize]
        public void Startup()
        {
            var expectedInterface = new Helpers.TestUserInterface(
                new List<Tuple<string, string>>(),
                new List<string>(),
                new List<string>()
            );

            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IInventoryContext, InventoryContext>();
            services.AddTransient<Func<string, InventoryCommand>>(InventoryCommand.GetInventoryCommand);

            Services = services.BuildServiceProvider();
        }

        [TestMethod]
        public void QuitCommand_Successful()
        {
            Assert.IsInstanceOfType(Services.GetService<Func<string, InventoryCommand>>().Invoke("q"), typeof(QuitCommand), "q should be QuitCommand");
            Assert.IsInstanceOfType(Services.GetService<Func<string, InventoryCommand>>().Invoke("quit"), typeof(QuitCommand), "quit should be QuitCommand");
        }

        [TestMethod]
        public void HelpCommand_Successful()
        {
            Assert.IsInstanceOfType(Services.GetService<Func<string, InventoryCommand>>().Invoke("?"), typeof(HelpCommand), "h should be HelpCommand");            
        }

        [TestMethod]
        public void UnknownCommand_Successful()
        {
            Assert.IsInstanceOfType(Services.GetService<Func<string, InventoryCommand>>().Invoke("add"), typeof(UnknownCommand), "unmatched command should be UnknownCommand");
            Assert.IsInstanceOfType(Services.GetService<Func<string, InventoryCommand>>().Invoke("addinventry"), typeof(UnknownCommand), "unmatched command should be UnknownCommand");
            Assert.IsInstanceOfType(Services.GetService<Func<string, InventoryCommand>>().Invoke("h"), typeof(UnknownCommand), "unmatched command should be UnknownCommand");
            Assert.IsInstanceOfType(Services.GetService<Func<string, InventoryCommand>>().Invoke("help"), typeof(UnknownCommand), "unmatched command should be UnknownCommand");
        }

        [TestMethod]
        public void AddInventoryCommand_Successful()
        {
            Assert.IsInstanceOfType(Services.GetService<Func<string, InventoryCommand>>().Invoke("a"), typeof(AddInventoryCommand), "a should be AddInventoryCommand");
            Assert.IsInstanceOfType(Services.GetService<Func<string, InventoryCommand>>().Invoke("addinventory"), typeof(AddInventoryCommand), "addinventory should be AddInventoryCommand");
        }

        [TestMethod]
        public void GetInventoryCommand_Successful()
        {
            Assert.IsInstanceOfType(Services.GetService<Func<string, InventoryCommand>>().Invoke("g"), typeof(GetInventoryCommand), "g should be GetInventoryCommand");
            Assert.IsInstanceOfType(Services.GetService<Func<string, InventoryCommand>>().Invoke("getinventory"), typeof(GetInventoryCommand), "getinventory should be GetInventoryCommand");
        }

        [TestMethod]
        public void UpdateQuantityCommand_Successful()
        {
            Assert.IsInstanceOfType(Services.GetService<Func<string, InventoryCommand>>().Invoke("u"), typeof(UpdateQuantityCommand), "u should be UpdateQuantityCommand");
            Assert.IsInstanceOfType(Services.GetService<Func<string, InventoryCommand>>().Invoke("updatequantity"), typeof(UpdateQuantityCommand), "updatequantity should be UpdateQuantityCommand");
            Assert.IsInstanceOfType(Services.GetService<Func<string, InventoryCommand>>().Invoke("UpdaTEQuantity"), typeof(UpdateQuantityCommand), "UpdaTEQuantity should be UpdateQuantityCommand");
        }
    }
}
