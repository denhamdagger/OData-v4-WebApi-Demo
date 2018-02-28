using Part14.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;

namespace Part14.Controllers
{
	public class EmployeesController : ODataController
	{
		private Northwind _repo;

		public EmployeesController()
		{
			_repo = new Northwind();
			_repo.Database.Log = sql => Debug.WriteLine(sql);
		}

		[EnableQuery]
		public IQueryable<Employee> Get()
		{
			return _repo.Employees;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (_repo != null)
				{
					_repo.Dispose();
					_repo = null;
				}
			}
		}
	}
}