using FileSharingSystem.DTO;
using FileSharingSystem.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharingSystem.Contract
{
	public interface IUserService
	{
        Task<UserDto> GetUserById(int userId, CancellationToken cancellationToken);
		Task AddUser(UserDto userDto, CancellationToken cancellationToken);

	}
}
