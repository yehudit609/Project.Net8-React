using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface IModelService
    {
        Task<Model> AddModel(Model model);
        Task<List<Model>> GetModels();
        Task<Model> GetModelById(int id);
        Task<Model> UpdateModel(int id, Model modelToUpdate);
    }
}
