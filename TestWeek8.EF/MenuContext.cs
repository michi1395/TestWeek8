using Microsoft.EntityFrameworkCore;
using System;
using TestWeek8.Core.Models;
using static TestWeek8.Core.Models.Plate;

namespace TestWeek8.EF
{
    public class MenuContext: DbContext
    {
        public DbSet<Menu> Menus { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Plate> Plates { get; set; }

        public MenuContext(DbContextOptions<MenuContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region MENU
            var menuEntity = builder.Entity<Menu>();

            menuEntity.HasKey(e => e.Id);

            menuEntity.Property(e => e.Name)
                          .IsRequired();

            menuEntity.HasMany(c => c.Plates)
                .WithOne(o => o.Menu);

            menuEntity.HasData(
                    new Menu
                    {
                        Id = 1,
                        Name = "Cenone di Capodanno"
                    },
                    new Menu
                    {
                        Id = 2,
                        Name = "Pranzo di Natale"
                    },
                     new Menu
                     {
                         Id = 3,
                         Name = "Pranzo domenicale"
                     }
                );
            #endregion

            #region PLATE
            var plateEntity = builder.Entity<Plate>();

            plateEntity.HasKey(e => e.Id);
            plateEntity.Property(e => e.Name)
                          .IsRequired();
            plateEntity.Property(e => e.Description)
                          .IsRequired();
            plateEntity.Property(e => e.PlateType)
                          .IsRequired();
            plateEntity.Property(e => e.Price)
                       .HasColumnType("decimal(5,2)")
                       .IsRequired();

            plateEntity.HasOne(o => o.Menu)
                .WithMany(c => c.Plates)
                .HasForeignKey(o => o.MenuId);

            plateEntity.HasData(
                    new Plate
                    {
                        Id = 1,
                        Name = "Orecchiette con polpette",
                        Description="Sugo, macinato, cipolla, parmigiano, orecchiette fresche",
                        PlateType=Tipology.FirstCourse,
                        MenuId=1,
                        Price=10.50M
                    },
                     new Plate
                     {
                         Id = 2,
                         Name = "Polpettone con carote",
                         Description = "Polpettone, brodo e carote",
                         PlateType = Tipology.MainCourse,
                         MenuId = 1,
                         Price = 12.50M
                     },
                      new Plate
                      {
                          Id = 3,
                          Name = "Cheesecake alla nutella",
                          Description = "Biscotti, panna, ricotta, nutella",
                          PlateType = Tipology.Sweet,
                          MenuId = 1,
                          Price = 5.50M
                      }
                );
            #endregion

            #region USER
            var userEntity = builder.Entity<User>();
            userEntity.HasKey(i => i.Id);
            userEntity.Property(e => e.Email).IsRequired();
            userEntity.Property(p => p.Password).IsRequired();
            userEntity.Property(r => r.Role).IsRequired();

            userEntity.HasData(
                new User
                {
                    Id = 1,
                    Email = "mrossi@abc.it",
                    Password = "1234",
                    Role = Role.Administator
                },
                new User
                {
                    Id = 2,
                    Email = "michi13@abc.it",
                    Password = "5678",
                    Role = Role.User
                }
                );
            #endregion
        }
    }
}
