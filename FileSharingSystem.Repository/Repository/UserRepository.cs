using FileSharingSystem.Contract;
using FileSharingSystem.DAL.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharingSystem.DAL.Repository
{
	public class UserRepository : IUserRepository
	{
		private readonly FileSharingSystemDbContext _dbContext;
		public UserRepository(FileSharingSystemDbContext dbContext)
		{
			_dbContext = dbContext;
		}
	}
}
