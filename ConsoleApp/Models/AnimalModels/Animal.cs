using ConsoleApp.Interfaces.AnimalInterfaces;
using ConsoleApp.Interfaces.CustomerInterfaces;
using ConsoleApp.Interfaces.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models.AnimalModels
{
    class Animal : IAnimal
    {
        public delegate Animal Factory(string name, ICustomer owner);
        public string Name { get; set; }
        public ICustomer Owner { get; set; }
        public bool CheckedIn { get; set; }
        public List<IService> Services { get; set;}

        public Animal(string name, ICustomer owner)
        {
            Name = name;
            Owner = owner;

            CheckedIn = false;
            Services = new();
        }
    }
}
