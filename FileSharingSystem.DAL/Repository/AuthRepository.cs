using FileSharingSystem.Contract;
using FileSharingSystem.DAL.DatabaseContext;
using FileSharingSystem.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharingSystem.DAL.Repository
{
	public class AuthRepository : IAuthRepository
	{
		private readonly FileSharingSystemDbContext _dbContext;
		public AuthRepository (FileSharingSystemDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<User> GetUserByUsernameAndPassword(string username, string password, CancellationToken cancellationToken)
		{
			try
			{
				return await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password, cancellationToken);
			}
			catch (Exception e)
			{
				throw;
			}
		}
	}
}
