using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.OData.Routing;
using System.Web.OData.Routing.Conventions;

namespace Part11
{
	public class MyRoutingConvention : IODataRoutingConvention
	{
		public string SelectAction(ODataPath odataPath, HttpControllerContext controllerContext, ILookup<string, HttpActionDescriptor> actionMap)
		{
			throw new NotImplementedException();
		}

		public string SelectController(ODataPath odataPath, HttpRequestMessage request)
		{
			throw new NotImplementedException();
		}
	}

	public class MyRoutingConvention2 : NavigationSourceRoutingConvention
	{
		public override string SelectAction(ODataPath odataPath, HttpControllerContext controllerContext, ILookup<string, HttpActionDescriptor> actionMap)
		{
			throw new NotImplementedException();
		}
	}
}