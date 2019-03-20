using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public sealed class DomainContext : DbContext
    {
        public DomainContext(DbContextOptions<DomainContext> contextOptions) : base(contextOptions)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.BuildObservedUser().BuildUserEntry();
            base.OnModelCreating(modelBuilder);
        }

    }

    public static class ModelBuilderExtensions
    {
        public static ModelBuilder BuildObservedUser(this ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<ObservedUser>();
            builder.HasKey(user => user.Id);
            builder.Property(user => user.ProfileId);
            builder.Property(user => user.Name);
            builder.Property(user => user.Surname);
            builder.HasMany(user => user.FriendEntries).WithOne(entry => entry.User);
            return modelBuilder;
        }

        public static ModelBuilder BuildUserEntry(this ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<FriendEntry>();
            builder.HasKey(entry => entry.Id);
            builder.Property(entry => entry.ProfileId);
            builder.Property(entry => entry.AddDate);
            builder.Property(entry => entry.IsDeleted);
            builder.Property(entry => entry.Male);
            builder.Property(entry => entry.ProfileLink);
            return modelBuilder;
        }
    }
}
