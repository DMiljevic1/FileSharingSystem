using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileSharingSystem.API.Common
{
	[Route("api/[controller]")]
	[ApiController]
	[EnableCors("AllowLocalhost")]
	public class BaseApiController : ControllerBase
	{
	}
}
