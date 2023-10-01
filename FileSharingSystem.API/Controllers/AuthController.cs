using FileSharingSystem.Contract;
using FileSharingSystem.DTO;
using FileSharingSystem.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileSharingSystem.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService _authService;
		public AuthController (IAuthService authService)
		{
			_authService = authService;
		}

		[EnableCors("AllowLocalhost")]
		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Login([FromBody] UserLogin userLogin, CancellationToken cancellationToken)
		{
			var loginResponse = await _authService.Generate(userLogin, cancellationToken);
			if (loginResponse.Success)
				return Ok(loginResponse);
			else
				return BadRequest();
		}
	}
}
