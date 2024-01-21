using GameProject.Application.Models.Bussiness;

namespace GameProject.Application.Contracts.Bussiness;

public interface IUserGameListService
{
    Task AddToUserGameList(AddGameToListRequest addGameToListRequest);
    Task RemoveFromUserGameList(RemoveGameFromListRequest removeGameFromListRequest);
    Task ChangeStatusOfGameInUserList(ChangeGameStatusRequest changeGameStatusRequest);
}