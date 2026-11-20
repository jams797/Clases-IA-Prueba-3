using System;
using Microsoft.EntityFrameworkCore;

namespace ProyectoApiMvc.BD;

public class DBClassContext : DbContext
{
    public DbSet<PersonModelDB> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=clase;Username=admin;Password=Admin123456");

        // dotnet ef dbcontext scaffold "Host=localhost;Port=5432;Database=clase;Username=admin;Password=Admin123456" Npgsql.EntityFrameworkCore.PostgreSQL -o Models/DB
    }
}
