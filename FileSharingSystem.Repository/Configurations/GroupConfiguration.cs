using FileSharingSystem.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FileSharingSystem.DAL.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired().
                HasMaxLength(64);

            builder.Property(x => x.CreatePermission)
                .HasColumnType("bit")
                .HasDefaultValue("((1))");

            builder.Property(x => x.UploadPermission)
                .HasColumnType("bit").
                HasDefaultValueSql("((1))");

            builder.Property(x => x.DeletePermission)
                .HasColumnType("bit")
                .HasDefaultValueSql("((1))");
        }
    }
}
