using Microsoft.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.UriParser;
using Part10.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using System.Web.OData.Routing.Conventions;

namespace Part10
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// OData Routing
			var model = GetEdmModel();

			config.MapODataServiceRoute("OData", "OData", b => b
				.AddService<IEdmModel>(ServiceLifetime.Singleton, s => model)
				.AddService<IEnumerable<IODataRoutingConvention>>(ServiceLifetime.Singleton, s => ODataRoutingConventions.CreateDefaultWithAttributeRouting("OData", config))
				.AddService<ODataUriResolver>(ServiceLifetime.Singleton, s => new AlternateKeysODataUriResolver(model))
			);

		}

		private static IEdmModel GetEdmModel()
		{
			EdmModel _builder = new EdmModel();

			// Create Car Entity
			EdmEntityType car = new EdmEntityType("Part10.Models", "Car");
			car.AddKeys(car.AddStructuralProperty("Make", EdmPrimitiveTypeKind.String), car.AddStructuralProperty("Model", EdmPrimitiveTypeKind.String));
			car.AddStructuralProperty("Colour", EdmPrimitiveTypeKind.String);
			car.AddStructuralProperty("Price", EdmPrimitiveTypeKind.Double);
			var cat = car.AddStructuralProperty("Category", EdmPrimitiveTypeKind.String, false);
			_builder.AddAlternateKeyAnnotation(car, new Dictionary<string, IEdmProperty>
			{
				{"Category", cat}
			});
			_builder.AddElement(car);

			// Create Container
			EdmEntityContainer container = new EdmEntityContainer("Part10.Models", "Container");

			// Add the Cars Entity into the Container
			EdmEntitySet cars = container.AddEntitySet("Cars", car);
			_builder.AddElement(container);

			return _builder;
		}
	}
}

