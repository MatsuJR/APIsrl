using APIsrl.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIsrl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ClientModel>> GetAllClients()
        {
            return Ok();
        }
    }
}
