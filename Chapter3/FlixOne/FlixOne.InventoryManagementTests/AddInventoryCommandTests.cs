using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlixOne.InventoryManagementTests
{
    /// <summary>
    /// AddInventory unit tests
    /// </summary>
    /// <remarks>
    ///     An add inventory command ("a", "addinventory") is available
    ///          parameter "name" of type string
    ///          adds an entry into the database with the given name and a 0 quantity
    /// </remarks>
    [TestClass]
    public class AddInventoryCommandTests
    {
        [TestMethod]
        public void AddInventoryCommand_Successful()
        {
            // create an instance of the command
            // add a new book with parameter "name"
            // verify the book was added with the given name with 0 quantity

            Assert.Inconclusive("AddInventoryCommand_Successful has not been implemented.");
        }
    }
}