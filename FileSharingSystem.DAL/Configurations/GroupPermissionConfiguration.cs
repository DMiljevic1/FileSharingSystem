using FileSharingSystem.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharingSystem.DAL.Configurations
{
	public class GroupPermissionConfiguration
	{
		public void Configure(EntityTypeBuilder<GroupPermission> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedOnAdd();

			builder.Property(x => x.CreatePermission)
				.HasColumnType("bit");

			builder.Property(x => x.UploadPermission)
				.HasColumnType("bit");

			builder.Property(x => x.DeletePermission)
				.HasColumnType("bit");
		}
	}
}
