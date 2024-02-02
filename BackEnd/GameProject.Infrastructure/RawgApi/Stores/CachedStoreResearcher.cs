using System.Text;
using GameProject.Application.Contracts.RawgApi.Stores;
using GameProject.Domain.Models.RawgApi.Stores;
using Microsoft.Extensions.Caching.Memory;

namespace GameProject.Identity.RawgApi.Stores;

public class CachedStoreResearcher : IStoresResearcher
{
    private readonly IStoresResearcher _storesResearcher;
    private readonly IMemoryCache _cache;

    public CachedStoreResearcher(IStoresResearcher storesResearcher, IMemoryCache cache)
    {
        _storesResearcher = storesResearcher;
        _cache = cache;
    }

    public async Task<Store> GetStoreInfo(int storeId)
    {
        StringBuilder stringBuilder = new StringBuilder();
        if (_cache.TryGetValue(GetKeyForStore(storeId), out Store store))
        {
            return store!;
        }

        store = await _storesResearcher.GetStoreInfo(storeId);

        _cache.Set(GetKeyForStore(storeId), store);
        return store;
    }

    private string GetKeyForStore(int storeId)
    {
        return new StringBuilder().Append("store").Append(storeId).ToString();
    }
}