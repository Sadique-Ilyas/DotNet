using Microsoft.AspNetCore.Identity;

namespace BookStore.API.Data
{
	public class ApplicationUser: IdentityUser
	{
		public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}