using CrudDoYT.DataContext;
using CrudDoYT.Models;
using CrudDoYT.Models.Livro;

namespace CrudDoYT.Service.LivroService;

public interface ILivroInterface
{
    Task<ServiceResponse<List<LivroModel>>> GetAll();
    
    Task<ServiceResponse<LivroModel>> GetById(Guid id);
    
    Task<ServiceResponse<String>> Create(LivroModel livro);
    
    Task<ServiceResponse<String>> Update(LivroModel livro);
    
}