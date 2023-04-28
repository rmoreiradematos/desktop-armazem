using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using Models;

namespace MyProject.Data
{
    public class Context : DbContext
    {
        public DbSet<Models.Produto> Produtos { get; set; }
        public DbSet<Models.Almoxarifado> Almoxarifados {get; set;}
        public DbSet<Models.Saldo> Saldos {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Aqui voce troca o caminho pro teu banco de dados!!
            var connectionString = "server=localhost;database=productscsharp;user=root;password=";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
