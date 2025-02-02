using CrudDoYT.Models;

namespace CrudDoYT.Service.FuncionarioService;

public interface IFuncionarioInterface
{
    Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios();
    
    Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario);
    
    Task<ServiceResponse<FuncionarioModel>> GetFuncionariosById(Guid id);
    
    Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel funcionario);
    
    Task<ServiceResponse<FuncionarioModel>> DeleteFuncionario(Guid id);
    
    Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(Guid id);
    
}