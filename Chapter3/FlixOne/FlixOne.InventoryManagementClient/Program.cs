using System;

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
