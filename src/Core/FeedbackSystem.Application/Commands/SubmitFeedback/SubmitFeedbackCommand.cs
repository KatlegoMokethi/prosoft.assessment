using MediatR;

namespace FeedbackSystem.Application.Commands.SubmitFeedback;

public class SubmitFeedbackCommand : IRequest<string>
{
    public string Service { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
