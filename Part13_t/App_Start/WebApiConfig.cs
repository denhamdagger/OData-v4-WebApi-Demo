using Microsoft.OData.Edm;
using Part13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace Part13
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// OData Routing
			config.MapODataServiceRoute("OData", "OData", GetEdmModel());
		}

		private static IEdmModel GetEdmModel()
		{
			ODataConventionModelBuilder _builder = new ODataConventionModelBuilder();

			_builder.EntitySet<Title>("Titles");

			return _builder.GetEdmModel();
		}
	}
}
