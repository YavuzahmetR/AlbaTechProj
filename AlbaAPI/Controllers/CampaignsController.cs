using AutoMapper;
using Layer.Core.DTOs;
using Layer.Core.Models;
using Layer.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlbaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignsController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Campaigns> _service;


        public CampaignsController(IMapper mapper, IService<Campaigns> service)
        {
            _mapper = mapper;
            _service = service;

        }
        // GET api/products
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var campaigns = await _service.GetAllAsync();
            var campaignsDto = _mapper.Map<List<CampaignsDto>>(campaigns.ToList());
            return CreateActionResult(ResponseDto<List<CampaignsDto>>.Success(campaignsDto, 200));
        }
        //GET /api/products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var campaign = await _service.GetByIdAsync(id);
            var campaignDto = _mapper.Map<CampaignsDto>(campaign);
            return CreateActionResult(ResponseDto<CampaignsDto>.Success(campaignDto, 200));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CampaignsDto campaignsDto)
        {
            var campaign = await _service.AddAsync(_mapper.Map<Campaigns>(campaignsDto));
            var campaignDto = _mapper.Map<CampaignsDto>(campaign);
            return CreateActionResult(ResponseDto<CampaignsDto>.Success(campaignDto, 201));
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, CampaignsUpdateDto campaignsUpdateDto)
        {

            var campaign = await _service.GetByIdAsync(id);

            if (campaign == null)
            {
                return NotFound();
            }

            campaign.Name = campaignsUpdateDto.Name;
            campaign.UpdatedDate = DateTime.Now;
            campaign.UpdatedBy = campaignsUpdateDto.UpdatedBy.Name;
            campaign.Status = campaignsUpdateDto.Status;
            campaign.Priority = campaignsUpdateDto.Priority;
            campaign.CampaignType = campaignsUpdateDto.CampaignType;

            
            await _service.UpdateAsync(campaign);

            return CreateActionResult(ResponseDto<NoContentDto>.Success(204));
        }
        //DELETE api/products/5
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var campaign = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(campaign);
            return CreateActionResult(ResponseDto<NoContentDto>.Success(204));
        }
    }
}
