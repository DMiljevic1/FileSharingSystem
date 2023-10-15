using AutoMapper;
using FileSharingSystem.Contract;
using FileSharingSystem.DTO;
using FileSharingSystem.Model.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
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
		private readonly IValidator<UserDto> _validator;
		public UserService(IUserRepository userRepository, IMapper mapper, IHashService hashService, IValidator<UserDto> validator)
		{
			_userRepository = userRepository;
			_mapper = mapper;
			_hashService = hashService;
			_validator = validator;
		}

        public async Task<UserDto> GetUserById(int userId, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(userId, cancellationToken);
			return _mapper.Map<User,UserDto>(user);
        }

		public async Task AddUser(UserDto userDto, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(userDto, cancellationToken);
			if(validationResult.IsValid)
			{
				userDto.Password = _hashService.HashUserPassword(userDto.Password);
				var user = _mapper.Map<UserDto, User>(userDto);
				await _userRepository.AddUser(user, cancellationToken);
			}
		}
    }
}
