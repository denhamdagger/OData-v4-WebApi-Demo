using System.ComponentModel.DataAnnotations;

namespace Part11.Models
{
	public class Car
	{
		public string Make { get; set; }
		public string Model { get; set; }
		public string Colour { get; set; }
		public double Price { get; set; }
		public string Category { get; set; }
	}
}