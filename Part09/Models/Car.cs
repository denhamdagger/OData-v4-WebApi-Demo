using System.ComponentModel.DataAnnotations;

namespace Part09.Models
{
	public class Car
	{
		[Key]
		public string Make { get; set; }

		[Key]
		public string Model { get; set; }

		public string Colour { get; set; }

		public double Price { get; set; }
	}
}