using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Core.Model.Request;
using TaskManager.Core.ServiceInterface;

namespace TaskManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController:ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> ListAllUser()
        {
            var users = await _userService.GetAllUser();
            return Ok(users);
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            return user is null? NotFound():Ok(user);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> CreateUser(UserRegisterRequest userRegisterRequest)
        {
            if (!ModelState.IsValid) return BadRequest("Invalidate Data");
            var res = await _userService.Register(userRegisterRequest);
            return Ok(res);
        } 
        
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateUser(UserUpdateRequest userUpdateRequest)
        {
            if (!ModelState.IsValid) return BadRequest("Invalidate Data");
            var res = await _userService.UpdateUser(userUpdateRequest);
            return Ok(res);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUser(id);
            return Ok();
        } 
    }
}