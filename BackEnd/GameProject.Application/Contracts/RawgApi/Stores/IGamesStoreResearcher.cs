using GameProject.Application.Models.Bussiness.DTOs;

namespace GameProject.Application.Contracts.RawgApi.Stores;

public interface IGamesStoreResearcher
{
    Task<List<GameStore>> GetGamesStoreForGame(int gameId);
}