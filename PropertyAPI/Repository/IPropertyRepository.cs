using Microsoft.AspNetCore.JsonPatch;
using PropertyAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PropertyAPI.Repository
{
    public interface IPropertyRepository
    {
        Task<List<PropertyModel>> GetAllProperties();
        Task<PropertyModel> GetPropetyById(int propertyId);
        Task<int> AddPropertyAsync(PropertyModel propertyModel);
        Task<PropertyModel> UpdatePropertyAsync(int id, PropertyModel propertyModel);
        Task UpdatePropertyPatchAsync(int id, JsonPatchDocument propertyModel);
        Task DeletePropertyAsync(int id);

    }
}
