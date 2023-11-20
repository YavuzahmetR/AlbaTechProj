using AutoMapper;
using Layer.Core.DTOs;
using Layer.Core.Models;
using Layer.Core.Repositories;
using Layer.Core.Services;
using Layer.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Linq.Expressions;

namespace Layer.Caching
{
    public class CampaignsServiceWithCaching : ICampaignsService
    {
        private const string CacheCampaignKey = "campaignsCache";
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Campaigns> _campaignsRepository;
        private readonly ICustomerCampaignsRepository _customerCampaignsRepository;
        private readonly IMemoryCache _memoryCache;
        private readonly IMapper _mapper;

        public CampaignsServiceWithCaching(
            IGenericRepository<Campaigns> campaignsRepository, IMemoryCache memoryCache,
            IUnitOfWork unitOfWork, ICustomerCampaignsRepository customerCampaignsRepository, IMapper mapper)
        {
            _memoryCache = memoryCache;
            _unitOfWork = unitOfWork;
            _campaignsRepository = campaignsRepository;
            if (!_memoryCache.TryGetValue(CacheCampaignKey, out _))
            {
                _memoryCache.Set(CacheCampaignKey, _campaignsRepository.GetAll().ToList());
            }
            _customerCampaignsRepository = customerCampaignsRepository;
            _mapper = mapper;
        }
        public async Task CacheAllCampaignsAsync()
        {
            _memoryCache.Set(CacheCampaignKey, await _campaignsRepository.GetAll().ToListAsync());
        }
        public async Task<Campaigns> AddAsync(Campaigns entity)
        {
            await _campaignsRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllCampaignsAsync();
            return entity;
        }

        public async Task<IEnumerable<Campaigns>> AddRangeAsync(IEnumerable<Campaigns> entities)
        {
            await _campaignsRepository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllCampaignsAsync();
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<Campaigns, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Campaigns>> GetAllAsync()
        {
            return Task.FromResult(_memoryCache.Get<IEnumerable<Campaigns>>(CacheCampaignKey));
        }

        public Task<Campaigns> GetByIdAsync(int id)
        {
            var campaign = _memoryCache.Get<List<Campaigns>>(CacheCampaignKey).FirstOrDefault(x => x.Id == id);
            if (campaign == null)
            {
                throw new Exception($"{id}.Kampanya VeriTabanında Bulunamamaktadır.");
            }
            return Task.FromResult(campaign);
        }
        public async Task RemoveAsync(Campaigns entity)
        {
            _campaignsRepository.Remove(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllCampaignsAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<Campaigns> entities)
        {
            _campaignsRepository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllCampaignsAsync();
        }

        public async Task UpdateAsync(Campaigns entity)
        {
            _campaignsRepository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllCampaignsAsync();
        }

        public IQueryable<Campaigns> Where(Expression<Func<Campaigns, bool>> expression)
        {
            return _memoryCache.Get<List<Campaigns>>(CacheCampaignKey).Where(expression.Compile()).AsQueryable();
        }

        public async Task<List<SimpleCampaignDto>> GetSimpleCampaignsByCustomerNo(int customerNo, int channelId)
        {
            var x = await _customerCampaignsRepository.GetCampaignsByCustomerNo(customerNo, channelId);
            var y = _mapper.Map<List<SimpleCampaignDto>>(x);
            return y;
        }
    }
}


