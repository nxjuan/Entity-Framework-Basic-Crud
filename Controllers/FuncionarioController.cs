using Microsoft.AspNetCore.Mvc;

namespace CrudDoYT.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FuncionarioController : ControllerBase
{
    [HttpGet]
    public ActionResult Get()
    {
        return Ok("oik");
    }
}