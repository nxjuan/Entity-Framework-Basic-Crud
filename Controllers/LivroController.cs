using CrudDoYT.Models.Livro;
using CrudDoYT.Service.LivroService;
using Microsoft.AspNetCore.Mvc;

namespace CrudDoYT.Controllers;

[ApiController]
[Route("[controller]")]
public class LivroController : ControllerBase
{
    private readonly ILivroInterface _livroInterface;

    public LivroController(ILivroInterface livroInterface)
    {
        _livroInterface = livroInterface;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _livroInterface.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        return Ok(await _livroInterface.GetById(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create(LivroModel livro)
    {
        return Ok(await _livroInterface.Create(livro));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] LivroModel livro)
    {
        return Ok(await _livroInterface.Update(livro));
    }
}