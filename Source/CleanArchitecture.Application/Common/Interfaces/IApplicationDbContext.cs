using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Desire> Desires { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<bool> CheckDbConnection();
    }
}
