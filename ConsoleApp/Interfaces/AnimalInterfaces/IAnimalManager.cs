using ConsoleApp.Interfaces.CustomerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Interfaces.AnimalInterfaces
{
    interface IAnimalManager
    {
        public IAnimal CreateAnimal(string name, ICustomer owner);
        public void RegisterAnimal();
        public void ListAllAnimals();
        public void CheckIn();
        public void CheckOut();
        public void AddService();
    }
}
