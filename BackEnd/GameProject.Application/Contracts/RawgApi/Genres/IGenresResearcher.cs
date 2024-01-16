using GameProject.Domain.Models.RawgApi.Genres;

namespace GameProject.Application.Contracts.RawgApi.Genres;

public interface IGenresResearcher
{
    Task<List<GenreMainInfo>> GetGenres();
}