using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Interfaces.MenuInterfaces
{
    interface IMenuManager
    {
        public void CreateMenu(string name);
        public void CreateMenuItem(string name, Action runThis);
        public void DrawMenu();
        public void CallMenuItem();
    }
}
