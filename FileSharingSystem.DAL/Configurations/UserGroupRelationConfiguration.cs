using FileSharingSystem.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FileSharingSystem.DAL.Configurations
{
    public class UserGroupRelationConfiguration : IEntityTypeConfiguration<UserGroupRelation>
    {
        public void Configure(EntityTypeBuilder<UserGroupRelation> builder)
        {
            builder.HasKey(ug => new { ug.UserId, ug.GroupId });

            builder.HasOne<User>(ug => ug.User)
                .WithMany(u => u.UserGroupRelations)
                .HasForeignKey(u => u.UserId);

            builder.HasOne<Group>(ug => ug.Group)
                .WithMany(g => g.UserGroupRelations)
                .HasForeignKey(g => g.GroupId);

            
        }
    }
}
