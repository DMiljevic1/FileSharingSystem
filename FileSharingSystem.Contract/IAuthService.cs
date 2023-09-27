using FileSharingSystem.DTO;
using FileSharingSystem.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharingSystem.Contract
{
	public interface IAuthService
	{
		Task<User> Authenticate(UserLogin userLogin, CancellationToken cancellationToken);
		Task<LoginResponse> Generate(UserLogin userLogin, CancellationToken cancellationToken);
	}
}
