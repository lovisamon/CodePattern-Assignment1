using ConsoleApp.Interfaces.AnimalInterfaces;
using ConsoleApp.Interfaces.CustomerInterfaces;
using ConsoleApp.Interfaces.DatabaseInterfaces;
using ConsoleApp.Interfaces.ServiceInterfaces;
using ConsoleApp.Models.AnimalModels;
using ConsoleApp.Models.CustomerModels;
using ConsoleApp.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models.DatabaseModels
{
    class DbManager : IDbManager
    {
        private readonly Customer.Factory _customerFactory;
        private readonly Animal.Factory _animalFactory;
        private readonly Service.Factory _serviceFactory;
        private readonly List<ICustomer> _customers = new();
        private readonly List<IAnimal> _animals = new();
        private readonly List<IService> _services = new();

        /* Load Dummy Data
         Realistically, data already exists in the database.
         However, since this is a mock database we populate it here.
        */
        public DbManager(Customer.Factory customerFactory, Animal.Factory animalFactory, Service.Factory serviceFactory)
        {
            _customerFactory = customerFactory;
            _animalFactory = animalFactory;
            _serviceFactory = serviceFactory;

            ICustomer customer = _customerFactory("Lovisa", "Montelius");
            IAnimal animal = _animalFactory("Molly", customer);
            AddCustomer(customer);
            AddAnimal(animal);

            IService nailtrimming = _serviceFactory("Nail Trimming", 150);
            IService wash = _serviceFactory("Wash", 200);
            _services.Add(nailtrimming);
            _services.Add(wash);
        }

        #region GET METHODS
        public List<ICustomer> GetCustomers()
        {
            return _customers;
        }

        public List<IAnimal> GetAnimals()
        {
            return _animals;
        }

        public List<IAnimal> GetCheckedInAnimals()
        {
            List<IAnimal> animals = new();
            foreach (IAnimal animal in _animals)
            {
                if(animal.CheckedIn == true)
                {
                    animals.Add(animal);
                }
            }
            return animals;
        }

        public List<IAnimal> GetCheckedOutAnimals()
        {
            List<IAnimal> animals = new();
            foreach (IAnimal animal in _animals)
            {
                if (animal.CheckedIn == false)
                {
                    animals.Add(animal);
                }
            }
            return animals;
        }

        public List<IService> GetServices()
        {
            return _services;
        }
        #endregion GET

        #region SAVE METHODS
        public void AddCustomer(ICustomer customer)
        {
            _customers.Add(customer);
        }

        public void AddAnimal(IAnimal animal)
        {
            _animals.Add(animal);
        }
        #endregion SAVE METHODS
    }
}
