using AutoMapper;
using GameProject.Application.Models.Bussiness.Requests.GameReview;

namespace GameProject.Identity.Mappings.Bussiness.GameReview;

public class UpdateGameReviewToGameReviewProfile : Profile
{
    public UpdateGameReviewToGameReviewProfile()
    {
        CreateMap<UpdateGameReviewRequest, Domain.Models.Business.GameReview>()
            .ForMember(e => e.Review,
                opt => opt.MapFrom(e => e.EditedReview))
            .ForMember(e => e.Score,
                opt => opt.MapFrom(e => e.EditedScore));
    }
}