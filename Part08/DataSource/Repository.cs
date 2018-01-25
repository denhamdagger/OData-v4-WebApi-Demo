using Part08.Models;
using System.Collections.Generic;
using System.Linq;

namespace Part08.DataSource
{
	public class Repository
	{
		private List<Car> _cars;

		public Repository()
		{
			_cars = new List<Car> {
				new Car {Make = "Vauxhall", Model = "Zafira", Colour = "Blue", Price = 20000.00},
				new Car {Make = "Vauxhall", Model = "Mokka", Colour = "Silver", Price = 18500.00},
				new Car {Make = "Ford", Model = "Focus", Colour = "Black", Price = 22000.00}
			};
		}

		public IQueryable<Car> GetCars()
		{
			return _cars.AsQueryable();
		}

		public Car GetCar(string make, string model)
		{
			return _cars.Where(p => p.Make == make && p.Model == model).FirstOrDefault();
		}
	}
}