using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagementSystem.Web.Data.Configurations
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                 new IdentityRole
                 {
                     Id = "00b8e8af-c567-4a7b-a943-97b593d48e45",
                     Name = "Employee",
                     NormalizedName = "EMPLOYEE"
                 },
                 new IdentityRole
                 {
                     Id = "f8c0628b-b2aa-4d03-ace8-c6b3f7deebf6",
                     Name = "Supervisor",
                     NormalizedName = "SUPERVISOR"
                 },
                 new IdentityRole
                 {
                     Id = "c07eef0b-b610-4042-bc76-8f48c76d5a32",
                     Name = "Administrator",
                     NormalizedName = "ADMINISTRATOR"
                 }
            );
        }
    }
}
