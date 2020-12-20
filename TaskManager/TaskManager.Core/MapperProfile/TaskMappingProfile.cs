using AutoMapper;
using TaskManager.Core.Entities;
using TaskManager.Core.Model.Request;
using TaskManager.Core.Model.Response;

namespace TaskManager.Core.MapperProfile
{
    public class TaskMappingProfile:Profile
    {
        public TaskMappingProfile()
        {
            // User
            CreateMap<User, UserResponse>();
            CreateMap<UserRegisterRequest, User>();
            CreateMap<UserUpdateRequest, User>();
            
            // Tasks
            CreateMap<Tasks, TaskResponse>()
                .ForMember(dest => dest.UserEmail,
                    opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.UserFullName,
                    opt => opt.MapFrom(src => src.User.Fullname));
            CreateMap<TaskCreateRequest, Tasks>();
            
            // Task History
            CreateMap<TaskHistory, TaskHistoryResponse>()
                .ForMember(dest => dest.UserEmail,
                    opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.UserFullName,
                    opt => opt.MapFrom(src => src.User.Fullname));
            CreateMap<TaskHistoryUpdateRequest, TaskHistory>();
            CreateMap<Tasks, TaskHistory>()
                .ForMember(dest=>dest.TaskId,opt=>opt.MapFrom(src=>src.Id));
        }
    }
}