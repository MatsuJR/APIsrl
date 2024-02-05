 using APIsrl.Data;
using APIsrl.Models;
using APIsrl.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIsrl.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ContextDataBase _context;

        public ClientRepository(ContextDataBase context) 
        {
            _context = context;
        }

        public async Task<List<ClientModel>> GetAllClients()
        {
            return await _context.Clients
                .ToListAsync();
        }

        public async Task<ClientModel> GetClientById(int id)
        {
            return await _context.Clients
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ClientModel> CreateClient(ClientModel client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();

            return client;
        }


        public async Task<ClientModel> UpdateClient(ClientModel client, int id)
        {
            ClientModel clientById = await GetClientById(id);
            if (clientById == null)
            {
                throw new Exception($"Cliente para o ID: {id} não foi encontrado");
            }

            clientById.Name = client.Name;
            clientById.Phone = client.Phone;
            clientById.Services = client.Services;

            _context.Clients.Update(clientById);
            await _context.SaveChangesAsync();

            return clientById;
        }


        public async Task<bool> DeleteClient(int id)
        {
            ClientModel clientById = await GetClientById(id);

            if(clientById == null)
            {
                throw new Exception($"Cliente para o ID: {id} não foi encontrado");
            }

            _context.Clients.Remove(clientById);
            await _context.SaveChangesAsync();

            return true;
        }

        

      



    }
}
