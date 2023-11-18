using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_DatabaseFirst
{
	internal class Program
	{
		static void Main(string[] args)
		{
			NorthwindDBConnection dBContext = new NorthwindDBConnection();
			//var products = dBContext.Products.Where(x => x.Price > 25000).ToList();
			var products = from product in dBContext.Products where product.Price > 25000 select product;
			var productList = products.ToList();

			foreach(var product in productList )
			{
                Console.WriteLine($"#{product.ProductId} {product.Name} {product.Price} {product.Category.Name}");
            }
			Console.ReadLine();
		}
	}
}
