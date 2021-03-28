using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;

namespace CleanArchitecture.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Desire> Desires { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<User> Users { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public async Task<bool> CheckDbConnection()
        {
            return await Database.CanConnectAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<User>()
                .HasMany(r => r.Desires)
                .WithOne(m => m.User)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
