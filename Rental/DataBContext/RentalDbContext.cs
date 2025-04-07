using Microsoft.EntityFrameworkCore;
using Rental.Models;

namespace Rental.DataBContext
{
    public class RentalDbContext : DbContext
    {
        // DbSet для каждой сущности
        public DbSet<User> User { get; set; }
        public DbSet<Tool> Tool { get; set; }
        public DbSet<Order> Order { get; set; }

        // Конструктор для передачи опций контекста
        public RentalDbContext(DbContextOptions<RentalDbContext> options)
            : base(options)
        {
            // Пустой конструктор, так как все настройки выполняются через Dependency Injection
        }

        //// Настройка модели
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    // Настройка связи между Order и User (один-ко-многим)
        //    modelBuilder.Entity<Order>()
        //        .HasOne(o => o.User) // У заказа есть один пользователь
        //        .WithMany(u => u.Orders) // У пользователя может быть много заказов
        //        .HasForeignKey(o => o.UserId) // Внешний ключ в таблице Orders
        //        .OnDelete(DeleteBehavior.Restrict); // Ограничение на каскадное удаление

        //    // Настройка связи между Order и Tool (один-ко-многим)
        //    modelBuilder.Entity<Order>()
        //        .HasOne(o => o.Tool) // У заказа есть один инструмент
        //        .WithMany(t => t.Orders) // У инструмента может быть много заказов
        //        .HasForeignKey(o => o.ToolId) // Внешний ключ в таблице Orders
        //        .OnDelete(DeleteBehavior.Restrict); // Ограничение на каскадное удаление
        //}
    }
}