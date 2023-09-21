using FileSharingSystem.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharingSystem.DAL.DatabaseContext
{
	public class FileSharingSystemDbContext : DbContext
	{
		public FileSharingSystemDbContext(DbContextOptions<FileSharingSystemDbContext> dbContextOptions) : base(dbContextOptions) { }

		public DbSet<User> Users {  get; set; }
		public DbSet<Group> Groups { get; set; }
		public DbSet<Folder> Folders { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<Model.Models.File> Files { get; set; }
		public DbSet<UserGroupRelation> UserGroupRelations { get; set; }
	}
}
