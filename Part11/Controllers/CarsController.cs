using Part11.DataSource;
using Part11.Models;
using System.Linq;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;

namespace Part11.Controllers
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
		[ODataRoute("")]
		public IQueryable<Car> GetAllCars()
		{
			return _repo.GetCars();
		}

		// OData/Cars(Make='Vauxhall', Model='Zafira')
		[ODataRoute("(Make={KeyMake}, Model={KeyModel})")]
		public Car Get([FromODataUri] string KeyMake, [FromODataUri] string KeyModel)
		{
			return _repo.GetCar(KeyMake, KeyModel);
		}

		// OData/Cars(Category='4x4')
		[ODataRoute("(Category={Category})")]
		public IQueryable<Car> GetCarByCategory([FromODataUri]string Category)
		{
			return _repo.GetCars(Category);
		}
	}
}