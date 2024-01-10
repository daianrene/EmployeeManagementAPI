using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.DTOs;
using EmployeeManagementAPI.Helpers;
using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Repositories.IRepositories;
using EmployeeManagementAPI.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Constants = EmployeeManagementAPI.Helpers.Constants;

namespace EmployeeManagementAPI.Repositories
{
    public class UserAccountRepository : IUserAccount
    {
        private readonly JwtConfig _jwtConfig;
        private readonly AppDbContext _appDbContext;

        public UserAccountRepository(IOptions<JwtConfig> jwtConfig, AppDbContext appDbContext)
        {
            _jwtConfig = jwtConfig.Value;
            _appDbContext = appDbContext;
        }

        public async Task<GeneralResponse> CreateAsync(Register user)
        {
            if (user == null)
                return new GeneralResponse(false, "Model is empty");

            var checkUser = await _appDbContext.ApplicationUsers
                .FirstOrDefaultAsync(u => u.Email!.ToLower() == user.Email!.ToLower());
            if (checkUser != null)
                return new GeneralResponse(true, "User registered already");


            var newUser = new ApplicationUser()
            {
                Email = user.Email,
                Name = user.Fullname!,
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password)
            };

            var result = _appDbContext.Add(newUser);
            await _appDbContext.SaveChangesAsync();

            // If there is no admin yet, create it
            var checkAdminRole = await _appDbContext.SystemRoles
                .FirstOrDefaultAsync(r => r.Name! == Constants.Admin);

            if (checkAdminRole == null)
            {
                var createAdminSystemRole = _appDbContext.Add(new SystemRole() { Name = Constants.Admin });
                await _appDbContext.SaveChangesAsync();

                _appDbContext.Add(new UserRole() { RoleId = createAdminSystemRole.Entity.Id, UserId = result.Entity.Id });
                await _appDbContext.SaveChangesAsync();

                return new GeneralResponse(true, "Account created!");
            }

            var checkUserRole = await _appDbContext.SystemRoles.FirstOrDefaultAsync(r => r.Name!.Equals(Constants.User));
            if (checkUserRole == null)
            {
                var createUserSystemRole = _appDbContext.Add(new SystemRole() { Name = Constants.User });
                await _appDbContext.SaveChangesAsync();

                _appDbContext.Add(new UserRole() { RoleId = createUserSystemRole.Entity.Id, UserId = result.Entity.Id });
                await _appDbContext.SaveChangesAsync();

                return new GeneralResponse(true, "Account created!");
            }

            _appDbContext.Add(new UserRole() { RoleId = checkUserRole.Id, UserId = result.Entity.Id });
            await _appDbContext.SaveChangesAsync();
            return new GeneralResponse(true, "Account created!");
        }
        public async Task<LoginResponse> SignInAsync(Login user)
        {
            if (user == null)
                return new LoginResponse(false, "Model is empty");

            var applicationUser = await _appDbContext.ApplicationUsers
                .FirstOrDefaultAsync(u => u.Email!.ToLower() == user.Email!.ToLower());
            if (applicationUser == null)
                return new LoginResponse(false, "User not found");

            // Verify Password
            if (!BCrypt.Net.BCrypt.Verify(user.Password, applicationUser.Password))
                return new LoginResponse(false, "Email or Password not valid");

            var getUserRole = await _appDbContext.UserRoles.FirstOrDefaultAsync(u => u.UserId == applicationUser.Id);
            if (getUserRole == null)
                return new LoginResponse(false, "User role not found!");

            var getRoleName = await _appDbContext.SystemRoles.FirstOrDefaultAsync(r => r.Id == getUserRole.RoleId);
            if (getRoleName == null)
                return new LoginResponse(false, "User role not found" + getUserRole.Id);

            string jwtToken = GenerateToken(applicationUser, getRoleName.Name!);
            string refreshToken = GenerateRefreshToken();

            //Save RefreshToken
            var findUser = await _appDbContext.RefreshTokenInfos.FirstOrDefaultAsync(u => u.UserId == applicationUser.Id);
            if (findUser != null)
            {
                findUser!.Token = refreshToken;
                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                _appDbContext.Add(new RefreshTokenInfo() { Token = refreshToken, UserId = applicationUser.Id });
                await _appDbContext.SaveChangesAsync();
            }

            return new LoginResponse(true, "Login succesfully", jwtToken, refreshToken);
        }

        private string GenerateToken(ApplicationUser user, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Key!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new List<Claim>(){
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name!),
                new Claim(ClaimTypes.Email,user.Email!),
                new Claim(ClaimTypes.Role,role)
            };

            var token = new JwtSecurityToken(
                claims: userClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string GenerateRefreshToken() => Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

        public async Task<LoginResponse> RefreshTokenAsync(RefreshToken token)
        {
            if (token == null)
                return new LoginResponse(false, "Modle is empty");

            var findToken = await _appDbContext.RefreshTokenInfos.FirstOrDefaultAsync(t => t.Token == token.Token);
            if (findToken == null)
                return new LoginResponse(false, "Refresh token is required");

            var user = await _appDbContext.ApplicationUsers.FirstOrDefaultAsync(u => u.Id == findToken.UserId);
            if (user == null)
                return new LoginResponse(false, "Refresh token could not be generated because user not found");

            var userRole = await _appDbContext.UserRoles.FirstOrDefaultAsync(u => u.UserId == user.Id);
            var roleName = await _appDbContext.SystemRoles.FirstOrDefaultAsync(r => r.Id == userRole!.RoleId);
            string jwtToken = GenerateToken(user, roleName!.Name!);
            string refreshToken = GenerateRefreshToken();

            var updateRefreshToken = await _appDbContext.RefreshTokenInfos.FirstOrDefaultAsync(r => r.UserId == user.Id);
            if (updateRefreshToken == null)
                return new LoginResponse(false, "Refresh token could not be generated because user has not signed in");

            updateRefreshToken.Token = refreshToken;
            await _appDbContext.SaveChangesAsync();
            return new LoginResponse(true, "Token refreshed", jwtToken, refreshToken);
        }

        public async Task<List<ManageUser>> GetUsers()
        {

            var allUsers = await GetApplicationsUsers();
            var allUserRoles = await UserRoles();
            var allRoles = await SystemRoles();

            if (allUserRoles.Count == 0 || allRoles.Count == 0)
                return null!;

            var users = new List<ManageUser>();
            foreach (var user in allUsers)
            {
                var userRole = allUserRoles.FirstOrDefault(u => u.UserId == user.Id);
                var roleName = allRoles.FirstOrDefault(r => r.Id == userRole!.RoleId);
                users.Add(new ManageUser() { UserId = user.Id, Name = user.Name!, Email = user.Email!, Role = roleName!.Name! });
            }
            return users;
        }

        public async Task<GeneralResponse> UpdateUser(ManageUser user)
        {
            var getRole = (await SystemRoles()).FirstOrDefault(r => r.Name!.Equals(user.Role));
            var userRole = await _appDbContext.UserRoles.FirstOrDefaultAsync(u => u.UserId == user.UserId);
            userRole!.RoleId = getRole!.Id;
            await _appDbContext.SaveChangesAsync();
            return new GeneralResponse(true, "User role updated succesfully");
        }

        public async Task<List<SystemRole>> GetRoles() => await SystemRoles();

        public async Task<GeneralResponse> DeleteUser(int id)
        {
            var user = await _appDbContext.ApplicationUsers.FirstOrDefaultAsync(u => u.Id == id);
            _appDbContext.ApplicationUsers.Remove(user!);
            await _appDbContext.SaveChangesAsync();
            return new GeneralResponse(true, "User succesfully deleted");
        }

        private async Task<List<SystemRole>> SystemRoles() => await _appDbContext.SystemRoles.AsNoTracking().ToListAsync();
        private async Task<List<UserRole>> UserRoles() => await _appDbContext.UserRoles.AsNoTracking().ToListAsync();
        private async Task<List<ApplicationUser>> GetApplicationsUsers() => await _appDbContext.ApplicationUsers.AsNoTracking().ToListAsync();

    }
}