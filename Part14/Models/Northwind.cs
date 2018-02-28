namespace Part14.Models
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class Northwind : DbContext
	{
		public Northwind()
			: base("name=Northwind")
		{
		}

		public virtual DbSet<Employee> Employees { get; set; }
		public virtual DbSet<Order> Orders { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Employee>()
				.HasMany(e => e.Employees1)
				.WithOptional(e => e.Employee1)
				.HasForeignKey(e => e.ReportsTo);

			modelBuilder.Entity<Order>()
				.Property(e => e.CustomerID)
				.IsFixedLength();

			modelBuilder.Entity<Order>()
				.Property(e => e.Freight)
				.HasPrecision(19, 4);
		}
	}
}
