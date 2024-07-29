using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class ModelService : IModelService
    {
        private readonly IModelRepository _modelRepository;

        public ModelService(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }

        public async Task<Model> AddModel(Model model)
        {
            // Implement the logic to add a new model using the repository
            return await _modelRepository.addModel(model);
        }

        public async Task<List<Model>> GetModels()
        {
            // Implement the logic to get all models using the repository
            return await _modelRepository.getModels();
        }

        public async Task<Model> GetModelById(int id)
        {
            // Implement the logic to get a model by ID using the repository
            return await _modelRepository.getModelById(id);
        }

        
    }
}
