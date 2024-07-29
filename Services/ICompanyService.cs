using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface ICompanyService
    {
        Task<Company> AddCompany(Company company);
        Task<List<Company>> GetCompanies();
        Task<Company> GetCompanyById(int id);
        Task<Company> UpdateCompany(int id, Company companyToUpdate);
    }
}
