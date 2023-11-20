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
    public class CampaignsController : Controller
    {
        private readonly ICampaignsService _campaignsService;
        private readonly ICampaignStatusService _campaignStatus;
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;
        public CampaignsController(ICampaignsService campaignsService, IMapper mapper, AppDbContext appDbContext, ICampaignStatusService campaignStatus)
        {
            _campaignsService = campaignsService;
            _mapper = mapper;
            _appDbContext = appDbContext;
            _campaignStatus = campaignStatus;
        }
        public async Task<IActionResult> Index(string ara, DateTime? startDate, DateTime? endDate, string campaignType, string campaignStatusOption, int? priorityFirst, int? priorityLast)
        {
            var campaignList = await _campaignsService.GetAllAsync();
            campaignList = campaignList.Where(c =>
                (string.IsNullOrEmpty(ara) || c.Name.Contains(ara)) &&
                (!startDate.HasValue || !endDate.HasValue || (c.StartDate >= startDate.Value && c.EndDate <= endDate.Value)) &&
                (string.IsNullOrEmpty(campaignType) || c.CampaignType.Contains(campaignType)) &&
                (string.IsNullOrEmpty(campaignStatusOption) || (c.Status == (campaignStatusOption == "Aktif"))) &&
                (!priorityFirst.HasValue || !priorityLast.HasValue || (c.Priority >= priorityFirst && c.Priority <= priorityLast))
            ).ToList();

            var campaignStatusOptions = new List<SelectListItem>
    {
        new SelectListItem { Text = "Hepsi", Value = "" },
        new SelectListItem { Text = "Aktif", Value = "Aktif" },
        new SelectListItem { Text = "Pasif", Value = "Pasif" }
    };

            ViewBag.CampaignStatusOptions = new SelectList(campaignStatusOptions, "Value", "Text");

            var campaignTypes = await _appDbContext.Parameters.Where(p => p.GroupCode == "CampaignTypes")
                .Select(p => new SelectListItem { Text = p.ParameterValue, Value = p.ParameterValue }).ToListAsync();
            ViewBag.CampaignTypes = new SelectList(campaignTypes, "Value", "Text");

            return View(campaignList);


        }

        [HttpGet]
        public async Task<IActionResult> Save()
        {
            var campaignList = await _campaignsService.GetAllAsync();


            List<SelectListItem> parametredeger = (
            from i in _appDbContext.Parameters
            where i.GroupCode == "CampaignTypes"
            select new SelectListItem
            {
                Text = i.ParameterValue,
                Value = i.ParameterCode
            }
                ).ToList();
            ViewBag.pr = parametredeger;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(CampaignsDto campaignsDto)
        {
            if (ModelState.IsValid)
            {
                var parameterQuery = from p in _appDbContext.Parameters
                                     where p.ParameterValue == campaignsDto.CampaignType || p.ParameterCode == campaignsDto.CampaignType
                                     select new
                                     {
                                         p.ParameterCode,
                                         p.ParameterValue
                                     };

                var parameter = await parameterQuery.FirstOrDefaultAsync();

                if (parameter != null)
                {
                    campaignsDto.CampaignParameter = parameter.ParameterCode;
                    campaignsDto.CampaignType = parameter.ParameterValue;
                }

                await _campaignsService.AddAsync(_mapper.Map<Campaigns>(campaignsDto));
                return RedirectToAction(nameof(Index));
            }


            return View();
        }
        public async Task<IActionResult> Update(int id)
        {
            var campaigns = await _campaignsService.GetByIdAsync(id);

            List<SelectListItem> parametredeger = (
            from i in _appDbContext.Parameters
            where i.GroupCode == "CampaignTypes"
            select new SelectListItem
            {
                Text = i.ParameterValue,
                Value = i.ParameterCode
            }).ToList();
            ViewBag.pr = parametredeger;
            return View(_mapper.Map<CampaignsDto>(campaigns));

        }
        [HttpPost]
        public async Task<IActionResult> Update(CampaignsDto campaignsDto)
        {
            if (ModelState.IsValid)
            {
                var parameterQuery = from p in _appDbContext.Parameters
                                     where p.ParameterCode == campaignsDto.CampaignType
                                     select p.ParameterValue;

                foreach (var parameterValue in parameterQuery)
                {
                    campaignsDto.CampaignType = parameterValue;
                }

                var campaign = await _campaignsService.GetByIdAsync(campaignsDto.Id);
                _mapper.Map(campaignsDto, campaign);

                await _campaignsService.UpdateAsync(campaign);
                return RedirectToAction(nameof(Index));

            }

            return View();
        }
        public async Task<IActionResult> Remove(int id)
        {
            var campaign = await _campaignsService.GetByIdAsync(id);
            await _campaignsService.RemoveAsync(campaign);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult ChangeStatusToTrue(int id)
        {
            _campaignStatus.CampaignStatusToTrue(id);
            return Json(new { success = true });
        }
        public IActionResult ChangeStatusToFalse(int id)
        {
            _campaignStatus.CampaignStatusToFalse(id);
            return Json(new { success = true });
        }

    }
}
