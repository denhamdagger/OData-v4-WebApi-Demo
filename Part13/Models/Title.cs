using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.OData.Builder;

namespace Part13.Models
{
	public class Title
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Contained]
		public List<Royalty> Royalties { get; set; }
	}
}