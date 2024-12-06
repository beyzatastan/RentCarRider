using Microsoft.AspNetCore.Mvc;
using RentCar.Model;
using RentCar.Services.User;

namespace RentCar.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController: ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<UserModel>>>  GetAllUsers()
    {
        var users = await _userService.GetAllUsers();
        return Ok(users);
    }
        
    [HttpGet("{id}")]
    //[Route(("{id}"))]
    public async Task<IActionResult> GetSingleUser(int id)
    {
        var result = await _userService.GetSingleUser(id);
        if(result is null)
            return NotFound("not found");
                
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> AddUser(UserModel user)
    {
        var result = await _userService.AddUser(user)!;
        if(result is null)
            return NotFound("not found");
                
        return Ok(result);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser (int id, UserModel request)
    { 
        var result = await _userService.UpdateUser(id,request);
        if(result is null)
            return NotFound("not found");
                
        return Ok(result);
    }
         
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser (int id)
    {
        var result =await _userService.DeleteUser(id);
        if(result is null)
            return NotFound("not found");
                
        return Ok(result);
    }
}