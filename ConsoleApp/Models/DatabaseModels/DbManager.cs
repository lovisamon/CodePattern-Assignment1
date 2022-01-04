﻿using ConsoleApp.Interfaces.AnimalInterfaces;
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
        private readonly List<ICustomer> _customers = new();
        private readonly List<IAnimal> _animals = new();
        private readonly List<IService> _services = new();

        // Load in dummy data
        public DbManager()
        {
            ICustomer customer = new Customer { FirstName = "Lovisa", LastName = "Montelius" };
            IAnimal animal = new Animal { Name = "Molly", Owner = customer };

            _customers.Add(customer);
            _animals.Add(animal);
            _services.Add(new NailTrimming());
            _services.Add(new Wash());
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
