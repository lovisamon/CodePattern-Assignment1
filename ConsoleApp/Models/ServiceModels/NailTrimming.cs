using ConsoleApp.Interfaces.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models.ServiceModels
{
    class NailTrimming : IService
    {
        public string Name => "Nail Trimming";
        public decimal Cost => 150;

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
