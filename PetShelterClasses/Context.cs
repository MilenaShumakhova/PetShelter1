using PetShelterClasses.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelterClasses
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<UsersPets> UsersPets { get; set; }
        public DbSet<GetterRequests> GetterRequests { get; set; }

        public Context() : base("PetShelterSecond")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(c => c.ExpectedPets)
                .WithMany(p => p.Users)
                .Map(m =>
                {
            // Ссылка на промежуточную таблицу
            m.ToTable("ExpectedPets");

            // Настройка внешних ключей промежуточной таблицы
            m.MapLeftKey("UserId");
                    m.MapRightKey("PetId");
                });
        }



    }
}
