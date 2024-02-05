using APIsrl.Models;
using APIsrl.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace APIsrl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }


        [HttpGet]
        public async Task<ActionResult<List<ClientModel>>> GetAllClients()
        {
            List<ClientModel> clients = await _clientRepository.GetAllClients();
            return Ok(clients);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ClientModel>> GetClientById(int id)
        {
            ClientModel client = await _clientRepository.GetClientById(id);
            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult<ClientModel>> CreateClient([FromBody] ClientModel clientModel)
        {
            ClientModel client =await _clientRepository.CreateClient(clientModel);

            return Ok(client);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClientModel>> UpdateClient([FromBody] ClientModel clientModel, int id)
        {
            clientModel.Id = id;
            ClientModel client = await _clientRepository.UpdateClient(clientModel, id);
            return Ok(client);

        }

        [HttpDelete]
        public async Task<ActionResult<ClientModel>> DeleteClient(int id)
        {
            bool deleted = await _clientRepository.DeleteClient(id);
            return Ok(deleted);
        }

    }
}
