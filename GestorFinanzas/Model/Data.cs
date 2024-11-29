using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GestorFinanzas.Model
{
    public class Data : DbContext
    {
        public DbSet<Movimiento> Movimientos { get; set; }
        public DbSet<Balance> Balance { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        /*public string Fecha { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }

        // El color se basa en si el monto es positivo o negativo
        public string ColorMonto => Monto < 0 ? "Red" : "Green";
        */

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Datas");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movimiento>().HasKey();
            modelBuilder.Entity<Balance>().HasKey();
            modelBuilder.Entity<Category>().HasKey();
            modelBuilder.Entity<Usuario>().HasKey();

        }

    }
    public record Movimiento(int id, string Descripcion, decimal Monto, string Fecha, int CategoryId, int idUsuario)
    {
        public Category Category { get; set; }
        public Usuario Usuario { get; set; }
    }
    public record Balance (int idBalance, decimal TotalIngresos, decimal TotalEgresos , string FechaInicio , string FechaFin, int idUsuario) 
    {
        public Usuario Usuario { get; set; }
    }
    public record Category (int idCategory , string Nombre, string Tipo);
    public record Usuario(int IdUsuario , string Clave);

}
