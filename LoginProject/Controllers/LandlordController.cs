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

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var landlord = await _landlordService.GetLandlordById(id);

        if (landlord == null)
        {
            return NotFound();
        }

        return Ok(landlord);
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

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Landlord landlord)
    {
        if (id != landlord.LandlordId)
        {
            return BadRequest();
        }

        var existingLandlord = await _landlordService.GetLandlordById(id);

        if (existingLandlord == null)
        {
            return NotFound();
        }

        await _landlordService.UpdateLandlord(id, landlord);

        return NoContent();
    }
}
