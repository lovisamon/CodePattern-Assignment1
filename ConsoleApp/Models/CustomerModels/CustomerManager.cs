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
        private readonly Customer.Factory _customerFactory;

        public CustomerManager(IDataIO dataIO, IDbManager dbManager, Customer.Factory customerFactory)
        {
            _dataIO = dataIO;
            _dbManager = dbManager;
            _customerFactory = customerFactory;
        }

        public ICustomer CreateCustomer(string firstName, string lastName)
        {
            return _customerFactory(firstName, lastName);
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
