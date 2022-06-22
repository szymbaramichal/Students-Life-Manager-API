using Microsoft.EntityFrameworkCore;
using SLM.Data.Entities;

namespace SLM.Data;

public class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions opt) : base(opt)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseNpgsql("Server=localhost;Port=5432;Database=user;Uid=user;Pwd=passwd123!");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoEntity>()
            .Property(todo => todo.TodoType)
            .HasConversion<int>();
    }

    public DbSet<TodoEntity> Todos { get; set; }
}

