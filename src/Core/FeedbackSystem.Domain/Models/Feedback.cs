namespace FeedbackSystem.Domain.Models;

public class Feedback
{
	public string Service { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public DateTime CreatedDatetime { get; set; }
}
