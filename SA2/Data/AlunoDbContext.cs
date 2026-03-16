using Microsoft.EntityFrameworkCore;
using SA2.Entidades;

namespace SA2.Data
{
    public class AlunoDbContext : DbContext
    {
        public AlunoDbContext(DbContextOptions<AlunoDbContext> options) : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed inicial de dados
            modelBuilder.Entity<Aluno>().HasData(
                new Aluno
                {
                    Id = 1,
                    NomeDoAluno = "Clodoaldo",
                    RegistroAluno = 1001,
                    CursoId = 1,
                    StatusWifi = "Ativo",
                    StatusAction = "Aprovado"
                },
                new Aluno
                {
                    Id = 2,
                    NomeDoAluno = "César",
                    RegistroAluno = 1002,
                    CursoId = 2,
                    StatusWifi = "Inativo",
                    StatusAction = "Aguardando aprovação"
                }
            );
        }
    }
}