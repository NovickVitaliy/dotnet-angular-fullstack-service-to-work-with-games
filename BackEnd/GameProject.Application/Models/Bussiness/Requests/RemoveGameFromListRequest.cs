using GameProject.Application.Models.Shared;
using GameProject.Domain.Models.Business.Games.Common;

namespace GameProject.Application.Models.Bussiness;

public class RemoveGameFromListRequest : BaseRequest
{
    public int GameToRemoveRawgId { get; set; }
    public GameStatus Status { get; set; }
}