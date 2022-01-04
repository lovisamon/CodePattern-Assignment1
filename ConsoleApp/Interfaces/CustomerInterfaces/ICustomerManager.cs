using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Interfaces.CustomerInterfaces
{
    interface ICustomerManager
    {
        public ICustomer CreateCustomer(string firstName, string lastName);
        public void RegisterCustomer();
        public void ListAllCustomers();
    }
}
