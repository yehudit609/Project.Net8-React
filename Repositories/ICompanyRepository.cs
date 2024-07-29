
using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICompanyRepository
    {
        Task<Company> addCompany(Company Company);
        Task<List<Company>> getCompanies();
        Task<Company> getCompanyById(int id);
    }
}
