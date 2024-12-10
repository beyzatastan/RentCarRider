using Microsoft.EntityFrameworkCore;
using RentCar.Data;
using RentCar.Model;

namespace RentCar.Services.User;

public class UserService: IUserService
{
    private readonly DataContext _context;

    public UserService(DataContext context)
    {
        _context = context;
    }
    public async Task<List<UserModel>>? GetAllUsers()
    {
        var users = await _context.Users.ToListAsync();
        return users;
    }

    public async Task<UserModel>? GetSingleUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
            return null;
        return user;
    }
    
    public async Task<List<UserModel>>? AddUser(UserModel user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return await _context.Users.ToListAsync();
    }

    public async Task<List<UserModel>>? UpdateUser(int id, UserModel request)
    {
        var user =  await _context.Users.FindAsync(id);
        if (user is null)
            return null;
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.Email = request.Email;
        user.PasswordHash = request.PasswordHash;
        user.PhoneNumber = request.PhoneNumber;
        user.Role = request.Role;
        await _context.SaveChangesAsync();
        return await _context.Users.ToListAsync();
    }

    public  async Task<List<UserModel>>?  DeleteUser(int id)
    {
        var user =  await _context.Users.FindAsync(id);
        if (user is null)
            return null;
           
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return await _context.Users.ToListAsync();
    }
}