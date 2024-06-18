using AutoMapper;
using FeedbackSystem.Application.Mappings;
using FeedbackSystem.Domain.Interfaces;
using MediatR;

namespace FeedbackSystem.Application.Queries.GetAllFeedback;

public class GetFeedbacksHandler : IRequestHandler<GetFeedbacksQuery, GetFeedbacksVm>
{
    private readonly IFeedbackRepository _feedbackRepo;
    private readonly IMapper _mapper;

    public GetFeedbacksHandler(IFeedbackRepository feedbackRepo)
    {
        _feedbackRepo = feedbackRepo;

        var mappingConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
        _mapper = new Mapper(mappingConfig);
    }

    public async Task<GetFeedbacksVm> Handle(GetFeedbacksQuery request, CancellationToken cancellationToken)
    {
        var feedbacks = await _feedbackRepo.GetFeedbacksAsync();

        return new GetFeedbacksVm
        {
            Feedbacks = _mapper.Map<List<FeedbackVm>>(feedbacks)
        };
    }
}
