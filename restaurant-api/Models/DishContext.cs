using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace restaurant_api.Models
{
    public class DishContext : DbContext
    {
        public DishContext(DbContextOptions<DishContext> options) 
            : base(options)
        {
        }
        public DbSet<Dish> Dishes { get; set; } = null!;
    }
}
