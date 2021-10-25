using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HotelApplication.Data;
using HotelApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApplication.Repository
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly HotelContext _context;
        private readonly IMapper _mapper;
        public PropertyRepository(HotelContext context, IMapper mapper) //Dependency Injection
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PropertyModel>> GetAllPropertiesAsync()
        {
            var records = await _context.Properties.ToListAsync();
            return _mapper.Map<List<PropertyModel>>(records); //Auto Map the record
        }

        public async Task<PropertyModel> GetPropertyByIdAsync(int propertyId)
        {
            var property = await _context.Properties.FindAsync(propertyId);
            return _mapper.Map<PropertyModel>(property);
        }

        public async Task<int> AddPropertyAsync(PropertyModel propertyModel)
        {
            var property = new PropertyInfo()
            {
                Name = propertyModel.Name,
                Description = propertyModel.Description,
                ImageName = propertyModel.ImageName
            };

            _context.Properties.Add(property);
            await _context.SaveChangesAsync();

            return property.PropertyId;
        }
        public async Task UpdatePropertyAsync(int propertyId, PropertyModel propertyModel)
        {
            var property = new PropertyInfo()
            {
                PropertyId = propertyId,
                Name = propertyModel.Name,
                Description = propertyModel.Description,
                ImageName = propertyModel.ImageName
            };

            _context.Properties.Update(property);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePropertyAsync(int propertyId)
        {
            var property = new PropertyInfo()
            {
                PropertyId = propertyId
            };

            _context.Properties.Remove(property);

            await _context.SaveChangesAsync();
        }
    }
}
