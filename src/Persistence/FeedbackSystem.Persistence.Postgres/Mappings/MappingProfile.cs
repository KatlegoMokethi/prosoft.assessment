using AutoMapper;
using FeedbackSystem.Domain.Models;
using FeedbackSystem.Persistence.Postgres.Entities;

namespace FeedbackSystem.Persistence.Postgres.Mappings;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
        CreateMap<Feedback, FeedbackEntity>()
            .ReverseMap();
    }
}
