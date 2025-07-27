using LinkDev.OrderManagementSystem.Application.Abstraction.Contracts;
using LinkDev.OrderManagementSystem.Application.Abstraction.Dtos.Invoices;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.OrderManagementSystem.APIs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        // GET: api/invoice
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceDto>>> GetAll()
        {
            var invoices = await _invoiceService.GetAllAsync();
            return Ok(invoices);
        }

        // GET: api/invoice/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceDto>> GetById(int id)
        {
            var invoice = await _invoiceService.GetByIdAsync(id);
            if (invoice == null) return NotFound();
            return Ok(invoice);
        }

        // POST: api/invoice
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] InvoiceCreateDto dto)
        {
            var createdId = await _invoiceService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdId }, null);
        }

        // PUT: api/invoice/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] InvoiceUpdateDto dto)
        {
            var updated = await _invoiceService.UpdateAsync(id, dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        // DELETE: api/invoice/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _invoiceService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}

