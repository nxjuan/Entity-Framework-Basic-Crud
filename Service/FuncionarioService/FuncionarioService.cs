using CrudDoYT.DataContext;
using CrudDoYT.Models;

namespace CrudDoYT.Service.FuncionarioService;

public class FuncionarioService : IFuncionarioInterface
{   
    private readonly ApplicationDbContext _context;

    public FuncionarioService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios()
    {
        ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
        try
        {
            serviceResponse.Dados = _context.Funcionarios.ToList();
        }
        catch (Exception e)
        {
            serviceResponse.Mensagem = "Erro: " + e.Message;
            serviceResponse.Sucesso = false;
        }
        return serviceResponse;
    }

    public Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<FuncionarioModel>> GetFuncionariosById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel funcionario)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id)
    {
        throw new NotImplementedException();
    }
}