using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Services;

[Route("api/[controller]")]
[ApiController]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;

    public CarController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var cars = await _carService.GetCars();
        return Ok(cars);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Car car)
    {
        if (car == null)
        {
            return BadRequest();
        }

        var addedCar = await _carService.AddCar(car);

        return CreatedAtAction(nameof(Get), new { id = addedCar.CarId }, addedCar);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _carService.DeleteCar(id);

        if (deleted == null)
        {
            return NotFound();
        }

        return NoContent();
    }

}
