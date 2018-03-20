using Microsoft.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.UriParser;
using Part14.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using System.Web.OData.Query;
using System.Web.OData.Routing.Conventions;

namespace Part14
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			var model = GetEdmModel();

			config.MapODataServiceRoute("OData", "OData", b => b
				.AddService<IEdmModel>(ServiceLifetime.Singleton, s => model)
				.AddService<IEnumerable<IODataRoutingConvention>>(ServiceLifetime.Singleton, s => ODataRoutingConventions.CreateDefaultWithAttributeRouting("OData", config))
				.AddService<ODataUriResolver>(ServiceLifetime.Singleton, s => new AlternateKeysODataUriResolver(model))
			);
		}

		private static IEdmModel GetEdmModel()
		{
			ODataConventionModelBuilder builder = new ODataConventionModelBuilder();

			builder.EntitySet<Employee>("Employees")
				.EntityType
				.Select()
				.Count()
				.Filter()
				.Filter(QueryOptionSetting.Disabled, "City")
				.Expand()
				.Select(SelectExpandType.Disabled, "Notes");

			builder.EntityType<Employee>().Ignore(p => p.Photo);
			builder.EntityType<Employee>().Ignore(p => p.PhotoPath);

			builder.EntitySet<Order>("Orders")
				.EntityType
				.Select();

			return builder.GetEdmModel();
		}
	}
}

// http://localhost:40000/odata/Employees
// http://localhost:40000/odata/Employees?$select=LastName,FirstName
// http://localhost:40000/odata/Employees(1)
// http://localhost:40000/odata/Employees(1)?$select=LastName,FirstName
// http://localhost:40000/odata/Employees(1)?$expand=Orders
// http://localhost:40000/odata/Employees(1)?$select=LastName,FirstName&$expand=Orders
// http://localhost:40000/odata/Employees(1)?$select=LastName,FirstName&$expand=Orders($select=OrderID)
