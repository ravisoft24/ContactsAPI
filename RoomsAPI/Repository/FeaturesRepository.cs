using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RoomsAPI.Data;
using RoomsAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomsAPI.Repository
{
    public class FeaturesRepository : IFeaturesRepository
    {
        private readonly RoomsContext _context;
        private readonly IMapper _mapper;

        public FeaturesRepository(RoomsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<FeaturesModel>> GetAllFeaturesAsync()
        {
            
            var features = await _context.Features.Select(x => new FeaturesModel()
            {
                Id = x.Id,
                Description = x.Description
              
            }).ToListAsync();

            return features;
            
        }
    }
}
