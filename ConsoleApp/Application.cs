using ConsoleApp.Interfaces.DatabaseInterfaces;
using ConsoleApp.Interfaces.MenuInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Application : IApplication
    {
        private readonly IMainMenu _mainMenu;

        public Application(IMainMenu mainMenu)
        {
            _mainMenu = mainMenu;
        }

        public void Run()
        {
            _mainMenu.Init();
            _mainMenu.Run();
        }
    }
}
