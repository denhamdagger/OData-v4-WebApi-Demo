using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Part13.Models
{
	public class Royalty
	{
		public int TitleId { get; set; }
		public int LowRange { get; set; }
		public int HighRange { get; set; }
		public int Percentage { get; set; }
	}
}