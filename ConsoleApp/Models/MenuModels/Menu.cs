using ConsoleApp.Interfaces.MenuInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models.MenuModels
{
    class Menu : IMenu
    {
        public string Name { get; set; }
        public List<IMenuItem> MenuItems { get; set; }
    }
}
