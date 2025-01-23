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
            serviceResponse.Mensagem = "Consulta Realizada com sucesso!";
            
            if (serviceResponse.Dados.Count == 0)
            {
                serviceResponse.Mensagem = "Nenhum registro encontrado";
            }
            
        }
        catch (Exception e)
        {
            serviceResponse.Mensagem = "Erro: " + e.Message;
            serviceResponse.Sucesso = false;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario)
    {
        ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

        try
        {
            if (novoFuncionario == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Informar dados";
                serviceResponse.Sucesso = false;
                return serviceResponse;
            }
            _context.Add(novoFuncionario);
            await _context.SaveChangesAsync();
            serviceResponse.Dados = _context.Funcionarios.ToList();
        }
        catch (Exception e)
        {
            serviceResponse.Mensagem = "Erro: " + e.Message;
            serviceResponse.Sucesso = false;
        }
        
        return serviceResponse;
    }

    public async Task<ServiceResponse<FuncionarioModel>> GetFuncionariosById(string id)
    {
        ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();

        try
        {
            serviceResponse.Dados = _context.Funcionarios.FirstOrDefault(x => x.Id == id);;
            serviceResponse.Mensagem = "Consulta Realizada com sucesso!";

            if (serviceResponse.Dados == null)
            {
                serviceResponse.Mensagem = "Nenhum registro encontrado";
                serviceResponse.Sucesso = false;
            }
            
        }
        catch (Exception e)
        {
            serviceResponse.Mensagem = "Erro: " + e.Message;
            serviceResponse.Sucesso = false;
        }
        
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel funcionario)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(string id)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(string id)
    {
        throw new NotImplementedException();
    }

}