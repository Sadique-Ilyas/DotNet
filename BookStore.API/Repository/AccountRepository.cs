using BookStore.API.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookStore.API.Repository
{
	public class AccountRepository : IAccountRepository
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly IConfiguration _configuration;

		public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_configuration = configuration;
		}

		public async Task<IdentityResult> SignUpAsync(SignUp signUpUser)
		{
			var user = new ApplicationUser()
			{
				FirstName = signUpUser.FirstName,
				LastName = signUpUser.LastName,
				Email = signUpUser.Email,
				UserName = signUpUser.Email
			};

			return await _userManager.CreateAsync(user, signUpUser.Password);
		}

		public async Task<string> SignInAsync(SignIn signinUser)
		{
			var result = await _signInManager.PasswordSignInAsync(signinUser.Email, signinUser.Password, false, false);

			if(!result.Succeeded)
			{
				return null;
			}

			var authClaims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, signinUser.Email),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
			};
			var authSignInKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:SecretKey"]));

			var token = new JwtSecurityToken(
				issuer: _configuration["JWT:ValidIssuer"],
				audience: _configuration["JWT:ValidAudience"],
				expires: DateTime.Now.AddMinutes(30),
				claims: authClaims,
				signingCredentials: new SigningCredentials(authSignInKey, SecurityAlgorithms.HmacSha256Signature)
			);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
