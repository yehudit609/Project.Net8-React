
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private CarRetalContext _picturesStoreContext;

        public CompanyRepository(CarRetalContext picturesStoreContext)
        {
            _picturesStoreContext = picturesStoreContext;
        }

        public async Task<Company> addCompany(Company Company)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Company>> getCompanies()
        {
            var foundCompanies = await _picturesStoreContext.Companies.ToListAsync();
            if (foundCompanies == null)
                return null;
            return foundCompanies;
        }

        public async Task<Company> getCompanyById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Company> updateCompany(int id, Company CompanyToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
