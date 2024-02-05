using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIsrl.Data;
using APIsrl.Models;
using APIsrl.Repository.Interfaces;
using APIsrl.Repository;

namespace APIsrl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialRepository _materialRepository;

        public MaterialController(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<MaterialModel>>> GetAllMaterials()
        {
            List<MaterialModel> materials = await _materialRepository.GetAllMaterials();
            return Ok(materials);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<MaterialModel>> GetMaterialById(int id)
        {
            MaterialModel material = await _materialRepository.GetMaterialById(id);
            return Ok(material);
        }

        [HttpPost]
        public async Task<ActionResult<MaterialModel>> CreateMaterial([FromBody] MaterialModel materialModel)
        {
            MaterialModel material = await _materialRepository.CreateMaterial(materialModel);

            return Ok(material);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MaterialModel>> UpdateMaterial([FromBody] MaterialModel materialModel, int id)
        {
            materialModel.Id = id;
            MaterialModel material = await _materialRepository.UpdateMaterial(materialModel, id);
            return Ok(material);

        }

        [HttpDelete]
        public async Task<ActionResult<MaterialModel>> DeleteMaterial(int id)
        {
            bool deleted = await _materialRepository.DeleteMaterial(id);
            return Ok(deleted);
        }
    }
}
