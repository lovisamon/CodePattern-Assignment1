using ConsoleApp.Interfaces.CustomerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models.CustomerModels
{
    class Customer : ICustomer
    {
        public delegate Customer Factory(string firstName, string lastName);
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName => $"{FirstName} {LastName}";
        
        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
