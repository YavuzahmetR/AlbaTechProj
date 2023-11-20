using AutoMapper;
using Layer.Core.DTOs;
using Layer.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlbaAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CampaignController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ICampaignsService _customerCampaignsService;


        public CampaignController(
            IMapper mapper,
             ICampaignsService customerCampaignsService)
        {
            _customerCampaignsService = customerCampaignsService;
            _mapper = mapper;
        }

        [HttpGet("GetSimpleCampaignsByCustomerNo")]
        public async Task<IActionResult> GetSimpleCampaignsByCustomerNo(int customerNo, int channelId)
        {
            var simpleCampaigns = await _customerCampaignsService.GetSimpleCampaignsByCustomerNo(customerNo, channelId);
            return CreateActionResult(ResponseDto<List<SimpleCampaignDto>>.Success(simpleCampaigns, 200));
        }

        
    }
}








