using IdeaTecAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace IdeaTecAPI.Data
{
    public class IdeaTecContext : DbContext
    {
        public IdeaTecContext(DbContextOptions<IdeaTecContext> options)
            : base(options)
        {
        }

        // Tabelas do Oracle
        public DbSet<Usuario> TB_USUARIO { get; set; } = null!;
        public DbSet<Empresa> TB_EMPRESA { get; set; } = null!;
        public DbSet<Tarefa> TB_TAREFA { get; set; } = null!;
        public DbSet<CheckinBemEstar> TB_CHECKIN_BEMESTAR { get; set; } = null!;
        public DbSet<RecomendacaoIA> TB_RECOMENDACAO_IA { get; set; } = null!;
        public DbSet<Habilidade> TB_HABILIDADE { get; set; } = null!;
        public DbSet<LogAtividade> TB_LOG_ATIVIDADE { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Note: removed hardcoded default schema. If you need a specific
            // Oracle schema, set it via migrations or configure the DB user.

            modelBuilder.Entity<Usuario>().ToTable("TB_USUARIO").HasKey(u => u.IdUsuario);
            modelBuilder.Entity<Empresa>().ToTable("TB_EMPRESA").HasKey(e => e.IdEmpresa);
            modelBuilder.Entity<Tarefa>().ToTable("TB_TAREFA").HasKey(t => t.IdTarefa);
            modelBuilder.Entity<CheckinBemEstar>().ToTable("TB_CHECKIN_BEMESTAR").HasKey(c => c.IdCheckin);
            modelBuilder.Entity<RecomendacaoIA>().ToTable("TB_RECOMENDACAO_IA").HasKey(r => r.IdRecomendacao);
            modelBuilder.Entity<Habilidade>().ToTable("TB_HABILIDADE").HasKey(h => h.IdHabilidade);
            modelBuilder.Entity<LogAtividade>().ToTable("TB_LOG_ATIVIDADE").HasKey(l => l.IdLog);

            base.OnModelCreating(modelBuilder);
        }
    }
}
