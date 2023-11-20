using AutoMapper;
using Layer.Core.DTOs;
using Layer.Core.Models;
using Layer.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlbaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerCampaignsController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<CustomerCampaigns> _service;

        public CustomerCampaignsController(IMapper mapper, IService<CustomerCampaigns> service)
        {
            _mapper = mapper;
            _service = service;
        }
        // GET api/products 
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var customerCampaigns = await _service.GetAllAsync();
            var customerCampaignsDto = _mapper.Map<List<CustomerCampaignsDto>>(customerCampaigns.ToList());
            return CreateActionResult(ResponseDto<List<CustomerCampaignsDto>>.Success(customerCampaignsDto, 200));
        }
        //GET /api/products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customerCampaigns = await _service.GetByIdAsync(id);
            var customerCampaignsDto = _mapper.Map<CustomerCampaignsDto>(customerCampaigns);
            return CreateActionResult(ResponseDto<CustomerCampaignsDto>.Success(customerCampaignsDto, 200));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CustomerCampaignsDto customerCampaignDto)
        {
            var customerCampaigns = await _service.AddAsync(_mapper.Map<CustomerCampaigns>(customerCampaignDto));
            var customerCampaignsDto = _mapper.Map<CustomerCampaignsDto>(customerCampaigns);
            return CreateActionResult(ResponseDto<CustomerCampaignsDto>.Success(customerCampaignsDto, 201));
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, CustomerCampaignsUpdateDto customerCampaignsUpdateDto)
        {

            var customerCampaigns = await _service.GetByIdAsync(id);

            if (customerCampaigns == null)
            {
                return NotFound();
            }
            customerCampaigns.CampaignsId = customerCampaignsUpdateDto.CampaignsId;
            customerCampaigns.CustomersId = customerCampaignsUpdateDto.CustomersId;
            if (customerCampaignsUpdateDto.CampaignsId == null && customerCampaignsUpdateDto.CustomersId == null)
            {
                return BadRequest("Verilen Id'ye uygun bir Kampanya veya Müşteri bulunmamaktadır.");
            }
            customerCampaigns.UpdatedDate = DateTime.Now;
            customerCampaigns.UpdatedBy = customerCampaignsUpdateDto.UpdatedBy.Name;

            // Güncelleme işlemini gerçekleştirin (directly using the campaign object)
            await _service.UpdateAsync(customerCampaigns);

            return CreateActionResult(ResponseDto<NoContentDto>.Success(204));
        }
        //DELETE api/products/5
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var customerCampaigns = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(customerCampaigns);
            return CreateActionResult(ResponseDto<NoContentDto>.Success(204));
        }
    }
}
