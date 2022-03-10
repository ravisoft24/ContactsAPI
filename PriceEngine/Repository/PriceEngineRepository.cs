using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using PriceEngine.Data;
using PriceEngine.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriceEngine.Repository
{
    public class PriceEngineRepository : IPriceEngineRepository
    {
        private readonly PriceEngineContext _context;
        private readonly IMapper _mapper;

        public PriceEngineRepository(PriceEngineContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PriceEngineModel>> GetAllPrices()
        {
            var price = await _context.PriceEngine.ToListAsync();
            return _mapper.Map<List<PriceEngineModel>>(price);

        }

        public async Task<PriceEngineModel> GetPriceById(int id)
        {
            var price = await _context.PriceEngine.FindAsync(id);
            return _mapper.Map<PriceEngineModel>(price);

        }


        public async Task<int> AddNewPriceAsync(PriceEngineModel priceEngineModel)
        {

            var mapper = _mapper.Map<PriceEngines>(priceEngineModel);
            _context.PriceEngine.Add(mapper);
            await _context.SaveChangesAsync();
            return mapper.Id;
        }


        public async Task<int> UpdatePriceAsync(int id, PriceEngineModel priceEngineModel)
        {
            var price = new PriceEngines()
            {
                Id = id,
                PriceLbl = priceEngineModel.PriceLbl,   
                Price = priceEngineModel.Price,
                FromDate = priceEngineModel.FromDate,   
                ToDate = priceEngineModel.ToDate

            };
            _context.PriceEngine.Update(price);
            await _context.SaveChangesAsync();
            return price.Id;
        }


        public async Task UpdatePricePatchAsync(int id, JsonPatchDocument priceEngineModel)
        {
            var price = _context.PriceEngine.Find(id);
            if (price != null)
            {
                priceEngineModel.ApplyTo(price);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeletePriceAsync(int id)
        {
            var price = new PriceEngines() { Id = id };

            _context.PriceEngine.Remove(price);
            await _context.SaveChangesAsync();

        }
    }
}
