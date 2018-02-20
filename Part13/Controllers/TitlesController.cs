using Part12.DataSource;
using Part13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;

namespace Part13.Controllers
{
	public class TitlesController :ODataController
	{
		private Repository _repo;

		public TitlesController()
		{
			_repo = new Repository();
		}

		// OData/Titles
		[ODataRoute("Titles")]
		public IQueryable<Title> Get()
		{
			return _repo.GetTitles();
		}

		// OData/Titles(Id)
		[ODataRoute("Titles({Id})")]
		public Title Get([FromODataUri] string Id)
		{
			return _repo.GetTitle(Id);
		}

		// OData/Titles(Id)/Royalties
		[ODataRoute("Titles({Id})/Royalties")]
		public IQueryable<Royalty> GetRoyaltiesForTitle([FromODataUri] string Id)
		{
			return _repo.GetRoyalties(Id);
		}

		// OData/Titles(Id)/Royalties(Id)
		[ODataRoute("Titles({Id})/Royalties({Key})")]
		public Royalty GetRoyaltyForTitle([FromODataUri] string Id, [FromODataUri] string Key)
		{
			return _repo.GetRoyalty(Id, Key);
		}
	}
}