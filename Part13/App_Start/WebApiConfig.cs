using Microsoft.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.UriParser;
using Part13.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using System.Web.OData.Routing.Conventions;

namespace Part13
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

			builder.EntityType<Royalty>();
			builder.EntityType<Title>();

			builder.EntitySet<Title>("Titles");

			return builder.GetEdmModel();
		}
	}
}


