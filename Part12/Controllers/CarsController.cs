using Part12.DataSource;
using Part12.Models;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;

namespace Part12.Controllers
{
	[ODataRoutePrefix("Cars")]
	public class VehicleController : ODataController
	{
		private Repository _repo;

		public VehicleController()
		{
			_repo = new Repository();
		}

		// OData/Cars
		[EnableQuery]
		[ODataRoute("")]
		public IQueryable<Car> GetAllCars()
		{
			return _repo.GetCars();
		}

		// OData/Cars(Make='Vauxhall', Model='Zafira')
		[EnableQuery]
		[ODataRoute("(Make={KeyMake}, Model={KeyModel})")]
		public Car Get([FromODataUri] string KeyMake, [FromODataUri] string KeyModel)
		{
			return _repo.GetCar(KeyMake, KeyModel);
		}

		// OData/Cars(Category='4x4')
		[EnableQuery]
		[ODataRoute("(Category={Category})")]
		public IQueryable<Car> GetCarByCategory([FromODataUri]string Category)
		{
			return _repo.GetCars(Category);
		}

		// OData/Cars(Make='Vauxhall', Model='Zafira')/Price
		[ODataRoute("(Make={KeyMake}, Model={KeyModel})/Price")]
		[ODataRoute("(Make={KeyMake}, Model={KeyModel})/Price/$value")]
		public IHttpActionResult GetCarPrice([FromODataUri] string KeyMake, [FromODataUri] string KeyModel)
		{
			var _car = _repo.GetCar(KeyMake, KeyModel);
			if (_car == null)
			{
				return NotFound();
			}

			return Ok(_car.Price);
		}
	}
}