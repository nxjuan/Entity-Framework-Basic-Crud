using System.ComponentModel.DataAnnotations;
using CrudDoYT.Enums;

namespace CrudDoYT.Models;

public class FuncionarioModel
{
    [Key]
    public String Id { get; set; }
    public String Nome { get; set; }
    public String Sobrenome { get; set; }
    public DepartamentoEnums Departamento { get; set; }
    public bool Ativo { get; set; }
    public TurnoEnum Turno { get; set; }
    public DateTime DataNascimento { get; set; } = DateTime.Now.ToUniversalTime();
    public DateTime DataCriacao { get; set; } = DateTime.Now.ToUniversalTime();
    
}