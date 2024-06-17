using AutoMapper;
using FeedbackSystem.Application.Commands.SubmitFeedback;
using FeedbackSystem.Domain.Models;

namespace FeedbackSystem.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<SubmitFeedbackCommand, Feedback>()
            .ReverseMap();
    }
}
