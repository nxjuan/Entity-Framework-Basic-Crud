using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CrudDoYT.Models.Biblioteca;

namespace CrudDoYT.Models.Livro;

public class LivroModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public string Autor { get; set; }
    public string Genero { get; set; }
    [ForeignKey("Id")] 
    public BibliotecaModel Biblioteca { get; set; }
}