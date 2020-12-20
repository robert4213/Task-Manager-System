using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManager.Core.Entities;
using TaskManager.Core.Model.Request;
using TaskManager.Core.Model.Response;

namespace TaskManager.Core.ServiceInterface
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponse>> GetAllUser();
        Task<UserResponse> GetUserById(int id);
        Task<UserResponse> Register(UserRegisterRequest userRegisterRequest);
        Task<UserResponse> UpdateUser(UserUpdateRequest userRegisterRequest);
        Task DeleteUser(int id);
    }
}