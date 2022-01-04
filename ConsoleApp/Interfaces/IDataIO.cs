using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Interfaces
{
    interface IDataIO
    {
        public void ToConsole(string message);
        public string FromConsole();
        public int IntFromConsole();
        public void ClearConsole();
    }
}
