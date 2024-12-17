using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCar.Data;
using RentCar.DTOS.CustomerDTO;
using RentCar.DTOS.UserDTO;
using RentCar.Model;
using RentCar.Services.User;

namespace RentCar.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly DataContext _context;

    public UserController(IUserService userService, DataContext context)
    {
        _userService = userService;
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserModel>>> GetAllUsers()
    {
        var users = await _userService.GetAllUsers();
        return Ok(users);
    }

    [HttpGet("{id}")]
    //[Route(("{id}"))]
    public async Task<IActionResult> GetSingleUser(int id)
    {
        var result = await _userService.GetSingleUser(id);
        if (result is null)
            return NotFound("not found");

        return Ok(result);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] AddUserDto dto)
    {
        if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
            return BadRequest("Email already in use");

        var user = new UserModel
        {
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password), // Şifreyi hash'liyoruz
            Role = "User" // İlk kayıt olduğunda müşteri değil
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok("User registered successfully");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AddUserDto dto)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == dto.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            return Unauthorized("Invalid credentials");

        // JWT veya başka bir token üretilebilir
        return Ok(new { Message = "Login successful" });
    }

    [HttpPost("{userId}/upgrade")]
    public async Task<IActionResult> UpgradeToCustomer(int userId, [FromBody] AddCustomerDto dto)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user == null) return NotFound("User not found");

        if (user.Role=="Customer") return BadRequest("User is already a customer");

        var customer = new CustomerModel
        {
            UserId = userId,
            IdentityNumber = dto.IdentityNumber,
            DrivingLicenseNumber = dto.DrivingLicenseNumber,
            DrivingLicenseIssuedDate = dto.DrivingLicenseIssuedDate,
            BirthDate = dto.BirthDate,
            Phone = dto.Phone,
            City = dto.City,
            District = dto.District,
            Address = dto.Address,
            PostalCode = dto.PostalCode
        };

        user.Role = "Customer" ;
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();

        return Ok("User upgraded to customer");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var result = await _userService.DeleteUser(id);
     

        return Ok(result);
    }
}