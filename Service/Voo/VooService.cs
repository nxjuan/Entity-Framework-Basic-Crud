using CrudDoYT.DataContext;
using CrudDoYT.Models;
using CrudDoYT.Models.Voo;
using Microsoft.EntityFrameworkCore;

namespace CrudDoYT.Service;

public class VooService : IVooInterface
{
    private readonly ApplicationDbContext _context;

    // Construtor do service, que recebe o DbContext (ApplicationDbContext) para interagir com o banco
    public VooService(ApplicationDbContext context)
    {
        _context = context;
    }

    // Implementação do método Create que recebe uma lista de voos
    public async Task<ServiceResponse<string>> Create(Voo[]? voos)
    {
        var serviceResponse = new ServiceResponse<string>();

        try
        {
            if (voos == null || voos.Length == 0)
            {
                return new ServiceResponse<string>
                {
                    Sucesso = false,
                    Mensagem = "É necessário informar ao menos um voo."
                };
            }
            
            var vooIds = voos.Select(v => v.Id).ToList(); 
            
            var voosExistentes = await _context.Voos
                .Where(v => vooIds.Contains(v.Id))
                .Select(v => v.Id)
                .ToListAsync();
            
            var novosVoos = voos.Where(v => !voosExistentes.Contains(v.Id)).ToArray();

            if (novosVoos.Length == 0)
            {
                return new ServiceResponse<string>
                {
                    Sucesso = false,
                    Mensagem = "Todos os voos já estão cadastrados."
                };
            }
            
            await _context.AddRangeAsync(novosVoos);
            await _context.SaveChangesAsync();

            return new ServiceResponse<string>
            {
                Sucesso = true,
                Mensagem = $"{novosVoos.Length} voos adicionados com sucesso."
            };
        }
        catch (Exception e)
        {
            return new ServiceResponse<string>
            {
                Sucesso = false,
                Mensagem = $"Erro ao criar voos: {e.Message}"
            };
        }
    }
}
