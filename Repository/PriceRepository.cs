using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelApplication.Data;
using HotelApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApplication.Repository
{
    public class PriceRepository : IPriceRepository
    {
        private readonly HotelContext _context;
        private readonly IMapper _mapper;
        public PriceRepository(HotelContext context, IMapper mapper) //Dependency Injection
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PriceModel>> GetAllPricesAsync()
        {
            var records = await _context.Prices.ToListAsync();
            return _mapper.Map<List<PriceModel>>(records); //Auto Map the record
        }

        public async Task<PriceModel> GetPriceByIdAsync(int priceId)
        {
            var price = await _context.Prices.FindAsync(priceId);
            return _mapper.Map<PriceModel>(price);
        }

        public async Task<int> AddPriceAsync(PriceModel priceModel)
        {
            var price = new Price()
            {
                Name = priceModel.Name,
                Type = priceModel.Type,
                Prices = priceModel.Prices
            };

            _context.Prices.Add(price);
            await _context.SaveChangesAsync();

            return price.PriceId;
        }
        public async Task UpdatePriceAsync(int priceId, PriceModel priceModel)
        {
            var price = new Price()
            {
                PriceId = priceId,
                Name = priceModel.Name,
                Type = priceModel.Type,
                Prices = priceModel.Prices
            };

            _context.Prices.Update(price);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePriceAsync(int priceId)
        {
            var price = new Price()
            {
                PriceId = priceId
            };

            _context.Prices.Remove(price);

            await _context.SaveChangesAsync();
        }
    }
}
