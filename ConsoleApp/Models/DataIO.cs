using ConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    class DataIO : IDataIO
    {
        public void ToConsole(string message)
        {
            Console.WriteLine(message);
        }

        public string FromConsole()
        {
            return Console.ReadLine();
        }

        public int IntFromConsole()
        {
            return int.Parse(Console.ReadLine());
            
        }

        public void ClearConsole()
        {
            Console.Clear();
        }
    }
}
