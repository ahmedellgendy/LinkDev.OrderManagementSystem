using AutoMapper;
using LinkDev.OrderManagementSystem.Application.Abstraction.Contracts;
using LinkDev.OrderManagementSystem.Application.Abstraction.Dtos.Users;
using LinkDev.OrderManagementSystem.Domain.Contracts;
using LinkDev.OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.OrderManagementSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var repository = _unitOfWork.GetRepository<User, int>();
            var users = await repository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            var repository = _unitOfWork.GetRepository<User, int>();
            var user = await repository.GetAsync(id);
            return _mapper.Map<UserDto?>(user);
        }

        public async Task<int> CreateUserAsync(CreateUserDto userDto)
        {
            var repository = _unitOfWork.GetRepository<User, int>();
            var user = _mapper.Map<User>(userDto);
            await repository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
            return user.Id;
        }

        public async Task UpdateUserAsync(UpdateUserDto userDto)
        {
            var repository = _unitOfWork.GetRepository<User, int>();
            var user = await repository.GetAsync(userDto.Id);

            if (user is null)
                throw new KeyNotFoundException($"User with Id {userDto.Id} not found");

            _mapper.Map(userDto, user);
            repository.Update(user);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var repository = _unitOfWork.GetRepository<User, int>();
            var user = await repository.GetAsync(id);

            if (user is null)
                throw new KeyNotFoundException($"User with Id {id} not found");

            repository.Delete(user);
            await _unitOfWork.CompleteAsync();
        }

       
    }

}
