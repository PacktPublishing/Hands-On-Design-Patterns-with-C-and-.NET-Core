using System;
using System.Collections.Generic;
using System.Linq;
using FlixOne.InventoryManagement.Command;
using FlixOne.InventoryManagement.Models;
using FlixOne.InventoryManagementTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlixOne.InventoryManagementTests
{
    /// <summary>
    /// UpdateQuantity Command Tests
    /// </summary>
    /// <remarks>
    /// An update quantity command ("u", "updatequantity") is available 
    ///     parameter "name" of type string
    ///     parameter "quantity" of a positive or negative integer
    ///     updates the quantity value of the book with the given name by adding the given quantity
    /// </remarks>
    [TestClass]
    public class UpdateQuantityCommandTests
    {
        [TestMethod]
        public void UpdateQuantity_ExistingBook_Successful()
        {
            // create an instance of the command
            // add a new book with parameter "name"
            // verify the book was added with the given name with 0 quantity

            Assert.Inconclusive("UpdateQuantity_ExistingBook_Successful has not been implemented.");
        }
    }
}