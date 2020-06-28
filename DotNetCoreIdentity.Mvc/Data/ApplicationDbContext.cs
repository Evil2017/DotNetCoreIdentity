using DotNetCoreIdentity.Mvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreIdentity.Mvc.Data
{
    public class ApplicationDbContext
     //: IdentityDbContext<ApplicationUser, ApplicationRole, int>
     : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserClaim, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>,IdentityUserToken<int>>
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

            //builder.Entity<UserLogin>(entity => entity.HasKey(m => m.UserId).HasName("主键"));
            //builder.Entity<UserLogin>(entity => entity.Property(m => m.UserId).HasMaxLength(36));
            //builder.Entity<UserLogin>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(85));
            //builder.Entity<UserLogin>(entity => entity.Property(m => m.ProviderKey).HasMaxLength(85));
            //builder.Entity<IdentityUserRole<int>>(entity => entity.Property(m => m.UserId).HasMaxLength(36));

            //builder.Entity<IdentityUserRole<int>>(entity => entity.Property(m => m.RoleId).HasMaxLength(36));

            //builder.Entity<IdentityUserToken<int>>(entity => entity.Property(m => m.UserId).HasMaxLength(36));
            //builder.Entity<IdentityUserToken<int>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(85));
            //builder.Entity<IdentityUserToken<int>>(entity => entity.Property(m => m.Name).HasMaxLength(85));

            //builder.Entity<IdentityUserClaim<int>>(entity => entity.Property(m => m.Id).HasMaxLength(36));
            //builder.Entity<IdentityUserClaim<int>>(entity => entity.Property(m => m.UserId).HasMaxLength(36));
            //builder.Entity<IdentityRoleClaim<int>>(entity => entity.Property(m => m.Id).HasMaxLength(36));
            //builder.Entity<IdentityRoleClaim<int>>(entity => entity.Property(m => m.RoleId).HasMaxLength(36));


       
            builder.Entity<ApplicationUser>(b =>
            {
                // Each User can have many UserClaims
                b.HasMany(e => e.Claims)
                    .WithOne()
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                // Each User can have many UserLogins
                b.HasMany(e => e.Logins)
                    .WithOne()
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                // Each User can have many UserTokens
                b.HasMany(e => e.Tokens)
                    .WithOne()
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne()
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
            builder.ApplyConfiguration(new AlbumConfiguration());
        }

        public DbSet<Album> Albums { get; set; }

        //public override DbSet<Role> Roles { get; set; }

        //public override DbSet<User> Users { get; set; }
        public DbSet<Test> Tests { get; set; }
    }
}
