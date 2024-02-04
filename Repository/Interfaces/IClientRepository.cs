using APIsrl.Models;

namespace APIsrl.Repository.Interfaces
{
    public interface IClientRepository
    {
        Task<List<ClientModel>> GetAllClients();
        Task<ClientModel> GetClientById(int id);
        Task<ClientModel> CreateClient(ClientModel client);
        Task<ClientModel> UpdateClient(ClientModel client, int id);
        Task<bool> DeleteClient(int id);
    }
}
