using ConsoleApp.Interfaces;
using ConsoleApp.Interfaces.AnimalInterfaces;
using ConsoleApp.Interfaces.CustomerInterfaces;
using ConsoleApp.Interfaces.DatabaseInterfaces;
using ConsoleApp.Interfaces.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models.AnimalModels
{
    class AnimalManager : IAnimalManager
    {
        private readonly IDataIO _dataIO;
        private readonly IDbManager _dbManager;

        public AnimalManager(IDataIO dataIO, IDbManager dbManager)
        {
            _dataIO = dataIO;
            _dbManager = dbManager;
        }

        public IAnimal CreateAnimal(string name, ICustomer owner)
        {
            IAnimal animal = new Animal
            {
                Name = name,
                Owner = owner
            };
            return animal;
        }
        public void RegisterAnimal()
        {
            List<ICustomer> customers = _dbManager.GetCustomers();
            if (customers.Count == 0)
            {
                _dataIO.ToConsole($"No customers found.");
                return;
            }
            _dataIO.ToConsole("Enter the owner (enter a number):");
            int i = 1;
            foreach (ICustomer customer in customers)
            {
                _dataIO.ToConsole($"{i}. {customer.DisplayName}");
                i++;
            }
            int target = _dataIO.IntFromConsole();
            ICustomer owner = customers[target - 1];

            _dataIO.ToConsole("Enter the animal's name:");
            string name = _dataIO.FromConsole();

            IAnimal animal = CreateAnimal(name, customers[target - 1]);
            _dbManager.AddAnimal(animal);

            _dataIO.ToConsole(animal.Name + " registered!");
        }

        public void ListAllAnimals()
        {
            List<IAnimal> animals = _dbManager.GetAnimals();
            int i = 1;
            foreach (IAnimal animal in animals)
            {
                _dataIO.ToConsole($"{i}. {animal.Name}, Owner: {animal.Owner.DisplayName}, CheckedIn: {animal.CheckedIn}");
                i++;
            }
        }

        public void CheckIn()
        {
            List<IAnimal> animals = _dbManager.GetCheckedOutAnimals();
            if (animals.Count == 0) {
                _dataIO.ToConsole($"No valid animals found.");
                return;
            }
            IAnimal animal = GetSelectedAnimalFromList(animals);
            animal.CheckedIn = true;
            _dataIO.ToConsole($"{animal.Name} checked in {DateTime.Now}.");

        }

        public void CheckOut()
        {
            List<IAnimal> animals = _dbManager.GetCheckedInAnimals();
            if (animals.Count == 0)
            {
                _dataIO.ToConsole($"No valid animals found.");
                return;
            }
            IAnimal animal = GetSelectedAnimalFromList(animals);
            animal.CheckedIn = false;
            _dataIO.ToConsole($"{animal.Name} checked out {DateTime.Now}.");
            DrawReceipt(animal);
        }

        public void AddService()
        {
            List<IAnimal> animals = _dbManager.GetAnimals();
            if (animals.Count == 0)
            {
                _dataIO.ToConsole($"No valid animals found.");
                return;
            }
            IAnimal animal = GetSelectedAnimalFromList(_dbManager.GetAnimals());
            List<IService> services = _dbManager.GetServices();
            _dataIO.ToConsole("Select a service (enter a number):");
            int i = 1;
            foreach (IService service in services)
            {
                _dataIO.ToConsole($"{i}. {service.GetName()}, Cost: {service.GetCost()}");
                i++;
            }
            int selection = _dataIO.IntFromConsole();
            animal.Services.Add(services[selection - 1]);
        }

        public IAnimal GetSelectedAnimalFromList(List<IAnimal> animals)
        {
            _dataIO.ToConsole("Select an animal (enter a number):");
            int i = 1;
            foreach (IAnimal animal in animals)
            {
                _dataIO.ToConsole($"{i}. {animal.Name}, Owner: {animal.Owner.DisplayName}");
                i++;
            }
            int selection = _dataIO.IntFromConsole();
            return animals[selection - 1];
        }

        public void DrawReceipt(IAnimal animal)
        {
            _dataIO.ToConsole($"*** RECEIPT ***");
            decimal TotalCost = 0;
            foreach (IService service in animal.Services)
            {
                _dataIO.ToConsole($"{service.GetName()}: {service.GetCost()}SEK");
                TotalCost += service.GetCost();
            }
            _dataIO.ToConsole($"Total Cost: {TotalCost}SEK");
            animal.Services.Clear();
        }
    }
}
