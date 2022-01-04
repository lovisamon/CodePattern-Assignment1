using ConsoleApp.Interfaces.CustomerInterfaces;
using ConsoleApp.Interfaces.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Interfaces.AnimalInterfaces
{
    interface IAnimal
    {
        public string Name { get; set; }
        public ICustomer Owner { get; set; }
        public bool CheckedIn { get; set; }
        public List<IService> Services { get; set; }
    }
}
