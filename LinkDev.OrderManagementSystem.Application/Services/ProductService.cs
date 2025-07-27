using AutoMapper;
using LinkDev.OrderManagementSystem.Application.Abstraction.Contracts;
using LinkDev.OrderManagementSystem.Application.Abstraction.Dtos.Products;
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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var repo = _unitOfWork.GetRepository<Product, int>();
            var products = await repo.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var repo = _unitOfWork.GetRepository<Product, int>();
            var product = await repo.GetAsync(id);
            return _mapper.Map<ProductDto?>(product);
        }

        public async Task<int> CreateProductAsync(CreateProductDto dto)
        {
            var repo = _unitOfWork.GetRepository<Product, int>();
            var product = _mapper.Map<Product>(dto);
            await repo.AddAsync(product);
            await _unitOfWork.CompleteAsync();
            return product.Id;
        }

        public async Task<bool> UpdateProductAsync(int id, UpdateProductDto dto)
        {
            var product = await _unitOfWork.GetRepository<Product, int>().GetAsync(id);
            if (product == null) 
                return false;

            _mapper.Map(dto, product);
            _unitOfWork.GetRepository<Product, int>().Update(product);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _unitOfWork.GetRepository<Product, int>().GetAsync(id);
            if (product == null) return false;

            _unitOfWork.GetRepository<Product, int>().Delete(product);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
