using AutoMapper;
using Layer.Core.DTOs;
using Layer.Core.Models;
using Layer.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlbaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignChannelsController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<CampaignChannels> _service;


        public CampaignChannelsController(IMapper mapper, IService<CampaignChannels> service)
        {
            _mapper = mapper;
            _service = service;

        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var campaignChannels = await _service.GetAllAsync();
            var campaignChannelsDto = _mapper.Map<List<CampaignChannelsDto>>(campaignChannels.ToList());
            return CreateActionResult(ResponseDto<List<CampaignChannelsDto>>.Success(campaignChannelsDto, 200));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var campaignChannels = await _service.GetByIdAsync(id);
            var campaignsChannelsDto = _mapper.Map<CampaignChannelsDto>(campaignChannels);
            return CreateActionResult(ResponseDto<CampaignChannelsDto>.Success(campaignsChannelsDto, 200));
        }
        [HttpPost]
        public async Task<IActionResult> Save(CampaignChannelsDto campaignChannelsDto)
        {
            var campaignChannels = await _service.AddAsync(_mapper.Map<CampaignChannels>(campaignChannelsDto));
            var campaignsChannelsDto = _mapper.Map<CampaignChannelsDto>(campaignChannels);
            return CreateActionResult(ResponseDto<CampaignChannelsDto>.Success(campaignsChannelsDto, 201));
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, CampaignChannelsUpdateDto campaignChannelsUpdateDto)
        {
            var campaignChannels = await _service.GetByIdAsync(id);
            if (campaignChannels == null)
            {
                return NotFound();
            }
            campaignChannels.CampaignsId = campaignChannelsUpdateDto.CampaignsId;
            campaignChannels.ChannelsId = campaignChannelsUpdateDto.ChannelsId;
            if (campaignChannelsUpdateDto.CampaignsId == null && campaignChannelsUpdateDto.ChannelsId == null)
            {
                return BadRequest("Verilen Id'ye uygun bir Kampanya veya Kanal bulunmamaktadır.");
            }
            campaignChannels.UpdatedDate = DateTime.Now;
            campaignChannels.Status = campaignChannelsUpdateDto.Status;
            campaignChannels.UpdatedBy = campaignChannelsUpdateDto.UpdatedBy.Name;
            await _service.UpdateAsync(campaignChannels);

            return CreateActionResult(ResponseDto<NoContentDto>.Success(204));

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var campaignChannels = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(campaignChannels);
            return CreateActionResult(ResponseDto<NoContentDto>.Success(204));
        }
    }
}
