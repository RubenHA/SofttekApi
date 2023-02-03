using Microsoft.EntityFrameworkCore;
using SofttekApi.Models;

namespace SofttekApi.Data
{
    public class VentaContext : DbContext
    {
        public VentaContext(DbContextOptions<VentaContext> options) : base(options) { }

        public DbSet<Venta> Ventas { get; set; }
    }
}
