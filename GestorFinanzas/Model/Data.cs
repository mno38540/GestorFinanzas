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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Shop");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category(1, "Salario","ingreso"),
                new Category(2, "Pago","Gasto"),
                new Category(3, "Transporte", "Gasto" ),
                new Category(4, "Comida", "Gasto")
                );

            modelBuilder.Entity<Movimiento>().HasData(
                new Movimiento(1,"Pago Andres",2000000,"05/12/2024",1,1),
                new Movimiento(2, "Pago Karen", 2000000, "08/12/2024", 1, 2),
                new Movimiento(3, "Comida", -25000, "14/11/2024", 1, 2),
                new Movimiento(4, "Tanqueada", -37500, "19/11/2024", 1, 2)
                );
            modelBuilder.Entity<Balance>().HasData(
                new Balance(1, 2550000, 1000000, "01/11/2024", "30/11/2024", 1),
                new Balance(2,100,200, "01/11/2024", "30/11/2024",2),
                new Balance(3, 5000, 200, "01/11/2024", "30/11/2024", 1),
                new Balance(4, 100000, 200, "01/11/2024", "30/11/2024", 1)
                );
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario(1, "Andres", "Claro2020"),
                new Usuario(2, "Karen Silva", "Nutri"),
                new Usuario(3, "Admin", "Admin1234")
                );
            
        }

    }
    public record Usuario(int Id, string user, string Clave);
    public record Category(int Id, string Nombre, string Tipo);
    public record Movimiento(int Id, string Descripcion, decimal Monto, string Fecha, int CategoryId, int UsuarioId)
    {
        public Category Category { get; set; }
        public Usuario Usuario { get; set; }
    }
    
    public record Balance (int Id, decimal TotalIngresos, decimal TotalEgresos , string FechaInicio , string FechaFin, int UsuarioId)
    {
        public Usuario Usuario { get; set; }
    }

}
