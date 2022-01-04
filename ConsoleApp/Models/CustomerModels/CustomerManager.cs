using ConsoleApp.Interfaces;
using ConsoleApp.Interfaces.CustomerInterfaces;
using ConsoleApp.Interfaces.DatabaseInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models.CustomerModels
{
    class CustomerManager : ICustomerManager
    {
        private readonly IDataIO _dataIO;
        private readonly IDbManager _dbManager;

        public CustomerManager(IDataIO dataIO, IDbManager dbManager)
        {
            _dataIO = dataIO;
            _dbManager = dbManager;
        }

        public ICustomer CreateCustomer(string firstName, string lastName)
        {
            ICustomer customer = new Customer
            {
                FirstName = firstName,
                LastName = lastName
            };
            return customer;
        }

        public void RegisterCustomer()
        {
            _dataIO.ToConsole("Enter first name:");
            string firstName = _dataIO.FromConsole();
            _dataIO.ToConsole("Enter last name:");
            string lastName = _dataIO.FromConsole();

            ICustomer customer = CreateCustomer(firstName, lastName);
            _dbManager.AddCustomer(customer);

            _dataIO.ToConsole(customer.DisplayName + " registered!");
        }

        public void ListAllCustomers()
        {
            List<ICustomer> customers = _dbManager.GetCustomers();
            int i = 1;
            foreach (ICustomer customer in customers)
            {
                this._dataIO.ToConsole($"{i}. {customer.DisplayName}");
                i++;
            }
        }
    }
}
