namespace DevOps.AutomatedActions.Api.Domain.PullRequest.Webhook;

public class Reviewer
{
    public string? reviewerUrl { get; set; }
    public int vote { get; set; }
    public string displayName { get; set; }
    public string url { get; set; }
    public string id { get; set; }
    public string uniqueName { get; set; }
    public string imageUrl { get; set; }
    public bool isContainer { get; set; }
}