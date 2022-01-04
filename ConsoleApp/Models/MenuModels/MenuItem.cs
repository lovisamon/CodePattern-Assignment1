using ConsoleApp.Interfaces.MenuInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models.MenuModels
{
    class MenuItem : IMenuItem
    {
        public string Name { get; set; }
        public Action Action { get; set; }

        public MenuItem(string name, Action action)
        {
            Name = name;
            Action = action;
        }
    }
}
