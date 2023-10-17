using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework_CodeFirst.Models
{
	[Table("Categories")]
	public class Category
	{
		[Key]
        public int CategoryId { get; set; }
		[Required]
        public string Name { get; set; }
    }
}
