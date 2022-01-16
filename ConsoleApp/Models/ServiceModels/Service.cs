using ConsoleApp.Interfaces.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models.ServiceModels
{
    internal class Service : IService
    {
        public delegate Service Factory(string name, decimal cost);
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public Service(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public string GetName()
        {
            return Name;
        }

        public decimal GetCost()
        {
            return Cost;
        }
    }
}
