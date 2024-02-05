using APIsrl.Models;

namespace APIsrl.Repository.Interfaces
{
    public interface IMaterialRepository
    {
        Task<List<MaterialModel>> GetAllMaterials();
        Task<MaterialModel> GetMaterialById(int id);
        Task<MaterialModel> CreateMaterial(MaterialModel material);
        Task<MaterialModel> UpdateMaterial(MaterialModel material, int id);
        Task<bool> DeleteMaterial(int id);
    }
}
