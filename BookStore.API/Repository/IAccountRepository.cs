using BookStore.API.Data;
using Microsoft.AspNetCore.Identity;

namespace BookStore.API.Repository
{
	public interface IAccountRepository
	{
		Task<IdentityResult> SignUpAsync(SignUp signUpUser);
		Task<string> SignInAsync(SignIn signinUser);
	}
}