using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CrudDoYT.Enums;

namespace CrudDoYT.Models;

public class FuncionarioModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public String Nome { get; set; }
    public String Sobrenome { get; set; }
    public DepartamentoEnums Departamento { get; set; }
    public bool Ativo { get; set; }
    public TurnoEnum Turno { get; set; }
    public DateTime DataNascimento { get; set; } = DateTime.Now.ToUniversalTime();
    public DateTime DataCriacao { get; set; } = DateTime.Now.ToUniversalTime();
    
}