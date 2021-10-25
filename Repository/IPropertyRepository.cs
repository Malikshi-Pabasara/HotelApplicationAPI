using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApplication.Models;

namespace HotelApplication.Repository
{
    public interface IPropertyRepository
    {
        Task<List<PropertyModel>> GetAllPropertiesAsync();
        Task<PropertyModel> GetPropertyByIdAsync(int propertyId);
        Task<int> AddPropertyAsync(PropertyModel propertyModel);
        Task UpdatePropertyAsync(int propertyId, PropertyModel propertyModel);
        Task DeletePropertyAsync(int propertyId);

    }
}
