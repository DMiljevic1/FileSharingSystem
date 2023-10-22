using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure;
using FileSharingSystem.Contract;
using FileSharingSystem.DTO;
using FileSharingSystem.Model.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;

namespace FileSharingSystem.Service
{
	public class AuthService : IAuthService
	{
		private readonly IAuthRepository _authRepository;
		private readonly IConfiguration _config;
		private readonly IHashService _hashService;
		private readonly ILogger<AuthService> _logger;
		public AuthService (IAuthRepository authRepository, IConfiguration config, IHashService hashService, ILogger<AuthService> logger)
		{
			_authRepository = authRepository;
			_config = config;
			_hashService = hashService;
			_logger = logger;
		}
		public async Task<User?> Authenticate(LoginRequest request, CancellationToken cancellationToken)
		{
			return await _authRepository.GetUserByEmailAndPassword(request.Email, request.Password, cancellationToken);
		}

		public async Task<LoginResponse> Generate(LoginRequest request, CancellationToken cancellationToken)
		{
			var response = new LoginResponse();
			request.Password = _hashService.HashUserPassword(request.Password);
			var user = await Authenticate(request, cancellationToken);
			if(user != null)
			{
				var token = GenerateToken(user);
				response.Success = true;
				response.Message = "Login was successfull.";
				response.Token = new JwtSecurityTokenHandler().WriteToken(token);
				_logger.LogDebug("User login: {@request} {@response}", request, response);
			}
			else
			{
				response.Success = false;
				response.Message = "Login failed.";
				_logger.LogError("User login failed: {@request} {@response}", request, response);
			}
			return response;
		}

		private JwtSecurityToken GenerateToken(User user)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
			var claims = new[]
			{
					new Claim(ClaimTypes.Rsa, user.Id.ToString()),
					new Claim(ClaimTypes.NameIdentifier, user.Email)
				};
			var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"],
				claims,
				expires: DateTime.UtcNow.AddMinutes(double.Parse(_config["Jwt:Exp"])),
				signingCredentials: credentials);
			return token;
		}
	}
}
