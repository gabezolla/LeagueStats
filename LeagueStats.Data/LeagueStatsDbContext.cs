using LeagueStats.Domain.Core.Data;
using LeagueStats.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Data
{
    public class LeagueStatsDbContext : DbContext, IUnitOfWork
    {
        public LeagueStatsDbContext(DbContextOptions<LeagueStatsDbContext> options) : base(options) { }

        public DbSet<Stats> Stats { get; set; }

        public DbSet<Summoner> Summoners { get; set; }

        public DbSet<Member> Members { get; set; }

        /// <summary>
        /// Mapeia as strings para varchar(100), para evitar criar um nvarchar(MAX)
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder
                .Model
                .GetEntityTypes()
                .SelectMany(
                    e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(100)");
            }

            // Busca as entidades e mappings via reflection para configurar o que setamos nas classes
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeagueStatsDbContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            // Pega o Tracker do EF (Mapeador de mudanças) e obtemos a prop RegistrationDate
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("RegistrationDate") != null))
            {
                // Se for adicionado, seta a RegistrationDate
                if (entry.State == EntityState.Added)
                {
                    entry.Property("RegistrationDate").CurrentValue = DateTime.Now;
                }

                // Caso seja atualização de entidade, não queremos mudar RegistrationDate
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("RegistrationDate").IsModified = false;
                }
            }

            // SaveChangesAsync() retorna o número de linhas alteradas
            return await base.SaveChangesAsync() > 0;
        }
    }
}

