
using Layer.Core.Models; 
using Layer.Core.Services;
using Layer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlbaMVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IService<Customers> _customers;
        private readonly AppDbContext _appDbContext;

        public CustomerController(IService<Customers> customers, AppDbContext appDbContext)
        {
            _customers = customers;
            _appDbContext = appDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _customers.GetAllAsync();
            
            var processVariable = _appDbContext.Parameters
                .Where(p => p.GroupCode == "SenarioType")
                .Select(p => new SelectListItem { Text = p.ParameterValue, Value = p.ParameterCode })
                .ToList();
            ViewBag.ProcessVariable = new SelectList(processVariable, "Value", "Text");

            var campaigns = _appDbContext.Campaigns.Select(c => new SelectListItem { Text = c.Name, Value=c.Id.ToString() });
            ViewBag.Campaigns = campaigns;

            return View(customers.ToList());
        }

        [HttpGet]
        public IActionResult GetSelectedVariable(string chosen)
        {

            var variableSelector = _appDbContext.Parameters
                .Where(p => p.GroupCode == chosen + "Type")
                .Select(p => new SelectListItem { Text = p.ParameterValue, Value = p.ParameterCode })
                .ToList();
            ViewBag.SelectedVariable = new SelectList(variableSelector, "Value", "Text");

            return Json(variableSelector);
        }

        
    }
}
