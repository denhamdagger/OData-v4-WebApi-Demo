using Part09.DataSource;
using Part09.Models;
using System.Linq;
using System.Web.OData;

namespace Part09.Controllers
{
	public class CarsController : ODataController
	{
		private Repository _repo;

		public CarsController()
		{
			_repo = new Repository();
		}

		// OData/Cars
		public IQueryable<Car> Get()
		{
			return _repo.GetCars();
		}

		// OData/Cars(Make='Vauxhall', Model='Zafira')
		public Car Get([FromODataUri] string KeyMake, [FromODataUri] string KeyModel)
		{
			return _repo.GetCar(KeyMake, KeyModel);
		}
	}
}