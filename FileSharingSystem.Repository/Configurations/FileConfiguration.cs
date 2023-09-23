using FileSharingSystem.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FileSharingSystem.DAL.Configurations
{
    public class FileConfiguration : IEntityTypeConfiguration<Model.Models.File>
    {
        public void Configure(EntityTypeBuilder<Model.Models.File> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Size)
                .IsRequired()
                .HasColumnName("Size")
                .HasColumnType("bigint");

            builder.Property(x => x.Attachment)
                .IsRequired()
                .HasColumnName("Attachment")
                .HasColumnType("varbinary(max)");

            builder.Property(x => x.Extension)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasOne<Folder>(f => f.Folder)
                .WithMany(x => x.Files)
                .HasForeignKey(f => f.FolderId);

        }
    }
}
