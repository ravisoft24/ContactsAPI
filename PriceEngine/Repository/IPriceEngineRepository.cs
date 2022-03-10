using Microsoft.AspNetCore.JsonPatch;
using PriceEngine.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriceEngine.Repository
{
    public interface IPriceEngineRepository
    {
        Task<List<PriceEngineModel>> GetAllPrices();
        Task<PriceEngineModel> GetPriceById(int id);
        Task<int> AddNewPriceAsync(PriceEngineModel priceEngineModel);
        Task<int> UpdatePriceAsync(int id, PriceEngineModel priceEngineModel);
        Task UpdatePricePatchAsync(int id, JsonPatchDocument priceEngineModel);
        Task DeletePriceAsync(int id);

    }
}
