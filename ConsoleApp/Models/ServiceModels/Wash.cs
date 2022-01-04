using ConsoleApp.Interfaces.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models.ServiceModels
{
    class Wash : IService
    {
        public string Name => "Wash";
        public decimal Cost => 200;

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
