using Part08.DataSource;
using Part08.Models;
using System.Linq;
using System.Web.OData;

namespace Part08.Controllers
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
	}
}