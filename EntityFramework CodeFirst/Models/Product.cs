using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework_CodeFirst.Models
{
    [Table("Products")]
	public class Product
	{
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
    }
}
