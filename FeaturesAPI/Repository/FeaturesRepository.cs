using AutoMapper;
using FeaturesAPI.Data;
using FeaturesAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FeaturesAPI.Repository
{
    public class FeaturesRepository : IFeaturesRepository
    {
        private readonly FeaturesContext _featuresContext;
        private readonly IMapper _mapper;

        public FeaturesRepository(FeaturesContext featuresContext, IMapper mapper)
        {
            _featuresContext = featuresContext;
            _mapper = mapper;
        }


        public async Task<List<FeaturesModel>> GetAllFeatures()
        {
            var features = await _featuresContext.Features.ToListAsync();
            return _mapper.Map<List<FeaturesModel>>(features);

        }

        public async Task<FeaturesModel> GetFeatureById(int id)
        {
            var feature = await _featuresContext.Features.FindAsync(id);
           return _mapper.Map<FeaturesModel>(feature);

        }


        public async Task<int> AddFeatureAsync(FeaturesModel featuresModel)
        {

            var mapper = _mapper.Map<Features>(featuresModel);
            _featuresContext.Features.Add(mapper);
            await _featuresContext.SaveChangesAsync();
            return mapper.Id;


        }


        public async Task<int> UpdateFeatureAsync(int id, FeaturesModel featuresModel)
        {
            var feature = new Features()
            {
                Id = id,
                Name = featuresModel.Name,
                Description = featuresModel.Description
            };
            _featuresContext.Features.Update(feature);
            await _featuresContext.SaveChangesAsync();
            return feature.Id;
        }



        public async Task UpdateFeaturePatchAsync(int featureId, JsonPatchDocument featuresModel)
        {
            var feature = _featuresContext.Features.Find(featureId);
            if (feature != null)
            {
                featuresModel.ApplyTo(feature);
                await _featuresContext.SaveChangesAsync();
            }
        }

        public async Task DeleteFeatureAsync(int featureId)
        {
            var feature = new Features() { Id = featureId };

            _featuresContext.Features.Remove(feature);
            await _featuresContext.SaveChangesAsync();

        }

    }
}
