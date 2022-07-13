namespace DevOps.AutomatedActions.Api.Domain.PullRequest.Webhook;

public class LastMergeCommit
{
    public string commitId { get; set; }
    public string url { get; set; }
}