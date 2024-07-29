// LandlordController.cs

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Services;

[Route("api/[controller]")]
[ApiController]
public class LandlordController : ControllerBase
{
    private readonly ILandlordService _landlordService;

    public LandlordController(ILandlordService landlordService)
    {
        _landlordService = landlordService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var landlords = await _landlordService.GetLandlords();
        return Ok(landlords);
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] Landlord landlord)
    {
        var landlord1 = await _landlordService.GetLandlordById(landlord);

        if (landlord1 == null)
        {
            return NotFound();
        }

        return Ok(landlord1);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Landlord landlord)
    {
        if (landlord == null)
        {
            return BadRequest();
        }

        var addedLandlord = await _landlordService.AddLandlord(landlord);

        return CreatedAtAction(nameof(Get), new { id = addedLandlord.LandlordId }, addedLandlord);
    }

  
}
