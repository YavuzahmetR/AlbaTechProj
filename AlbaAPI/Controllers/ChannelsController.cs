using AutoMapper;
using Layer.Core.DTOs;
using Layer.Core.Models;
using Layer.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlbaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChannelsController : BaseController
    {
        private readonly IService<Channels> _service;
        private readonly IMapper _mapper;
        public ChannelsController(IService<Channels> service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var channels = await _service.GetAllAsync();
            var channelsDto = _mapper.Map<List<ChannelsDto>>(channels.ToList());
            return CreateActionResult(ResponseDto<List<ChannelsDto>>.Success(channelsDto, 200));
        }
        //GET /api/products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var channels = await _service.GetByIdAsync(id);
            var channelsDto = _mapper.Map<ChannelsDto>(channels);
            return CreateActionResult(ResponseDto<ChannelsDto>.Success(channelsDto, 200));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ChannelsDto channelsDto)
        {
            var channels = await _service.AddAsync(_mapper.Map<Channels>(channelsDto));
            var channelDto = _mapper.Map<ChannelsDto>(channels);
            return CreateActionResult(ResponseDto<ChannelsDto>.Success(channelDto, 201));
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, ChannelsUpdateDto channelsUpdateDto)
        {

            var channels = await _service.GetByIdAsync(id);

            if (channels == null)
            {
                return NotFound();
            }

            channels.UpdatedDate = DateTime.Now;
            channels.UpdatedBy = channelsUpdateDto.UpdatedBy.Name;
            channels.ChannelType = channelsUpdateDto.ChannelType;

            // Güncelleme işlemini gerçekleştirin (directly using the campaign object)
            await _service.UpdateAsync(channels);

            return CreateActionResult(ResponseDto<NoContentDto>.Success(204));
        }
        //DELETE api/products/5
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var channels = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(channels);
            return CreateActionResult(ResponseDto<NoContentDto>.Success(204));
        }
    }
}
