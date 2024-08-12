using Microsoft.EntityFrameworkCore;
using SampleOrdering.UserService.Domain;
using SampleOrdering.UserService.Domain.Shared.Users;
using SampleOrdering.UserService.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace SampleOrdering.UserService.EntityFrameworkCore.EntityFrameworkCore
{
    public class UserServiceDbContext : AbpDbContext<UserServiceDbContext>, IUserServiceDbContext
    {
        public UserServiceDbContext(DbContextOptions<UserServiceDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ConfigureOrderService();

            modelBuilder.Entity<User>(b =>
            {
                b.ToTable(UserServiceDbProperties.DbTablePrefix + "Users", UserServiceDbProperties.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Name).IsRequired().HasMaxLength(UserConstants.MaxNameLength);
                b.Property(x => x.Surname).IsRequired().HasMaxLength(UserConstants.MaxSurnameLength);
                b.Property(x => x.Email).IsRequired().HasMaxLength(UserConstants.MaxEmailLength);
                b.Property(x => x.Password).IsRequired().HasMaxLength(UserConstants.MaxPasswordLength);
                b.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(UserConstants.MaxPhoneNumberLength);
            });
        }
    }
}
