using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Part13.Models
{
	public class Title
	{
		public int Id { get; set; }
		public string Name { get; set; }

		[ForeignKey("Royalty")]
		public int TitleId { get; set; }
	}
}