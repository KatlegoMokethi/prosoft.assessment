using MediatR;
using FeedbackSystem.Domain.Interfaces;
using AutoMapper;
using FeedbackSystem.Application.Mappings;
using FeedbackSystem.Domain.Models;

namespace FeedbackSystem.Application.Commands.SubmitFeedback
{
	public class SubmitFeedbackHandler : IRequestHandler<SubmitFeedbackCommand, string>
	{
        private readonly IFeedbackRepository _feedbackRepo;
        private readonly IMapper _mapper;

        public SubmitFeedbackHandler(IFeedbackRepository feedbackRepo)
		{
            _feedbackRepo = feedbackRepo;

            var mappingConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            _mapper = new Mapper(mappingConfig);
        }

        public async Task<string> Handle(SubmitFeedbackCommand request, CancellationToken cancellationToken)
        {
            var feedback = _mapper.Map<Feedback>(request);
            await _feedbackRepo.AddFeedbackAsync(feedback);
            return "Thanks for your feedback!";
        }
    }
}
