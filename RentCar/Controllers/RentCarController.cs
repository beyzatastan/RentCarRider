using Microsoft.AspNetCore.Mvc;
using RentCar.Model;
using RentCar.Services;

namespace RentCar.Controllers;
[ApiController]
[Route("api/[controller]")]
public class RentCarController: ControllerBase
{
    private readonly IRentCarService _rentCarService;

    public RentCarController(IRentCarService rentCarService)
    {
        _rentCarService = rentCarService;
    }
    [HttpGet]
    public async Task<ActionResult<List<CarModel>>>  GetAllCars()
    {
        return await _rentCarService.GetAllCars();
    }
        
    [HttpGet("{id}")]
    //[Route(("{id}"))]
    public async Task<IActionResult> GetSingleCar(int id)
    {
        var result = await _rentCarService.GetSingleCar(id);
        if(result is null)
            return NotFound("not found");
                
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> AddCar(CarModel car)
    {
        var result = await _rentCarService.AddCar(car);
        if(result is null)
            return NotFound("not found");
                
        return Ok(result);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCar (int id, CarModel request)
    { 
        var result = await _rentCarService.UpdateCar(id,request);
        if(result is null)
            return NotFound("not found");
                
        return Ok(result);
    }
         
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCar (int id)
    {
        var result =await _rentCarService.DeleteCar(id);
        if(result is null)
            return NotFound("not found");
                
        return Ok(result);
    }
}