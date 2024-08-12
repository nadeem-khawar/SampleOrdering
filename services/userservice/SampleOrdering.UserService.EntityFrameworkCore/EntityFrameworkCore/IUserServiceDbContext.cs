using Microsoft.EntityFrameworkCore;
using SampleOrdering.UserService.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;

namespace SampleOrdering.UserService.EntityFrameworkCore.EntityFrameworkCore
{
    public interface IUserServiceDbContext : IEfCoreDbContext
    {
        DbSet<User> Users { get; }
    }
}
