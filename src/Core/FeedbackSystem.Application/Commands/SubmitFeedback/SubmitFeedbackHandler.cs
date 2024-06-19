using MediatR;
using FeedbackSystem.Domain.Interfaces;
using AutoMapper;
using FeedbackSystem.Application.Mappings;
using FeedbackSystem.Domain.Models;
using FeedbackSystem.Infrastructure.Services;
using FeedbackSystem.Infrastructure.Models;

namespace FeedbackSystem.Application.Commands.SubmitFeedback
{
	public class SubmitFeedbackHandler : IRequestHandler<SubmitFeedbackCommand, string>
	{
        private readonly IFeedbackRepository _feedbackRepo;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public SubmitFeedbackHandler(IFeedbackRepository feedbackRepo, INotificationService notificationService)
		{
            _feedbackRepo = feedbackRepo;
            _notificationService = notificationService;

            var mappingConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            _mapper = new Mapper(mappingConfig);
        }

        public async Task<string> Handle(SubmitFeedbackCommand request, CancellationToken cancellationToken)
        {
            var feedback = _mapper.Map<Feedback>(request);
            await _feedbackRepo.AddFeedbackAsync(feedback);

            await _notificationService.SendEmailAsync(new MailOptions
            {
                Subject = "Prosoft IT Feedback System Notification",
                Body = $"New feedback was submitted for {request.Service}: {request.Description}"
            });

            return "Thanks for your feedback!";
        }
    }
}
