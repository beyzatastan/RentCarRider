using RentCar.DTOS.UserDTO;
using RentCar.Model;

namespace RentCar.Services.User;

public interface IUserService
{
    Task<List<UserModel>> GetAllUsers();
    Task<UserModel?> GetSingleUser(int id);
    Task<string> Register(AddUserDto dto);
    Task<UserModel?> Login(AddUserDto dto);
    Task<UserModel?> UpdateUser(UpdateUserDto dto);
    Task<bool> DeleteUser(int id);
}