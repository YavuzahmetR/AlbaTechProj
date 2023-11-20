using AutoMapper;
using Layer.Core.DTOs;
using Layer.Core.Models;
using Layer.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlbaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Customers> _service;

        public CustomerController(IMapper mapper, IService<Customers> service)
        {
            _mapper = mapper;
            _service = service;
        }
        // GET api/products
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var customers = await _service.GetAllAsync();
            var customersDto = _mapper.Map<List<CustomersDto>>(customers.ToList());
            return CreateActionResult(ResponseDto<List<CustomersDto>>.Success(customersDto, 200));
        }
        //GET /api/products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customers = await _service.GetByIdAsync(id);
            var customersDto = _mapper.Map<CustomersDto>(customers);
            return CreateActionResult(ResponseDto<CustomersDto>.Success(customersDto, 200));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CustomersDto customersDto)
        {
            var customers = await _service.AddAsync(_mapper.Map<Customers>(customersDto));
            var customerDto = _mapper.Map<CustomersDto>(customers);
            return CreateActionResult(ResponseDto<CustomersDto>.Success(customerDto, 201));
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, CustomersUpdateDto campaignsUpdateDto)
        {

            var customers = await _service.GetByIdAsync(id);

            if (customers == null)
            {
                return NotFound();
            }

            customers.UpdatedDate = DateTime.Now;
            customers.UpdatedBy = campaignsUpdateDto.UpdatedBy.Name;
            customers.CustomerName = campaignsUpdateDto.CustomerName;
            customers.CustomerNo = campaignsUpdateDto.CustomerNo;

            // Güncelleme işlemini gerçekleştirin (directly using the campaign object)
            await _service.UpdateAsync(customers);

            return CreateActionResult(ResponseDto<NoContentDto>.Success(204));
        }
        //DELETE api/products/5
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var customers = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(customers);
            return CreateActionResult(ResponseDto<NoContentDto>.Success(204));
        }

    }
}

