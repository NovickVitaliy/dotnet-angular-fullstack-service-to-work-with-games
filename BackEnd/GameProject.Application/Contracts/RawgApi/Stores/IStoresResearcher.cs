using GameProject.Domain.Models.RawgApi.Stores;

namespace GameProject.Application.Contracts.RawgApi.Stores;

public interface IStoresResearcher
{
    Task<Store> GetStoreInfo(int storeId);
}