
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;
namespace Repositories
{
    public class ModelRepository : IModelRepository
    {
        private CarRetalContext _picturesStoreContext;

        public ModelRepository(CarRetalContext picturesStoreContext)
        {
            _picturesStoreContext = picturesStoreContext;
        }

        public async Task<Model> addModel(Model user)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Model>> getModels()
        {
            var foundModels = await _picturesStoreContext.Models.ToListAsync();
            if (foundModels == null)
                return null;
            return foundModels;
        }

        public async Task<Model> getModelById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Model> updateModel(int id, Model ModelToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
