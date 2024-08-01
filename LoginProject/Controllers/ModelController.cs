using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Services;

[Route("api/[controller]")]
[ApiController]
public class ModelController : ControllerBase
{
    private readonly IModelService _modelService;

    public ModelController(IModelService modelService)
    {
        _modelService = modelService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var models = await _modelService.GetModels();
        return Ok(models);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var model = await _modelService.GetModelById(id);

        if (model == null)
        {
            return NotFound();
        }

        return Ok(model);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Model model)
    {
        if (model == null)
        {
            return BadRequest();
        }

        var addedModel = await _modelService.AddModel(model);

        return CreatedAtAction(nameof(Get), new { id = addedModel.ModelId }, addedModel);
    }
  
}
