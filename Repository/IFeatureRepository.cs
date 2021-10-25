using System.Collections.Generic;
using System.Threading.Tasks;
using HotelApplication.Models;

namespace HotelApplication.Repository
{
    public interface IFeatureRepository
    {
        Task<List<FeatureModel>> GetAllFeaturesAsync();
        Task<FeatureModel> GetFeatureByIdAsync(int featureId);
        Task<int> AddFeatureAsync(FeatureModel featureModel);
        Task UpdateFeatureAsync(int featureId, FeatureModel featureModel);
        Task DeleteFeatureAsync(int featureId);
    }
}
