using AlbaMVC.HelpfulFunctions;
using AutoMapper;
using Layer.Core.DTOs;
using Layer.Core.Models;
using Layer.Core.Services;
using Layer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace AlbaMVC.Controllers
{
    public class CampaignChannelsController : Controller
    {
        private readonly IService<CampaignChannels> _campaignsService;
        private readonly ICampaignChannelsStatusService _campaignChannelsStatusService;
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;
        public CampaignChannelsController(IService<CampaignChannels> campaignsService, IMapper mapper, AppDbContext appDbContext, ICampaignChannelsStatusService campaignChannelsStatusService)
        {
            _campaignsService = campaignsService;
            _mapper = mapper;
            _appDbContext = appDbContext;
            _campaignChannelsStatusService = campaignChannelsStatusService;
        }
        public async Task<IActionResult> Index(string ara, int idSearch, DateTime? startAction, DateTime? endAction, string channelType, string language)
        {
            var campaignChannels = await _appDbContext.CampaignChannels
        .Include(cc => cc.Campaigns)
        .Include(cc => cc.Channels)
        .ToListAsync();

            var filteredCampaignChannels = campaignChannels
                .Select(cc => new CampaignChannels
                {
                    Id = cc.Id,
                    CampaignsId = cc.CampaignsId,
                    CampaignName = cc.Campaigns.Name,
                    ChannelsId = cc.ChannelsId,
                    ChannelType = cc.Channels.ChannelType,
                    Status = cc.Status,
                    ActionStartTime = cc.ActionStartTime,
                    ActionEndTime = cc.ActionEndTime,
                    LanguageCode = cc.LanguageCode,
                    Description = cc.Description,
                })
                .Where(cc =>
                    (string.IsNullOrEmpty(ara) || cc.CampaignName.Contains(ara)) &&
                    (idSearch == 0 || cc.ChannelType == _appDbContext.Channels.Where(ch => ch.Id == idSearch).Select(ch => ch.ChannelType).FirstOrDefault()) &&
                    (!startAction.HasValue || !endAction.HasValue || (cc.ActionStartTime >= startAction.Value && cc.ActionEndTime <= endAction.Value)) &&
                    (string.IsNullOrEmpty(language) || cc.LanguageCode == _appDbContext.Parameters.Where(p => p.GroupCode == "LanguageType" && p.ParameterValue == language).Select(p => p.ParameterCode).FirstOrDefault())
                )
                .ToList();

            var languages = await _appDbContext.Parameters
                .Where(p => p.GroupCode == "LanguageType")
                .Select(p => new SelectListItem { Text = p.ParameterValue, Value = p.ParameterValue })
                .ToListAsync();
            ViewBag.languages = new SelectList(languages, "Value", "Text");

            return View(filteredCampaignChannels);
        }

        
        [HttpGet]
        public async Task<IActionResult> Save()
        {
            var campaignChannelsName = await _appDbContext.Campaigns.ToListAsync();
            var channelsName = await _appDbContext.Channels.ToListAsync();

            var filteredCampaigns = campaignChannelsName.Select(cc => new CampaignChannels
            {
                CampaignsId = cc.Id,
                CampaignName = cc.Name,
            }).ToList();
            var filteredChannels = channelsName.Select(cc => new CampaignChannels
            {
                ChannelsId = cc.Id,
                ChannelType = cc.ChannelType,
            }).ToList();
            List<SelectListItem> campaignOptions = filteredCampaigns.Select(c => new SelectListItem
            {
                Text = c.CampaignName,
                Value = c.CampaignsId.ToString(),
            })/*.Distinct(new ComparerClass())*/.ToList();
            ViewBag.CampaignOptions = campaignOptions;
            List<SelectListItem> channelOptions = filteredChannels.Select(c => new SelectListItem
            {
                Text = c.ChannelType,
                Value = c.ChannelsId.ToString(),
            })/*.Distinct(new ComparerClass())*/.ToList();
            ViewBag.ChannelOptions = channelOptions;

            List<SelectListItem> languageDeger = (from i in _appDbContext.Parameters
                                                  where i.GroupCode == "LanguageType"
                                                  select new SelectListItem
                                                  {
                                                      Text = i.ParameterValue,
                                                      Value = i.ParameterCode
                                                  })
                                                  .ToList();
            ViewBag.LanguageDeger = languageDeger;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(CampaignChannelsDto campaignChannels)
        {
            if (ModelState.IsValid)
            {
                var selectedCampaign = await _appDbContext.Campaigns.FindAsync(campaignChannels.CampaignsId);
                var selectedChannel = await _appDbContext.Channels.FindAsync(campaignChannels.ChannelsId);
                var languageCode = from p in _appDbContext.Parameters where p.ParameterCode == campaignChannels.LanguageCode select p.ParameterCode;
                foreach (var parameterValue in languageCode)
                {
                    campaignChannels.LanguageCode = parameterValue;
                }
                if (selectedCampaign != null && selectedChannel != null)
                {
                    campaignChannels.CampaignsId = selectedCampaign.Id;
                    campaignChannels.ChannelsId = selectedChannel.Id;
                    campaignChannels.CampaignName = selectedCampaign.Name;
                    campaignChannels.ChannelType = selectedChannel.ChannelType;
                    campaignChannels.Status = selectedCampaign.Status;
                }
                else
                {
                    throw new Exception("Kardeş null geldi bi tanesi");

                }

                await _campaignsService.AddAsync(_mapper.Map<CampaignChannels>(campaignChannels));
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public async Task<IActionResult> Remove(int id)
        {
            var cc = await _campaignsService.GetByIdAsync(id);
            await _campaignsService.RemoveAsync(cc);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var cc = await _campaignsService.GetByIdAsync(id);

            var languageDeger = (from i in _appDbContext.Parameters
                                 where i.GroupCode == "LanguageType"
                                 select new SelectListItem
                                 {
                                     Text = i.ParameterValue,
                                     Value = i.ParameterCode
                                 }).ToList();
            ViewBag.LanguageOptions = languageDeger;

            var campaignDeger = (from i in _appDbContext.Campaigns
                                     //where i.Id == cc.CampaignsId
                                 select new SelectListItem
                                 {
                                     Text = i.Name,
                                     Value = i.Name
                                 }).ToList();
            ViewBag.CampaignOptions = campaignDeger;

            var channelDeger = (from i in _appDbContext.Channels
                                    //where i.Id == cc.ChannelsId
                                select new SelectListItem
                                {
                                    Text = i.ChannelType,
                                    Value = i.ChannelType,
                                }).ToList();
            ViewBag.ChannelOptions = channelDeger;

            return View(_mapper.Map<CampaignChannelsDto>(cc));
        }
        [HttpPost]
        public async Task<IActionResult> Update(CampaignChannelsDto campaignChannelsDto)
        {
            if (ModelState.IsValid)
            {
                var cc = await _campaignsService.GetByIdAsync(campaignChannelsDto.Id);
                _mapper.Map(campaignChannelsDto, cc);
                var selectedCampaign = await _appDbContext.Campaigns.FirstOrDefaultAsync(c => c.Name == campaignChannelsDto.CampaignName);
                var selectedChannel = await _appDbContext.Channels.FirstOrDefaultAsync(c => c.ChannelType == campaignChannelsDto.ChannelType);

                if (selectedCampaign != null && selectedChannel != null)
                {
                    cc.CampaignsId = selectedCampaign.Id;
                    cc.ChannelsId = selectedChannel.Id;
                    cc.CampaignName = selectedCampaign.Name;
                    cc.ChannelType = selectedChannel.ChannelType;
                    cc.ActionStartTime = campaignChannelsDto.ActionStartTime;
                    cc.ActionEndTime = campaignChannelsDto.ActionEndTime;
                    cc.LanguageCode = campaignChannelsDto.LanguageCode;
                    cc.Description = campaignChannelsDto.Description;

                    await _campaignsService.UpdateAsync(cc);
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(campaignChannelsDto);
        }

        public IActionResult ChangeChannelStatusToTrue(int id)
        {
            _campaignChannelsStatusService.ChangeChannelStatusToTrue(id);
            return Json(new { success = true });
        }
        public IActionResult ChangeChannelStatusToFalse(int id)
        {
            _campaignChannelsStatusService.ChangeChannelStatusToFalse(id);
            return Json(new { success = true });
        }
    }
}
