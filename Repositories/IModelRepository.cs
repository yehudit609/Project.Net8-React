using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IModelRepository
    {
        Task<Model> addModel(Model Model);
        Task<List<Model>> getModels();
        Task<Model> getModelById(int id);
    }
}
