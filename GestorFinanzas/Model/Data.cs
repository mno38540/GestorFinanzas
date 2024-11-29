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
                new Movimiento(1,"Pago de sueldo",2000000,"05/12/2024",1,1),
                new Movimiento(1, "Pago de sueldo", 2000000, "05/12/2024", 1, 2)
                );
            modelBuilder.Entity<Balance>().HasData(
                new Balance(1, 2550000, 1000000, "01/11/2024", "30/11/2024", 1)
                );
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario(1, "Andres", "Claro2020"),
                new Usuario(2, "Karen Silva", "Nutri"),
                new Usuario(2, "Admin", "Admin1234")
                );
            
        }

    }
    public record Movimiento(int id, string Descripcion, decimal Monto, string Fecha, int CategoryId, int idUsuario)
    {
        public Category Category { get; set; }
        public Usuario Usuario { get; set; }
    }
    public record Usuario(int IdUsuario, string usuario, string Clave);
    public record Balance (int idBalance, decimal TotalIngresos, decimal TotalEgresos , string FechaInicio , string FechaFin, int idUsuario) 
    {
        public Usuario Usuario { get; set; }
    }
    public record Category (int idCategory , string Nombre, string Tipo);
    

}
