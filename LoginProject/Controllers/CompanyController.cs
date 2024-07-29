// CompanyController.cs

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Services;

[Route("api/[controller]")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var companies = await _companyService.GetCompanies();
        return Ok(companies);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var company = await _companyService.GetCompanyById(id);

        if (company == null)
        {
            return NotFound();
        }

        return Ok(company);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Company company)
    {
        if (company == null)
        {
            return BadRequest();
        }

        var addedCompany = await _companyService.AddCompany(company);

        return CreatedAtAction(nameof(Get), new { id = addedCompany.CompanyId }, addedCompany);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Company company)
    {
        if (id != company.CompanyId)
        {
            return BadRequest();
        }

        var existingCompany = await _companyService.GetCompanyById(id);

        if (existingCompany == null)
        {
            return NotFound();
        }

        await _companyService.UpdateCompany(id, company);

        return NoContent();
    }
}
