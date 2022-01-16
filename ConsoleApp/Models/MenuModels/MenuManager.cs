using ConsoleApp.Interfaces;
using ConsoleApp.Interfaces.MenuInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models.MenuModels
{
    class MenuManager : IMenuManager
    {
        private readonly IDataIO _dataIO;
        private readonly IMenu _menu;
        private readonly MenuItem.Factory _menuItemFactory;

        public MenuManager(IDataIO dataIO, IMenu menu, MenuItem.Factory menuItemFactory)
        {
            _dataIO = dataIO;
            _menu = menu;
            _menuItemFactory = menuItemFactory;
        }

        public void CreateMenu(string name)
        {
            _menu.Name = name;
            _menu.MenuItems = new();
        }

        public void CreateMenuItem(string name, Action action)
        {
            _menu.MenuItems.Add(_menuItemFactory(name, action));
        }

        public void DrawMenu()
        {
            _dataIO.ToConsole(_menu.Name);
            for(int i = 0; i < _menu.MenuItems.Count; i++)
            {
                _dataIO.ToConsole($"{i + 1}. {_menu.MenuItems[i].Name}");
            }
        }

        public void CallMenuItem()
        {
            int selection = _dataIO.IntFromConsole();
            _dataIO.ClearConsole();
            _dataIO.ToConsole($"*** {_menu.MenuItems[selection - 1].Name} ***");
            _menu.MenuItems[selection - 1].Action();
            _dataIO.ToConsole("");
        }
    }
}
