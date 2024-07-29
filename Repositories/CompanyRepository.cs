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

        public async Task<Company> addCompany(Company company)
        {
            try
            {
                _picturesStoreContext.Companies.Add(company);
                await _picturesStoreContext.SaveChangesAsync();
                return company;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding company: " + ex.Message);
            }
        }

        public async Task<List<Company>> getCompanies()
        {
            try
            {
                var foundCompanies = await _picturesStoreContext.Companies.ToListAsync();
                return foundCompanies;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting companies: " + ex.Message);
            }
        }

        public async Task<Company> getCompanyById(int id)
        {
            try
            {
                var foundCompany = await _picturesStoreContext.Companies.FirstOrDefaultAsync(c => c.CompanyId == id);
                return foundCompany;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting company by ID: " + ex.Message);
            }
        }
    }
}
