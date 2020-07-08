using DotNetCoreIdentity.Mvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreIdentity.Mvc.Data
{
    public class ApplicationDbContext
 : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    //: IdentityDbContext<ApplicationUser, IdentityRole<int>,int,IdentityUserClaim<int>,IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>,IdentityUserToken<int>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<IdentityUser>(entity => entity.Property(m => m.Id).HasMaxLength(85));
            //builder.Entity<IdentityUser>(entity => entity.Property(m => m.NormalizedEmail).HasMaxLength(85));
            //builder.Entity<IdentityUser>(entity => entity.Property(m => m.NormalizedUserName).HasMaxLength(85));

            //builder.Entity<IdentityRole<int>>(entity => entity.Property(m => m.Id).HasMaxLength(85));
            //builder.Entity<IdentityRole<int>>(entity => entity.Property(m => m.NormalizedName).HasMaxLength(85));

            //builder.Entity<IdentityUserLogin<int>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(85));
            //builder.Entity<IdentityUserLogin<int>>(entity => entity.Property(m => m.ProviderKey).HasMaxLength(85));
            //builder.Entity<IdentityUserLogin<int>>(entity => entity.Property(m => m.UserId).HasMaxLength(85));
            //builder.Entity<IdentityUserLogin<int>>().HasKey(x => x.ProviderKey);

            //builder.Entity<IdentityUserRole<int>>(entity => entity.Property(m => m.UserId).HasMaxLength(85));

            //builder.Entity<IdentityUserRole<int>>(entity => entity.Property(m => m.RoleId).HasMaxLength(85));

            //builder.Entity<IdentityUserToken<int>>(entity => entity.Property(m => m.UserId).HasMaxLength(85));
            //builder.Entity<IdentityUserToken<int>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(85));
            //builder.Entity<IdentityUserToken<int>>(entity => entity.Property(m => m.Name).HasMaxLength(85));

            //builder.Entity<IdentityUserClaim<int>>(entity => entity.Property(m => m.Id).HasMaxLength(85));
            //builder.Entity<IdentityUserClaim<int>>(entity => entity.Property(m => m.UserId).HasMaxLength(85));
            //builder.Entity<IdentityRoleClaim<int>>(entity => entity.Property(m => m.Id).HasMaxLength(85));
            //builder.Entity<IdentityRoleClaim<int>>(entity => entity.Property(m => m.RoleId).HasMaxLength(85));


            //builder.Entity<ApplicationUser>(b =>
            //{
            //    // Each User can have many UserClaims
            //    b.HasMany(e => e.Claims)
            //        .WithOne()
            //        .HasForeignKey(uc => uc.UserId)
            //        .IsRequired();

            //    // Each User can have many UserLogins
            //    b.HasMany(e => e.Logins)
            //        .WithOne()
            //        .HasForeignKey(ul => ul.UserId)
            //        .IsRequired();

            //    // Each User can have many UserTokens
            //    b.HasMany(e => e.Tokens)
            //        .WithOne()
            //        .HasForeignKey(ut => ut.UserId)
            //        .IsRequired();

            //    // Each User can have many entries in the UserRole join table
            //    b.HasMany(e => e.UserRoles)
            //        .WithOne()
            //        .HasForeignKey(ur => ur.UserId)
            //        .IsRequired();
            //});

        }

        public DbSet<Album> Albums { get; set; }
    }
}
