using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCore_CodeFirst.Models
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
