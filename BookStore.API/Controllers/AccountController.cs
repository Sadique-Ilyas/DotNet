using BookStore.API.Data;
using BookStore.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IAccountRepository _accountRepository;

		public AccountController(IAccountRepository accountRepository)
        {
			_accountRepository = accountRepository;
		}

		[HttpPost("signup")]
		public async Task<IActionResult> SignUp([FromBody] SignUp signupUser)
		{
			var result = await _accountRepository.SignUpAsync(signupUser);

			if(!result.Succeeded)
			{
				return Unauthorized();
			}

			return Ok(result.Succeeded);
		}

		[HttpPost("signin")]
		public async Task<IActionResult> SignIn([FromBody] SignIn signinUser)
		{
			var result = await _accountRepository.SignInAsync(signinUser);

			if (string.IsNullOrEmpty(result))
			{
				return Unauthorized();
			}

			return Ok(result);
		}
	}
}
