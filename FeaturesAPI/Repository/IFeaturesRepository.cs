using FeaturesAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FeaturesAPI.Repository
{
    public interface IFeaturesRepository
    {
        Task<List<FeaturesModel>> GetAllFeatures();
        Task<FeaturesModel> GetFeatureById(int id);
        Task<int> AddFeatureAsync(FeaturesModel featuresModel);
        Task<int> UpdateFeatureAsync(int id, FeaturesModel featuresModel);
        Task UpdateFeaturePatchAsync(int featureId, JsonPatchDocument featuresModel);
        Task DeleteFeatureAsync(int featureId);


    }
}
