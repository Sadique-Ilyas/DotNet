using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Data
{
	public class SignIn
	{
		[Required, EmailAddress]
		public string? Email { get; set; }
		[Required]
		public string? Password { get; set; }
	}
}
