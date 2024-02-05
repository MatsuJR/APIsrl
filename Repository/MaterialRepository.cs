using APIsrl.Data;
using APIsrl.Models;
using APIsrl.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace APIsrl.Repository
{
    public class MaterialRepository : IMaterialRepository
    {

        private readonly ContextDataBase _context;
        public MaterialRepository(ContextDataBase context)
        {
            _context = context;
        }

        public async Task<MaterialModel> CreateMaterial(MaterialModel material)
        {
            await _context.Materials.AddAsync(material);
            await _context.SaveChangesAsync();

            return material;
        }

        public async Task<List<MaterialModel>> GetAllMaterials()
        {
            return await _context.Materials.ToListAsync();
        }

        public async Task<MaterialModel> GetMaterialById(int id)
        {
            return await _context.Materials.FirstOrDefaultAsync(m => m.Id == id);
        }


        public async Task<bool> DeleteMaterial(int id)
        {
            MaterialModel materialById = await GetMaterialById(id);
            if (materialById == null)
            {
                throw new Exception($"Material para o ID: {id} não foi encontrado");
            }
            _context.Materials.Remove(materialById);
            await _context.SaveChangesAsync();

            return true;
        }

        

        public async Task<MaterialModel> UpdateMaterial(MaterialModel material, int id)
        {
            MaterialModel materialById = await GetMaterialById(id);
            if (materialById == null)
            {
                throw new Exception($"Material para o ID: {id} não foi encontrado");
            }
            materialById.Name = material.Name;
            materialById.Price = material.Price;
            materialById.Width = material.Width;
            materialById.Height = material.Height;
            materialById.Length = material.Length;
            materialById.Thickness = material.Thickness;

            _context.Materials.Update(materialById);
            await _context.SaveChangesAsync();

            return materialById;
        }





    }


}


