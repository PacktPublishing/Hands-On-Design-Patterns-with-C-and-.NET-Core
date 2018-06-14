using System;
using FlixOne.InventoryManagement.Command;
using FlixOne.InventoryManagement.UserInterface;
using Microsoft.Extensions.DependencyInjection;

namespace FlixOne.InventoryManagementClient
{
    class Program
    {
        private static void Main(string[] args)
        {
            var service = new CatalogService(new ConsoleUserInterface());            
            service.Run();

            Console.WriteLine("CatalogService has completed.");
            Console.ReadLine();
        }        
    }
}
