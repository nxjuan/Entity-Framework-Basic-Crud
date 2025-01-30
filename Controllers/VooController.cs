using CrudDoYT.Models;
using CrudDoYT.Models.Voo;
using CrudDoYT.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CrudDoYT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VooController : ControllerBase
    {
        private readonly IVooInterface _vooInterface;

        public VooController(IVooInterface vooInterface)
        {
            _vooInterface = vooInterface;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVoos([FromBody] Voo[] voos)
        {
            return Ok(await _vooInterface.Create(voos));
        }
    }
}