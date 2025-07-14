using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole 
                {
                    Id = "00b8e8af-c567-4a7b-a943-97b593d48e45",
                    Name = "Employee",
                    NormalizedName= "EMPLOYEE"
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
                });

            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                    Id = "5d569588-f4ec-4a9a-8519-cf7318f3d24d",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    UserName = "admin@localhost.com",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true,
                    FirstName = "Default",
                    LastName = "Default",
                    DateOfBirth = new DateOnly(1950,12,01) 
                });

            builder.Entity <IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> 
                { 
                     RoleId = "c07eef0b-b610-4042-bc76-8f48c76d5a32",
                     UserId = "5d569588-f4ec-4a9a-8519-cf7318f3d24d"
                });
        }

        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
        public DbSet<Period> Periods { get; set; }
    }
}
