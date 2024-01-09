using EmployeeManagementAPI.DTOs;
using EmployeeManagementAPI.Responses;

namespace EmployeeManagementAPI.Repositories.IRepositories
{
    public interface IUserAccount
    {
        Task<GeneralResponse> CreateAsync(Register user);
        Task<LoginResponse> SignInAsync(Login user);
        Task<LoginResponse> RefreshTokenAsync(RefreshToken refreshToken);
    }
}
