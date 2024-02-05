using APIsrl.Data;
using APIsrl.Models;
using APIsrl.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIsrl.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ContextDataBase _context;
        public ServiceRepository(ContextDataBase context)
        {
            _context = context;
        }

        public async Task<List<ServiceModel>> GetAllServices()
        {
            return await _context.Services
                .Include(s => s.Client)
                .ToListAsync();
        }

        public async Task<ServiceModel> GetServiceById(int id)
        {
            return await _context.Services
                .Include(s => s.Client)
                .FirstOrDefaultAsync(s => s.Id == id);
        }


        public async Task<ServiceModel> CreateService(ServiceModel service)
        {
            await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();

            return service;
        }

       

        public async Task<ServiceModel> UpdateService(ServiceModel service, int id)
        {
            ServiceModel serviceById = await GetServiceById(id);
            if(serviceById == null)
            {
                throw new Exception($"Serviço para o ID: {id} não foi encontrado");
            }

            serviceById.ServiceDescription = service.ServiceDescription;
            serviceById.SpentMaterial = service.SpentMaterial;
            serviceById.StartDate = service.StartDate;
            serviceById.FinalDate = service.FinalDate;
            serviceById.GrossProfit = service.GrossProfit;
            serviceById.NetProfit = service.NetProfit;
            serviceById.TotalBudget = service.TotalBudget;
            serviceById.ClientId = service.ClientId;

            _context.Services.Update(serviceById);
            await _context.SaveChangesAsync();

            return serviceById;

        }


        public async Task<bool> DeleteService(int id)
        {
            ServiceModel serviceById = await GetServiceById(id);
            if (serviceById == null)
            {
                throw new Exception($"Serviço para o ID: {id} não foi encontrado");
            }

            _context.Services.Remove(serviceById);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
