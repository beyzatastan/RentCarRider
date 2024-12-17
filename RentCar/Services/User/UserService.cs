using Microsoft.EntityFrameworkCore;
using RentCar.Data;
using RentCar.DTOS.UserDTO;
using RentCar.Model;

namespace RentCar.Services.User;

public class UserService : IUserService
{
    private readonly DataContext _context;

    public UserService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<UserModel>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<UserModel?> GetSingleUser(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<string> Register(AddUserDto dto)
    {
        if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
            return "Email already in use";

        var user = new UserModel
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            PhoneNumber = dto.PhoneNumber,
            Role = dto.Role
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return "User registered successfully";
    }

    public async Task<UserModel?> Login(AddUserDto dto)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == dto.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            return null;

        return user;
    }

    public async Task<UserModel?> UpdateUser(UpdateUserDto dto)
    {
        var user = await _context.Users.FindAsync(dto.Id);
        if (user == null) return null;

        user.FirstName = dto.FirstName ?? user.FirstName;
        user.LastName = dto.LastName ?? user.LastName;
        user.Email = dto.Email ?? user.Email;
        user.PasswordHash = dto.Password != null ? BCrypt.Net.BCrypt.HashPassword(dto.Password) : user.PasswordHash;
        user.PhoneNumber = dto.PhoneNumber ?? user.PhoneNumber;

        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<bool> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return false;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }
}
