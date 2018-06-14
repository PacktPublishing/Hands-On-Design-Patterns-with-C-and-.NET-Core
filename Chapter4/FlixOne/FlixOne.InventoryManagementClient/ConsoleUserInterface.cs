using System;
using FlixOne.InventoryManagement.UserInterface;

namespace FlixOne.InventoryManagementClient
{
    // https://msdn.microsoft.com/en-us/library/ff648968.aspx
    internal class ConsoleUserInterface : IUserInterface
    {
        public string ReadValue(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(message);
            return Console.ReadLine();
        }

        public void WriteMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
        }

        public void WriteWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(message);
        }
    }
}
