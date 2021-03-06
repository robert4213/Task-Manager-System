﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TaskManager.Core.Entities;
using TaskManager.Core.Exceptions;
using TaskManager.Core.Model.Request;
using TaskManager.Core.Model.Response;
using TaskManager.Core.RepositoryInterface;
using TaskManager.Core.ServiceInterface;

namespace TaskManager.Infrastructure.Service
{
    public class UserService:IUserService
    {
        private readonly IAsyncRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IAsyncRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserResponse>> GetAllUser()
        {
            var users = await _userRepository.ListAllAsync();
            var res = _mapper.Map<IEnumerable<UserResponse>>(users);
            return res;
        }

        public async Task<UserResponse> GetUserById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            var res = _mapper.Map<UserResponse>(user);
            return res;
        }

        public async Task<UserResponse> Register(UserRegisterRequest userRegisterRequest)
        {
            var user = _mapper.Map<User>(userRegisterRequest);
            var resUser = await _userRepository.AddAsync(user);
            var res = _mapper.Map<UserResponse>(resUser);
            return res;
        }

        public async Task<UserResponse> UpdateUser(UserUpdateRequest userUpdateRequest)
        {
            var user = _mapper.Map<User>(userUpdateRequest);
            var resUser = await _userRepository.UpdateAsync(user);
            var res = _mapper.Map<UserResponse>(resUser);
            return res;
        }

        public async Task DeleteUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user is null) throw new NotFoundException("User", id);
            await _userRepository.DeleteAsync(user);
        }
    }
}