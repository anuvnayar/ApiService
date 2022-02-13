using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Microsoft.EntityFrameworkCore;


namespace ApiService.Data
{
public class DataContext:DbContext
{
      public DataContext()
    {
    }
    
    public DbSet<AppUser> AppUsers { get; set; }
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppUser>(entity =>
        {
            //entity.HasKey(e => e.UserId);
            entity.Property(e => e.Id);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.Age).HasMaxLength(250);
            entity.Property(e => e.State).HasMaxLength(250);
        });
    }
}
}