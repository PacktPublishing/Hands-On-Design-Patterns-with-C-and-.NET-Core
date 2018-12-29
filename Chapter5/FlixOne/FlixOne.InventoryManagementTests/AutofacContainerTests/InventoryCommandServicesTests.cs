using Autofac;
using Autofac.Core;
using FlixOne.InventoryManagementTests.ImplemenationFactoryTests;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlixOne.InventoryManagementTests
{       
    [TestClass]
    public class InventoryCommandAutofacTests
    {
        IContainer Container { get; set; }

        [TestInitialize]
        public void Startup()
        {
            IServiceCollection services = new ServiceCollection();

            var builder = new ContainerBuilder();            

            builder.RegisterType<QuitCommand>().Named<InventoryCommand>("q");
            builder.RegisterType<QuitCommand>().Named<InventoryCommand>("quit");
            builder.RegisterType<UpdateQuantityCommand>().Named<InventoryCommand>("u");
            builder.RegisterType<UpdateQuantityCommand>().Named<InventoryCommand>("updatequantity");
            builder.RegisterType<HelpCommand>().Named<InventoryCommand>("?");
            builder.RegisterType<AddInventoryCommand>().Named<InventoryCommand>("a");
            builder.RegisterType<AddInventoryCommand>().Named<InventoryCommand>("addinventory");
            builder.RegisterType<GetInventoryCommand>().Named<InventoryCommand>("g");
            builder.RegisterType<GetInventoryCommand>().Named<InventoryCommand>("getinventory");
            builder.RegisterType<UpdateQuantityCommand>().Named<InventoryCommand>("u");
            builder.RegisterType<UpdateQuantityCommand>().Named<InventoryCommand>("u");
            builder.RegisterType<UnknownCommand>().As<InventoryCommand>();

            Container = builder.Build();            
        }

        public InventoryCommand GetCommand(string input)
        {
            return Container.ResolveOptionalNamed<InventoryCommand>(input.ToLower()) ?? Container.Resolve<InventoryCommand>();
        }


        [TestMethod]
        public void QuitCommand_Successful()
        {
            Assert.IsInstanceOfType(GetCommand("q"), typeof(QuitCommand), "q should be QuitCommand");
            Assert.IsInstanceOfType(GetCommand("quit"), typeof(QuitCommand), "quit should be QuitCommand");
        }

        [TestMethod]
        public void HelpCommand_Successful()
        {
            Assert.IsInstanceOfType(GetCommand("?"), typeof(HelpCommand), "? should be HelpCommand");            
        }

        [TestMethod]
        public void UnknownCommand_Successful()
        {
            Assert.IsInstanceOfType(GetCommand("add"), typeof(UnknownCommand), "unmatched command should be UnknownCommand");
            Assert.IsInstanceOfType(GetCommand("addinventry"), typeof(UnknownCommand), "unmatched command should be UnknownCommand");
            Assert.IsInstanceOfType(GetCommand("h"), typeof(UnknownCommand), "unmatched command should be UnknownCommand");
            Assert.IsInstanceOfType(GetCommand("help"), typeof(UnknownCommand), "unmatched command should be UnknownCommand");
        }

        [TestMethod]
        public void AddInventoryCommand_Successful()
        {
            Assert.IsInstanceOfType(GetCommand("a"), typeof(AddInventoryCommand), "a should be AddInventoryCommand");
            Assert.IsInstanceOfType(GetCommand("addinventory"), typeof(AddInventoryCommand), "addinventory should be AddInventoryCommand");
        }

        [TestMethod]
        public void GetInventoryCommand_Successful()
        {
            Assert.IsInstanceOfType(GetCommand("g"), typeof(GetInventoryCommand), "g should be GetInventoryCommand");
            Assert.IsInstanceOfType(GetCommand("getinventory"), typeof(GetInventoryCommand), "getinventory should be GetInventoryCommand");
        }

        [TestMethod]
        public void UpdateQuantityCommand_Successful()
        {
            Assert.IsInstanceOfType(GetCommand("u"), typeof(UpdateQuantityCommand), "u should be UpdateQuantityCommand");
            Assert.IsInstanceOfType(GetCommand("updatequantity"), typeof(UpdateQuantityCommand), "updatequantity should be UpdateQuantityCommand");
            Assert.IsInstanceOfType(GetCommand("UpdaTEQuantity"), typeof(UpdateQuantityCommand), "UpdaTEQuantity should be UpdateQuantityCommand");
        }
    }
}
