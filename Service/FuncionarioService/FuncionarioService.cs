using CrudDoYT.DataContext;
using CrudDoYT.Models;
using Microsoft.EntityFrameworkCore;

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
        var serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
        try
        {
            serviceResponse.Dados = await _context.Funcionarios.ToListAsync();
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

    public async Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel? novoFuncionario)
    {
        var serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

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
        var serviceResponse = new ServiceResponse<FuncionarioModel>();

        try
        {
            serviceResponse.Dados = await _context.Funcionarios.FirstOrDefaultAsync(x => x.Id == id);;
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
        var serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

        try
        {
            var funcionarioModel = _context.Funcionarios.FirstOrDefault(x => x.Id == funcionario.Id);
            if (funcionarioModel == null)
            {
                serviceResponse.Mensagem = "Nenhum registro encontrado";
                serviceResponse.Sucesso = false;
                return serviceResponse;
            }
            
            funcionarioModel.Nome = funcionario.Nome;
            funcionarioModel.Sobrenome = funcionario.Sobrenome;
            funcionarioModel.Departamento = funcionario.Departamento;
            funcionarioModel.DataCriacao = funcionario.DataCriacao;
            funcionarioModel.Turno = funcionario.Turno;

            _context.Update(funcionarioModel);
            
            await _context.SaveChangesAsync();
            serviceResponse.Dados = _context.Funcionarios.ToList();
            serviceResponse.Mensagem = "Registro Atualizado com sucesso!";
        }
        catch (Exception e)
        {
            serviceResponse.Mensagem = "Erro: " + e.Message;
            serviceResponse.Sucesso = false;
        }
        
        return serviceResponse;
    }

    public async Task<ServiceResponse<FuncionarioModel>> DeleteFuncionario(string id)
    {
        var serviceResponse = new ServiceResponse<FuncionarioModel>();
        try
        {
            var funcionarioModel = await _context.Funcionarios.FirstOrDefaultAsync(x => x.Id == id);
            if (funcionarioModel == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Funcionario não encontrado";
                serviceResponse.Sucesso = false;
                return serviceResponse;
            }

            serviceResponse.Mensagem = "Funcionario deletado";
            _context.Remove(funcionarioModel);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            serviceResponse.Mensagem = "Erro: " + e.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(string id)
    {
        var serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

        var funcionario = await _context.Funcionarios.FirstOrDefaultAsync(x => x.Id == id);

        if (funcionario == null)
        {
            serviceResponse.Mensagem = "Funcionario não encontrado";
            serviceResponse.Sucesso = false;
            return serviceResponse;
        }
        serviceResponse.Dados = _context.Funcionarios.ToList();
        serviceResponse.Mensagem = "Funcionario inativado";
        funcionario.Ativo = false;
        _context.Update(funcionario);
        await _context.SaveChangesAsync();
        return serviceResponse;
    }

}