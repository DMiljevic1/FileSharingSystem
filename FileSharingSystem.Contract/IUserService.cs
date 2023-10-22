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
        Task<GetUserResponse> GetUserById(int userId, CancellationToken cancellationToken);
		Task<AddUserResponse> AddUser(AddUserRequest userDto, CancellationToken cancellationToken);

	}
}
