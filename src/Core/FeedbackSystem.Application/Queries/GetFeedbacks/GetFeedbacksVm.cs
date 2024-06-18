namespace FeedbackSystem.Application.Queries.GetAllFeedback;

public class GetFeedbacksVm
{
   public List<FeedbackVm> Feedbacks { get; set; } = new();
}

public class FeedbackVm
{
    public string Service { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
