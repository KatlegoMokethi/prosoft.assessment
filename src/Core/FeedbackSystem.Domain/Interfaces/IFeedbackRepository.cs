using FeedbackSystem.Domain.Models;

namespace FeedbackSystem.Domain.Interfaces;

public interface IFeedbackRepository
{
    Task AddFeedbackAsync(Feedback feedback);
}
