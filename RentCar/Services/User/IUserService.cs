using RentCar.Model;

namespace RentCar.Services.User;

public interface IUserService
{
    
    Task<List<UserModel>>? GetAllUsers();
    Task<UserModel>? GetSingleUser(int id);
    
    Task<List<UserModel>>? AddUser(UserModel customer);
    
    Task<List<UserModel>>? UpdateUser(int id, UserModel request);
    Task<List<UserModel>>? DeleteUser(int id);
}