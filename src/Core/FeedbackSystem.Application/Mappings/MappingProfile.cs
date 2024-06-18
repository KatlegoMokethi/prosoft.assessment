using AutoMapper;
using FeedbackSystem.Application.Commands.SubmitFeedback;
using FeedbackSystem.Application.Queries.GetAllFeedback;
using FeedbackSystem.Domain.Models;

namespace FeedbackSystem.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<SubmitFeedbackCommand, Feedback>()
            .ReverseMap();

        CreateMap<FeedbackVm, Feedback>()
            .ReverseMap();
    }
}
