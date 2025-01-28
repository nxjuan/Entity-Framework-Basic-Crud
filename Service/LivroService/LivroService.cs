using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CrudDoYT.DataContext;
using CrudDoYT.Models;
using CrudDoYT.Models.Livro;
using Microsoft.EntityFrameworkCore;

namespace CrudDoYT.Service.LivroService;

public class LivroService : ILivroInterface
{
    public readonly ApplicationDbContext _context;

    public LivroService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ServiceResponse<List<LivroModel>>> GetAll()
    {
        var serviceResponse = new ServiceResponse<List<LivroModel>>();

        try
        {
            serviceResponse.Dados = await _context.Livros.ToListAsync();
            serviceResponse.Mensagem = "Livros encontrados com sucesso!";

            if (serviceResponse.Dados.Count == 0)
            {
                serviceResponse.Mensagem = "A lista está vazia!";
                serviceResponse.Sucesso = false;
            }
        }
        catch (Exception e)
        {
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<LivroModel>> GetById(Guid id)
    {
        var serviceResponse = new ServiceResponse<LivroModel>();

        try
        {
            serviceResponse.Dados = await _context.Livros.FirstOrDefaultAsync(x => x.Id == id);
            serviceResponse.Mensagem = "Livros encontrados!";
        }
        catch (Exception e)
        {
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
        }
        
        return serviceResponse;
    }

    public async Task<ServiceResponse<string>> Create(LivroModel? novoLivro)
    {
        var serviceResponse = new ServiceResponse<string>();
        try
        {
            if (novoLivro == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Informar dados";
                serviceResponse.Sucesso = false;
                return serviceResponse;
            }
            
            await _context.AddAsync(novoLivro);
            await _context.SaveChangesAsync();
            serviceResponse.Mensagem = "Livro criado com sucesso!";
            return serviceResponse;
        }
        catch (Exception e)
        {
            serviceResponse.Dados = e.Message;
            serviceResponse.Sucesso = false;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<string>> Update(LivroModel livro)
    {
        throw new NotImplementedException();
    }
}