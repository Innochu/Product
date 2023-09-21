using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product.Data;
using Product.Models;

namespace Product.Controllers
{
	[ApiController]  //this should be assigned to class that searves as an Api controller which means it's responsible for handling HTTP requests and returning HTTP responses.
	[Route ("api/[controller]")]  //The [Route] attribute is used to define the routing template for the API controller.
	public class ProductController : Controller
	{
		private readonly ProductsDbContext _productsDbContext;

		public ProductController(ProductsDbContext productsDbContext)
        {
			_productsDbContext = productsDbContext;
		}
        [HttpGet]
		public async Task<IActionResult> Getproduct()
		{
			return Ok(await _productsDbContext.Products.ToListAsync());
			//from my Dbcontext class, go to products table and return a list, 
			//add the Ok() to prevent  conversion error
			//return View();
		}

		[HttpPost]
		public async  Task<IActionResult>  AddProductRequest(AddProductRequest addProductRequest)
		{
			var productmodels = new ProductModels()
			{
				Id = Guid.NewGuid(),
				ProductName = addProductRequest.ProductName,
				UnitPrice = addProductRequest.UnitPrice,
				ProductCategory = addProductRequest.ProductCategory,
				Status = addProductRequest.Status,

			};

			//inject the DBContext, go to the table from DBset i.e Contacts and add all parameters asynchronously
			await _productsDbContext.Products.AddAsync(productmodels);
			await _productsDbContext.SaveChangesAsync();                           //save all changes async


			return Ok(productmodels);                                                // return contact with an Ok response
		}
	}
}
