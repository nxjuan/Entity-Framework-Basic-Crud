using CrudDoYT.DataContext;
using CrudDoYT.Models;
using CrudDoYT.Service.FuncionarioService;
using Microsoft.AspNetCore.Mvc;

namespace CrudDoYT.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FuncionarioController : ControllerBase
{
    private readonly IFuncionarioInterface _funcionarioInterface;
    public FuncionarioController(IFuncionarioInterface funcionarioInterface)
    {
        _funcionarioInterface = funcionarioInterface;
    }
    
    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> GetFuncionarios()
    {
        return Ok( await _funcionarioInterface.GetFuncionarios() );
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<FuncionarioModel>>> GetFuncionarioById([FromRoute] string id)
    {
        return Ok( await _funcionarioInterface.GetFuncionariosById(id) );
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> PostFuncionarios(FuncionarioModel novoFuncionario)
    {
        return Ok( await _funcionarioInterface.CreateFuncionario(novoFuncionario) );
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> UpdateFuncionario(FuncionarioModel funcionario)
    {
        return Ok( await _funcionarioInterface.UpdateFuncionario(funcionario) );
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<FuncionarioModel>>> DeleteFuncionario(string id)
    {
        return Ok( await _funcionarioInterface.DeleteFuncionario(id) );
    }

    [HttpPatch("inativa/{id}")]
    public async Task<ActionResult<ServiceResponse<FuncionarioModel>>> inativaFuncionario(string id)
    {
        return Ok( await _funcionarioInterface.InativaFuncionario(id) );
    }
    
}