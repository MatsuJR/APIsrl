using APIsrl.Models;

namespace APIsrl.Repository.Interfaces
{
    public interface IServiceRepository
    {

        Task<List<ServiceModel>> GetAllServices();
        Task<ServiceModel> GetServiceById(int id);
        Task<ServiceModel> CreateService(ServiceModel service);
        Task<ServiceModel> UpdateService(ServiceModel service, int id);
        Task<bool> DeleteService(int id);
    }
}
