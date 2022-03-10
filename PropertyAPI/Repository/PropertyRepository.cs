using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using PropertyAPI.Data;
using PropertyAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyAPI.Repository
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly PropertyContext _context;
        private readonly IMapper _mapper;

        public PropertyRepository(PropertyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PropertyModel>> GetAllProperties()
        {
            var records = await _context.Property.ToListAsync();
            return _mapper.Map<List<PropertyModel>>(records);
        
        }

        public async Task<PropertyModel> GetPropetyById(int propertyId)
        {
            var records = await _context.Property.FindAsync(propertyId);
            return _mapper.Map<PropertyModel>(records);

        }

        public async Task<int> AddPropertyAsync(PropertyModel propertyModel)
        {
            var mapper = _mapper.Map<Property>(propertyModel);
            _context.Property.Add(mapper);
            await _context.SaveChangesAsync();
            return mapper.Id;

        }


        public async Task<PropertyModel> UpdatePropertyAsync(int id, PropertyModel propertyModel)
        {
            var property = new Property()
            {
                Id = id,
                Name = propertyModel.Name,
            };

            _context.Property.Update(property);
            await _context.SaveChangesAsync();
            return _mapper.Map<PropertyModel>(property);
            //return "id " + property.id + " updated";

            //var property = await _context.Property.FindAsync(id);
            //var mapper = _mapper.Map(property, propertyModel);
            //_context.Property.Update(property);
            //await _context.SaveChangesAsync();
            //return _mapper.Map<PropertyModel>(property);

        }


        public async Task UpdatePropertyPatchAsync(int id, JsonPatchDocument propertyModel)
        {
            var property = _context.Property.Find(id);
            if (property != null)
            {
                propertyModel.ApplyTo(property);
                await _context.SaveChangesAsync();
            }
         
        }

        public async Task DeletePropertyAsync(int id)
        {
            var property = new Property() { Id = id };

            _context.Property.Remove(property);
            await _context.SaveChangesAsync();

        }

    }
}
