using AutoMapper;
using GameProject.Application.AutoMapper.CustomConverters.Identity;
using GameProject.Application.Models.Identity;
using GameProject.Domain.Models.Identity;

namespace GameProject.Application.Mappings.Identity;

public class IdentityUserToUserResponseProfile : Profile
{
    public IdentityUserToUserResponseProfile()
    {
        CreateMap<ApplicationUser, AuthenticationResponse>()
            .ForMember(au => au.Platforms,
                opt => opt.ConvertUsing(new PlatformStringToPlatformArrayConverter()))
            .ForMember(e => e.Location,
                opt => opt.MapFrom(e => e.Country))
            .ForMember(e => e.StartedGames,
                opt => opt.MapFrom(e => e.UsersStartedGames.Select(g => g.StartedGame)))
            .ForMember(e => e.InProgressGames,
                opt => opt.MapFrom(e => e.UsersInProgressGames.Select(g => g.InProgressGame)))
            .ForMember(e => e.FinishedGames, 
                opt => opt.MapFrom(e => e.UsersFinishedGames.Select(g => g.FinishedGame)))
            .ForMember(e => e.AbandonedGames, 
                opt => opt.MapFrom(e => e.UsersAbandonedGames.Select(g => g.AbandonedGame)))
            .ForMember(e => e.DesiredGames,
                opt => opt.MapFrom(e => e.UsersDesiredGames.Select(g => g.DesiredGame)))
            .ForMember(e => e.GameReviews,
                opt => opt.Ignore());
    }
}