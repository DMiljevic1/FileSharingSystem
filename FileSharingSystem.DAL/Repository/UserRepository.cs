using FileSharingSystem.Contract;
using FileSharingSystem.DAL.DatabaseContext;
using FileSharingSystem.Model.Models;
using Microsoft.EntityFrameworkCore;


namespace FileSharingSystem.DAL.Repository
{
	public class UserRepository : IUserRepository
	{
		private readonly FileSharingSystemDbContext _dbContext;
		public UserRepository(FileSharingSystemDbContext dbContext)
		{
			_dbContext = dbContext;
		}

        public async Task<User> GetUserById(int userId, CancellationToken cancellationToken)
        {
			try
			{
				return await _dbContext.Users.FirstOrDefaultAsync<User>(u => u.Id == userId, cancellationToken);
			}
			catch (Exception)
			{
				throw;
			}
        }

		public async Task AddUser(User user, CancellationToken cancellationToken)
		{
			await _dbContext.Users.AddAsync(user);
			await _dbContext.SaveChangesAsync();
		}
    }
}
