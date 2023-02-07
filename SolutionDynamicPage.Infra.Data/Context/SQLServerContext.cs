using Microsoft.EntityFrameworkCore;
using SolutionDynamicPage.Infra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionDynamicPage.Infra.Data.Context
{
    public class SQLServerContext : DbContext
    {

        public SQLServerContext(DbContextOptions<SQLServerContext> options) : base(options) 
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed
                modelBuilder.Entity<User>()
                .HasData(
                new { Id = 1, Login = "mike", Password = "root"}
                );


            modelBuilder.Entity<SiteProfile>()
            .HasData(
            new
            {
                Id = 1,
                ProfileName = "Main Profile",
                BusinessName = "Sua Marca",
                Description = "Descrição do Negócio",
                FacebookAdress = "@empresa",
                InstragramAdress = "@empreinsta",
                Address = "1600 Amphitheatre Parkway, Mountain View",
                Email = "empresa@empresa.com",
                Phone = "4733223322",
                CellPhone = "47933224455",
                ImageLogo = "~/img/banner.jpg",
                ImageBanner = "~/img/banner.jpg",
                Title = "Bom te ver por aqui!",
                ImageDescription = "~/img/banner.jpg",
                FooterDescription = "Transforme as pessoas que encontram você, novos clientes com um Perfil da Empresa gratuito para seu estabelecimento físico ou sua área de cobertura."
                ,IsPublished = true
            }

       ); ;

            /* public int Id { get; set; }
        public string ProfileName { get; set; }

        public string BusinessName { get; set; }
        public string Description { get; set; }

        public string? FacebookAdress { get; set; }

        public string? InstagramAdress { get; set; }

        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public string ImageLogo { get; set; }
        public string ImageBanner { get; set; }

        public string Title { get; set; }

        public string ImageDescription { get; set; }

        public string FooterDescription { get; set; }*/
        }

        public DbSet<SiteProfile> Profiles { get; set;}
        public DbSet<User> Users { get; set;}
    }
}

