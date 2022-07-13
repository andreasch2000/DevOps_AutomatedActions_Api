namespace DevOps.AutomatedActions.Api.Domain.PullRequest.Webhook;

public class Resource
{
    public Comment? comment { get; set; }
    public Webhook.PullRequest? pullRequest { get; set; }
}