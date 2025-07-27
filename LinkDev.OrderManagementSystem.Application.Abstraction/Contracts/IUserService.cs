using AutoMapper;
using LinkDev.OrderManagementSystem.Application.Abstraction.Dtos.Users;
using LinkDev.OrderManagementSystem.Domain.Contracts;
using LinkDev.OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.OrderManagementSystem.Application.Abstraction.Contracts
{
    public interface IUserService
    {

        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto?> GetUserByIdAsync(int id);
        Task<int> CreateUserAsync(CreateUserDto userDto);
        Task UpdateUserAsync(UpdateUserDto userDto);
        Task DeleteUserAsync(int id);

        

    }
}
