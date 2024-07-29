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

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var car = await _carService.GetCarById(id);

        if (car == null)
        {
            return NotFound();
        }

        return Ok(car);
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

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Car car)
    {
        if (id != car.CarId)
        {
            return BadRequest();
        }

        var existingCar = await _carService.GetCarById(id);

        if (existingCar == null)
        {
            return NotFound();
        }

        await _carService.UpdateCar(id, car);

        return NoContent();
    }

    //[HttpDelete("{id}")]
    //public async Task<IActionResult> Delete(int id)
    //{
    //    var existingCar = await _carService.GetCarById(id);

    //    if (existingCar == null)
    //    {
    //        return NotFound();
    //    }

    //    await _carService.DeleteCar(id);

    //    return NoContent();
    //}
}
