using APINetCore.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINetCore.Persistence
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options)
            : base(options)
        {

        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Unidade> Unidades { get; set; }
        public DbSet<Comanda> Comandas { get; set; }
        public DbSet<ItensComanda> ComandaItens { get; set; }
        public DbSet<NotaFiscal> NotasFiscais { get; set; }
        public DbSet<NotaFiscalItens> NotasFiscaisItens { get; set; }
        public DbSet<Produtos> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comanda>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Comanda>()
                .HasMany(p => p.ComandaItens)
                .WithOne(a => a.Comanda)
                .HasForeignKey(a => a.IdComanda)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItensComanda>()
                 .HasKey(a => a.Id);

            //modelBuilder.Entity<ItensComanda>()
            //    .HasOne(p => p.Produto)
            //    .WithOne();
                //.HasForeignKey<Produtos>(b => b.Id);

            modelBuilder.Entity<NotaFiscal>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<NotaFiscal>()
                .HasMany(p => p.notaFiscalItens)
                .WithOne(a => a.NotaFiscal)
                .HasForeignKey(a => a.IdNotaFiscal)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<NotaFiscalItens>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Produtos>()
                .HasKey(a => a.Id);

            //modelBuilder.Entity<Produtos>()
                //.HasOne(c =>c.)
                //.WithOne();
                //.HasForeignKey<Produtos>(b => b.Id);






            modelBuilder.Entity<Aluno>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Professor>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Professor>()
                .HasMany(p => p.Alunos)
                .WithOne(a => a.Professor)
                .HasForeignKey(a => a.IdProfessor)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Unidade>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Unidade>()
                .HasMany(u => u.Alunos)
                .WithOne(a => a.Unidade)
                .HasForeignKey(a => a.IdUnidade)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Unidade>()
               .HasMany(u => u.Professores)
               .WithOne(p => p.Unidade)
               .HasForeignKey(a => a.IdUnidade)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
