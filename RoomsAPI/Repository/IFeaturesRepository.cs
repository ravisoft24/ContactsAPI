using RoomsAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoomsAPI.Repository
{
    public interface IFeaturesRepository
    {
        Task<List<FeaturesModel>> GetAllFeaturesAsync();
    }
}
