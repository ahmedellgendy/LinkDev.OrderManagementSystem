using LinkDev.OrderManagementSystem.Application.Abstraction.Dtos.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.OrderManagementSystem.Application.Abstraction.Contracts
{
    public interface IInvoiceService
    {
        Task<IEnumerable<InvoiceDto>> GetAllAsync();
        Task<InvoiceDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(InvoiceCreateDto dto);
        Task<bool> UpdateAsync(int id, InvoiceUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
