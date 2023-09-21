using FileSharingSystem.DAL.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharingSystem.DAL.Repository
{
	public class UserRepository
	{
		private readonly FileSharingSystemDbContext _fileSharingSystemDbContext;
		public UserRepository(FileSharingSystemDbContext fileSharingSystemDbContext)
		{
			_fileSharingSystemDbContext = fileSharingSystemDbContext;
		}
	}
}
