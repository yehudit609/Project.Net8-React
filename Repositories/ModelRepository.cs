using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repositories
{
    public class ModelRepository : IModelRepository
    {
        private CarRetalContext _picturesStoreContext;

        public ModelRepository(CarRetalContext picturesStoreContext)
        {
            _picturesStoreContext = picturesStoreContext;
        }

        public async Task<Model> addModel(Model model)
        {
            try
            {
                _picturesStoreContext.Models.Add(model);
                await _picturesStoreContext.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding model: " + ex.Message);
            }
        }

        public async Task<List<Model>> getModels()
        {
            try
            {
                var foundModels = await _picturesStoreContext.Models.ToListAsync();
                return foundModels;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting models: " + ex.Message);
            }
        }

        public async Task<Model> getModelById(int id)
        {
            try
            {
                var foundModel = await _picturesStoreContext.Models.FirstOrDefaultAsync(m => m.ModelId == id);
                return foundModel;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting model by ID: " + ex.Message);
            }
        }
    }
}
