using FileSharingSystem.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharingSystem.Contract
{
	public interface IUserRepository
	{
		Task<User> GetUserById(int userId, CancellationToken cancellationToken);
	}
}
