using CrudDoYT.Models;
using CrudDoYT.Models.Biblioteca;
using CrudDoYT.Models.Livro;
using Microsoft.EntityFrameworkCore;

namespace CrudDoYT.DataContext;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    public DbSet<FuncionarioModel> Funcionarios { get; set; }
    public DbSet<LivroModel> Livros { get; set; }
    public DbSet<BibliotecaModel> Bibliotecas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LivroModel>()
            .HasOne(b => b.Biblioteca)
            .WithMany(l => l.Livros)
            .HasForeignKey(l => l.Id);
        
        base.OnModelCreating(modelBuilder);
    }
}