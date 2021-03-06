﻿using Microsoft.OData.Edm;
using Part09.Models;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace Part09
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

			_builder.EntitySet<Car>("Cars");

			return _builder.GetEdmModel();
		}
	}
}
