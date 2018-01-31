using Part08.DataSource;
using Part08.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.OData;

namespace Part08.Controllers
{
	public class CustomersController : ODataController
	{
		private Repository _repo;

		public CustomersController()
		{
			_repo = new Repository();
		}

		// OData\Customers
		[EnableQuery]
		public IQueryable<Customer> Get()
		{
			return _repo.GetCustomers();
		}

		// OData\Customers(1)
		[EnableQuery]
		public Customer Get([FromODataUri] int Key)
		{
			return _repo.GetCustomer(Key);
		}
	}
}