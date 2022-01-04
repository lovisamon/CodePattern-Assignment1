using ConsoleApp.Interfaces.AnimalInterfaces;
using ConsoleApp.Interfaces.CustomerInterfaces;
using ConsoleApp.Interfaces.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Interfaces.DatabaseInterfaces
{
    interface IDbManager
    {
        public List<ICustomer> GetCustomers();
        public List<IAnimal> GetAnimals();
        public List<IAnimal> GetCheckedInAnimals();
        public List<IAnimal> GetCheckedOutAnimals();
        public List<IService> GetServices();
        public void AddCustomer(ICustomer customer);
        public void AddAnimal(IAnimal animal);
    }
}
