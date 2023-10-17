using AutoMapper;
using FileSharingSystem.Contract;
using FileSharingSystem.DTO;
using FileSharingSystem.Model.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharingSystem.Service
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;
		private readonly IHashService _hashService;
		private readonly IValidator<AddUserRequest> _validator;
		private readonly ILogger<UserService> _logger;
		public UserService(IUserRepository userRepository, IMapper mapper, IHashService hashService, IValidator<AddUserRequest> validator, ILogger<UserService> logger)
		{
			_userRepository = userRepository;
			_mapper = mapper;
			_hashService = hashService;
			_validator = validator;
			_logger = logger;
		}

        public async Task<AddUserRequest> GetUserById(int userId, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(userId, cancellationToken);
			return _mapper.Map<User,AddUserRequest>(user);
        }

		public async Task<AddUserResponse> AddUser(AddUserRequest request, CancellationToken cancellationToken)
		{
			var response = new AddUserResponse();
			request.Password = _hashService.HashUserPassword(request.Password);
			request.ConfirmPassword = _hashService.HashUserPassword(request.ConfirmPassword);
			var validationResult = await _validator.ValidateAsync(request, cancellationToken);
			if (validationResult.IsValid)
			{
				var user = _mapper.Map<AddUserRequest, User>(request);
				await _userRepository.AddUser(user, cancellationToken);
				response.Success = true;
				response.Message = "User created successfully.";
				_logger.LogDebug("Add user: {@request} {@response}", request, response);
			}
			else
			{
				response.Success = false;
				response.Message = validationResult.ToString().Replace("\r\n", " ");
				_logger.LogError("Add user failed: {@request} {@response}", request, response);
			}
			return response;
		}
    }
}
