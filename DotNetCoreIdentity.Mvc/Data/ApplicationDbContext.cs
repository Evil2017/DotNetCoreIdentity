using DotNetCoreIdentity.Mvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreIdentity.Mvc.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    //: IdentityDbContext<User, Role, int, IdentityUserClaim<int>,IdentityUserRole<int>, UserLogin,IdentityRoleClaim<int>,IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            //builder.Entity<IdentityUser>(entity => entity.Property(m => m.Id).HasMaxLength(36));
            //builder.Entity<IdentityUser>(entity => entity.Property(m => m.NormalizedEmail).HasMaxLength(85));
            //builder.Entity<IdentityUser>(entity => entity.Property(m => m.NormalizedUserName).HasMaxLength(85));

            //builder.Entity<IdentityRole>(entity => entity.Property(m => m.Id).HasMaxLength(36));
            //builder.Entity<IdentityRole>(entity => entity.Property(m => m.NormalizedName).HasMaxLength(85));

            builder.Entity<IdentityUserLogin<int>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(85));
            builder.Entity<IdentityUserLogin<int>>(entity => entity.Property(m => m.ProviderKey).HasMaxLength(85));
            builder.Entity<IdentityUserLogin<int>>(entity => entity.Property(m => m.UserId).HasMaxLength(36));
            //builder.Entity<IdentityUserRole<int>>(entity => entity.Property(m => m.UserId).HasMaxLength(36));

            //builder.Entity<IdentityUserRole<int>>(entity => entity.Property(m => m.RoleId).HasMaxLength(36));

            builder.Entity<IdentityUserToken<int>>(entity => entity.Property(m => m.UserId).HasMaxLength(36));
            builder.Entity<IdentityUserToken<int>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(85));
            builder.Entity<IdentityUserToken<int>>(entity => entity.Property(m => m.Name).HasMaxLength(85));

            //builder.Entity<IdentityUserClaim<int>>(entity => entity.Property(m => m.Id).HasMaxLength(36));
            //builder.Entity<IdentityUserClaim<int>>(entity => entity.Property(m => m.UserId).HasMaxLength(36));
            //builder.Entity<IdentityRoleClaim<int>>(entity => entity.Property(m => m.Id).HasMaxLength(36));
            //builder.Entity<IdentityRoleClaim<int>>(entity => entity.Property(m => m.RoleId).HasMaxLength(36));
        }

        //public override DbSet<Role> Roles { get; set; }

        //public override DbSet<User> Users { get; set; }
        public DbSet<Test> Tests { get; set; }
    }
}
