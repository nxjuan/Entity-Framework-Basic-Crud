using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CrudDoYT.Models.Livro;

namespace CrudDoYT.Models.Biblioteca;

public class BibliotecaModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nome { get; set; }
    public string Endereco { get; set; }
    public string CNPJ { get; set; }
    public string Email { get; set; }
    
    [InverseProperty("Biblioteca")]
    public ICollection<LivroModel>? Livros { get; set; }
}