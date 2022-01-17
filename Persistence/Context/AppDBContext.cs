using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api_rest.Domain.Models;
using api_rest.Domain.Helpers;


namespace api_rest.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(p => p.Id);
            builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Category>().HasMany(p => p.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);

            builder.Entity<Category>().HasData
            (
                new Category { Id = 10, Name = "Material Escolar" }, 
                new Category { Id = 11, Name = "Artigos para Viagem" },
                new Category { Id = 12, Name = "Itens Esportivos"},
                new Category { Id = 13, Name = "Informatica"}
            );

            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Login).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.QuantityInPackage).IsRequired();
            builder.Entity<Product>().Property(p => p.Unit).IsRequired();

            builder.Entity<Product>().HasData
            (
                new Product
                {
                    Id = 10,
                    Login = "Caderno",
                    QuantityInPackage = 20,
                    Unit = EUnit.MaterialEscolar,
                    CategoryId = 10
                },
                new Product
                {
                    Id = 11,
                    Login = "Mala",
                    QuantityInPackage = 5,
                    Unit = EUnit.ArtigosViagem,
                    CategoryId = 11,
                },
                new Product
                {
                    Id = 12,
                    Login = "Bola",
                    QuantityInPackage = 7,
                    Unit = EUnit.ItensEsportivos,
                    CategoryId = 12,
                },
                new Product
                {
                    Id = 13,
                    Login = "Notebook",
                    QuantityInPackage = 9,
                    Unit = EUnit.Informatica,
                    CategoryId = 13,
                }

            );

            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Login).IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(10);

            builder.Entity<User>().HasData
            (
                new User
                {
                    Id = 13,
                    Login = "Baron",
                    Password = "12345678",
                }
            );

        }
    
    }
}
