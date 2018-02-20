using Part13.Models;
using System.Collections.Generic;
using System.Linq;

namespace Part12.DataSource
{
	public class Repository
	{
		private List<Title> _titles;

		public Repository()
		{
			_titles = new List<Title> {
				new Title {Id = 1, Name = "Lets Get Out of Here", Royalties = new List<Royalty> {
					new Royalty {Id = 1, TitleId = 1, LowRange = 0, HighRange = 100, Percentage = 5},
					new Royalty {Id = 2, TitleId = 1, LowRange = 101, HighRange = 1000, Percentage = 10},
					new Royalty {Id = 3, TitleId = 1, LowRange = 1001, HighRange = 10000, Percentage = 15}
				}},
				new Title {Id = 2, Name = "From Here to There", Royalties = new List<Royalty> {
					new Royalty {Id = 4, TitleId = 2, LowRange = 0, HighRange = 500, Percentage = 10},
					new Royalty {Id = 5, TitleId = 2, LowRange = 501, HighRange = 1000, Percentage = 15},
					new Royalty {Id = 6, TitleId = 2, LowRange = 1001, HighRange = 10000, Percentage = 20}
				}},
				new Title {Id = 3, Name = "Return of the War Hero", Royalties = new List<Royalty> {
					new Royalty {Id = 7, TitleId = 3, LowRange = 0, HighRange = 100, Percentage = 5},
					new Royalty {Id = 8, TitleId = 3, LowRange = 101, HighRange = 10000, Percentage = 10}
				}}
			};
		}

		public IQueryable<Title> GetTitles()
		{
			return _titles.AsQueryable();
		}

		public Title GetTitle(string Id)
		{
			return _titles.Where(p => p.Id == int.Parse(Id)).FirstOrDefault();
		}

		public IQueryable<Royalty> GetRoyalties(string Id)
		{
			var _title = _titles.Where(p => p.Id == int.Parse(Id)).FirstOrDefault();

			return _title.Royalties.AsQueryable();
		}

		public Royalty GetRoyalty(string Id, string Key)
		{
			var _title = _titles.Where(p => p.Id == int.Parse(Id)).FirstOrDefault();
			var _royalty = _title.Royalties.Where(p => p.Id == int.Parse(Key)).FirstOrDefault();

			return _royalty;
		}
	}
}