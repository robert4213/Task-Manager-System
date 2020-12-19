using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManager.Core.Entities;
using TaskManager.Core.Model.Request;
using TaskManager.Core.Model.Response;

namespace TaskManager.Core.ServiceInterface
{
    public interface IUserService
    {
        Task<IEnumerable<UserDetailResponse>> GatAllUser();
        
        Task<UserDetailResponse> Register(UserRegisterRequest userRegisterRequest);
        Task<UserDetailResponse> UpdateUser(UserUpdateRequest userRegisterRequest);
        Task DeleteUser(int id);
    }
}