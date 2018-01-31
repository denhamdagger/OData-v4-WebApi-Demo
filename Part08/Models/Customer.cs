using System.ComponentModel.DataAnnotations;

namespace Part08.Models
{
	public class Customer
	{
		[Key]
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public int Age { get; set; }
	}
}