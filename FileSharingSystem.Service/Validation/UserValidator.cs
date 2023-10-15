using FileSharingSystem.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharingSystem.Service.Validation
{
	public class UserValidator : AbstractValidator<UserDto>
	{
		public UserValidator() 
		{
			RuleFor(x => x.Email).NotNull().NotEmpty();
			RuleFor(x => x.Password).NotNull().NotEmpty();
			RuleFor(x => x.Password).Equal(x => x.ConfirmPassword);
			RuleFor(x => x.FirstName).NotNull().NotEmpty();
			RuleFor(x => x.LastName).NotNull().NotEmpty();
			RuleFor(x => x.DateOfBirth).NotNull();
		}
	}
}
