using AutoMapper;
using LinkDev.OrderManagementSystem.Application.Abstraction.Contracts;
using LinkDev.OrderManagementSystem.Application.Abstraction.Dtos.Customers;
using LinkDev.OrderManagementSystem.Application.Abstraction.Repositories;
using LinkDev.OrderManagementSystem.Domain.Contracts;
using LinkDev.OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.OrderManagementSystem.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
        {
            var customers = await _unitOfWork.GetRepository<Customer, int>().GetAllAsync();
            return _mapper.Map<IEnumerable<CustomerDto>>(customers);
        }

        public async Task<CustomerDto?> GetCustomerByIdAsync(int id)
        {
            var customer = await _unitOfWork.GetRepository<Customer, int>().GetAsync(id);
            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<int> CreateCustomerAsync(CreateCustomerDto dto)
        {
            var customer = _mapper.Map<Customer>(dto);
            await _unitOfWork.GetRepository<Customer, int>().AddAsync(customer);
            await _unitOfWork.CompleteAsync();
            return customer.Id;
        }

        public async Task<bool> UpdateCustomerAsync(int id, UpdateCustomerDto dto)
        {
            var repo = _unitOfWork.GetRepository<Customer, int>();
            var existing = await repo.GetAsync(id);

            if (existing is null)
                return false;

            _mapper.Map(dto, existing);
            repo.Update(existing);
            await _unitOfWork.CompleteAsync();
            return true;
        }


        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var repo = _unitOfWork.GetRepository<Customer, int>();
            var customer = await repo.GetAsync(id);

            if (customer is null)
                return false;

            repo.Delete(customer);
            await _unitOfWork.CompleteAsync();
            return true;
        }

    }
}
