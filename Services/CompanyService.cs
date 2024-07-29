using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Company> AddCompany(Company company)
        {
            // Implement the logic to add a new company using the repository
            return await _companyRepository.addCompany(company);
        }

        public async Task<List<Company>> GetCompanies()
        {
            // Implement the logic to get all companies using the repository
            return await _companyRepository.getCompanies();
        }

        public async Task<Company> GetCompanyById(int id)
        {
            // Implement the logic to get a company by ID using the repository
            return await _companyRepository.getCompanyById(id);
        }
    }
}
