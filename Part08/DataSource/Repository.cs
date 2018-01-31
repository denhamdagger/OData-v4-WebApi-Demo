using Part08.Models;
using System.Collections.Generic;
using System.Linq;

namespace Part08.DataSource
{
	public class Repository
	{
		private List<Customer> _customers;

		public Repository()
		{
			_customers = new List<Customer> {
				new Customer { Id = 1, FirstName = "Katie", LastName = "Smith", Age = 15 },
				new Customer { Id = 2, FirstName = "Luke", LastName = "Jones", Age = 26 },
				new Customer { Id = 3, FirstName = "Carl", LastName = "Lewis", Age = 47 }
			};
		}

		public IQueryable<Customer> GetCustomers()
		{
			return _customers.AsQueryable();
		}

		public Customer GetCustomer(int id)
		{
			return _customers.Where(p => p.Id == id).FirstOrDefault();
		}
	}
}