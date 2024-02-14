using AutoMapper;
using MVC.Data.Dto;
using MVC.Models;

namespace MVC.Profiles;

/// <summary>
/// Profile for mapping between DTOs (Data Transfer Objects) and models.
/// </summary>
public class MVCProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MVCProfile"/> class.
    /// </summary>
    public MVCProfile()
    {
        CreateMap<CreateUserDto, User>();
        CreateMap<UpdateUserDto, User>(); 
        CreateMap<User, UpdateUserDto>();
        CreateMap<User, ReadUserDto>();
    }
}
