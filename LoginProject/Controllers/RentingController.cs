// RentingController.cs

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Services;

[Route("api/[controller]")]
[ApiController]
public class RentingController : ControllerBase
{
    private readonly IRentingService _rentingService;

    public RentingController(IRentingService rentingService)
    {
        _rentingService = rentingService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var rentings = await _rentingService.GetRentings();
        return Ok(rentings);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var renting = await _rentingService.GetRentingById(id);

        if (renting == null)
        {
            return NotFound();
        }

        return Ok(renting);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Renting renting)
    {
        if (renting == null)
        {
            return BadRequest();
        }

        var addedRenting = await _rentingService.AddRenting(renting);

        return CreatedAtAction(nameof(Get), new { id = addedRenting.RentingId }, addedRenting);
    }

  
}
