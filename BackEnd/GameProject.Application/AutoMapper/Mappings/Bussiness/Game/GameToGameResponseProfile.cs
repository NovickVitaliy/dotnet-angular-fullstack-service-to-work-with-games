using AutoMapper;
using GameProject.Application.Models.Bussiness.DTOs;
using GameProject.Domain.Models.Business.Games;

namespace GameProject.Application.Mappings.Bussiness.Game;

public class GameToGameResponseProfile : Profile
{
    public GameToGameResponseProfile()
    {
        CreateMap<StartedGame, BaseGameResponse>();
        CreateMap<InProgressGame, BaseGameResponse>();
        CreateMap<FinishedGame, BaseGameResponse>();
        CreateMap<AbandonedGame, BaseGameResponse>();
        CreateMap<DesiredGame, BaseGameResponse>();
    }
}