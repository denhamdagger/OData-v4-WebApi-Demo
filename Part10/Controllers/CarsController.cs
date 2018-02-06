using Part10.DataSource;
using Part10.Models;
using System.Linq;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;

namespace Part10.Controllers
{
	public class CarsController : ODataController
	{
		private Repository _repo;

		public CarsController()
		{
			_repo = new Repository();
		}

		// OData/Cars
		[EnableQuery]
		public IQueryable<Car> Get()
		{
			return _repo.GetCars();
		}

		// OData/Cars(Make='Vauxhall', Model='Zafira')
		[EnableQuery]
		public Car Get([FromODataUri] string KeyMake, [FromODataUri] string KeyModel)
		{
			return _repo.GetCar(KeyMake, KeyModel);
		}

		// OData/Cars(Category='4x4')
		[EnableQuery]
		[ODataRoute("Cars(Category={Category})")]
		public IQueryable<Car> GetCarByCategory([FromODataUri]string Category)
		{
			return _repo.GetCars(Category);
		}
	}
}