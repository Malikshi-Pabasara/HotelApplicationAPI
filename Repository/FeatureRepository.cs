using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HotelApplication.Data;
using HotelApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApplication.Repository
{
    public class FeatureRepository : IFeatureRepository
    {
        private readonly HotelContext _context;
        private readonly IMapper _mapper;
        public FeatureRepository(HotelContext context, IMapper mapper) //Dependency Injection
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<FeatureModel>> GetAllFeaturesAsync()
        {
            var records = await _context.Features.ToListAsync();
            return _mapper.Map<List<FeatureModel>>(records); //Auto Map the record
        }

        public async Task<FeatureModel> GetFeatureByIdAsync(int featureId)
        {
            var feature = await _context.Features.FindAsync(featureId);
            return _mapper.Map<FeatureModel>(feature);
        }

        public async Task<int> AddFeatureAsync(FeatureModel featureModel)
        {
            var feature = new Feature()
            {
                Name = featureModel.Name,
                Type = featureModel.Type,
                NumberOfFeatures = featureModel.NumberOfFeatures
            };

            _context.Features.Add(feature);
            await _context.SaveChangesAsync();

            return feature.FeatureId;
        }
        public async Task UpdateFeatureAsync(int featureId, FeatureModel featureModel)
        {
            var feature = new Feature()
            {
                FeatureId = featureId,
                Name = featureModel.Name,
                Type = featureModel.Type,
                NumberOfFeatures = featureModel.NumberOfFeatures
            };

            _context.Features.Update(feature);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFeatureAsync(int featureId)
        {
            var feature = new Feature()
            {
                FeatureId = featureId
            };

            _context.Features.Remove(feature);

            await _context.SaveChangesAsync();
        }
    }
}
