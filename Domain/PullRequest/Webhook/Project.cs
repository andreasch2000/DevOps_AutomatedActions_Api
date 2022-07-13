namespace DevOps.AutomatedActions.Api.Domain.PullRequest.Webhook;

public class Project
{
    public string id { get; set; }
    public string? name { get; set; }
    public string? url { get; set; }
    public string? state { get; set; }
    public string? visibility { get; set; }
    public DateTime lastUpdateTime { get; set; }
}