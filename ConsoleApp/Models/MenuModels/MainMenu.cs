using ConsoleApp.Interfaces;
using ConsoleApp.Interfaces.AnimalInterfaces;
using ConsoleApp.Interfaces.CustomerInterfaces;
using ConsoleApp.Interfaces.MenuInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models.MenuModels
{
    class MainMenu : IMainMenu
    {
        private readonly IMenuManager _menuManager;
        private readonly ICustomerManager _customerManager;
        private readonly IAnimalManager _animalManager;

        public MainMenu(IMenuManager menuManager, ICustomerManager customerManager, IAnimalManager animalManager)
        {
            _menuManager = menuManager;
            _customerManager = customerManager;
            _animalManager = animalManager;
        }

        public void Init()
        {
            _menuManager.CreateMenu("*** Main Menu ***");
            _menuManager.CreateMenuItem("Register New Customer", _customerManager.RegisterCustomer);
            _menuManager.CreateMenuItem("Register New Animal", _animalManager.RegisterAnimal);
            _menuManager.CreateMenuItem("List All Customers", _customerManager.ListAllCustomers);
            _menuManager.CreateMenuItem("List All Animals", _animalManager.ListAllAnimals);
            _menuManager.CreateMenuItem("Add Service to Animal", _animalManager.AddService);
            _menuManager.CreateMenuItem("Check In Animal", _animalManager.CheckIn);
            _menuManager.CreateMenuItem("Check Out Animal", _animalManager.CheckOut);
            _menuManager.CreateMenuItem("Exit", ExitProgram); 
        }

        public void Run()
        {
            while (true)
            {
                _menuManager.DrawMenu();
                _menuManager.CallMenuItem();
            }
        }

        public void ExitProgram()
        {
            Environment.Exit(0);
        }
    }
}
