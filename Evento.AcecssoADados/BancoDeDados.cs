using Evento.AcessoADados.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.AcecssoADados
{
    public class BancoDeDados : DbContext
    {
        public DbSet<Event> Eventos { get; set; }
        public DbSet<Participante> Participantes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("server=localhost;" +
            "user id=sa;" +
            "password=;database=Eventos;"
             );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Participante>()
                .HasOne(p => p.Evento)
                .WithMany(b => b.Participantes)
                .HasForeignKey(p => p.IdEvento);
        }
    }
}
