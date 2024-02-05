using APIsrl.Models;
using APIsrl.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace APIsrl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;
        public ServiceController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }


        [HttpGet]
        public async Task<ActionResult<List<ServiceModel>>> GetAllServices()
        {
            List<ServiceModel> services = await _serviceRepository.GetAllServices();
            return Ok(services);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceModel>> GetServiceById(int id)
        {
            ServiceModel service = await _serviceRepository.GetServiceById(id);
            return Ok(service);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceModel>> CreateService([FromBody] ServiceModel serviceModel)
        {
            ServiceModel service = await _serviceRepository.CreateService(serviceModel);

            return Ok(service);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceModel>> UpdateService([FromBody] ServiceModel serviceModel, int id)
        {
            serviceModel.Id = id;
            ServiceModel service = await _serviceRepository.UpdateService(serviceModel, id);
            return Ok(service);

        }

        [HttpDelete]
        public async Task<ActionResult<ServiceModel>> DeleteClient(int id)
        {
            bool deleted = await _serviceRepository.DeleteService(id);
            return Ok(deleted);
        }

    }
}
