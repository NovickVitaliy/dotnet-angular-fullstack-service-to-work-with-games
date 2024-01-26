using AutoMapper;
using GameProject.Application.Models.Bussiness.DTOs;

namespace GameProject.Identity.Mappings.Bussiness.GameReview;

public class GameReviewToGameReviewDtoProfile : Profile
{
    public GameReviewToGameReviewDtoProfile()
    {
        CreateMap<Domain.Models.Business.GameReview, GameReviewDto>()
            .ForMember(e => e.AuthorName,
                opt => opt.MapFrom(e => e.Author.UserName))
            .ForMember(e => e.AuthorEmail,
                opt => opt.MapFrom(e => e.Author.Email))
            .ForMember(e => e.AuthorProfilePhotoUrl,
                opt => opt.MapFrom(e => 
                    e.Author.ProfilePhoto == null ? null : e.Author.ProfilePhoto.Url))
            .ForMember(e => e.ReviewId,
                opt => opt.MapFrom(e => e.Id))
            .ForMember(e => e.ReviewId,
                opt => opt.MapFrom(e => e.Id))
            .ForMember(e => e.GameRawgId,
                opt => opt.MapFrom(e => e.GameRawgId))
            .ForMember(e => e.GameName,
                opt => opt.MapFrom(e => e.GameName));
    }
}