using FluentValidation;

namespace FeedbackSystem.Application.Commands.SubmitFeedback;

public class SubmitFeedbackValidator : AbstractValidator<SubmitFeedbackCommand>
{
	public SubmitFeedbackValidator() 
	{
        RuleFor(command => command.Service)
            .NotEmpty();

        RuleFor(command => command.Description)
            .NotEmpty();
    }
}
