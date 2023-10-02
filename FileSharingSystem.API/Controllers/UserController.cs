using FileSharingSystem.Contract;
using FileSharingSystem.DTO;
using FileSharingSystem.Model.Models;
using FileSharingSystem.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileSharingSystem.API.Controllers
{
	
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;
		public UserController(IUserService userService)
		{
			_userService = userService;
		}
		[EnableCors("AllowLocalhost")]
        [HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> GetUserById(int userId, CancellationToken cancellationToken) 
		{
			var user = await _userService.GetUserById(userId, cancellationToken);
			

			if (user != null) 
			{
				return Ok(user);
			}
			return BadRequest();
		}
	}
}
