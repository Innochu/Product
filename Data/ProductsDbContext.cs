using Microsoft.EntityFrameworkCore;
using Product.Models;

namespace Product.Data
{
	public class ProductsDbContext : DbContext
	{
		public ProductsDbContext(DbContextOptions options) : base(options)
		{

		}

        public DbSet<ProductModels> Products { get; set; }
    }



}
