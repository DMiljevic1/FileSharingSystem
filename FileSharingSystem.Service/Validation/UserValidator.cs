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
			RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("Email cannot be empty.");
			RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Password cannot be empty.");
			RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Passwords must match.");
			RuleFor(x => x.FirstName).NotNull().NotEmpty().WithMessage("First name cannot be empty.");
			RuleFor(x => x.LastName).NotNull().NotEmpty().WithMessage("Last name cannot be empty.");
			RuleFor(x => x.DateOfBirth).NotNull().WithMessage("Date of birth cannot be empty.");
		}
	}
}
