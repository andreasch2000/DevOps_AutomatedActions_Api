namespace DevOps.AutomatedActions.Api.Domain.PullRequest.Webhook;

public class PullRequestData
{
    public string subscriptionId { get; set; }
    public int notificationId { get; set; }
    public string id { get; set; }
    public string eventType { get; set; }
    public string publisherId { get; set; }
    public Message message { get; set; }
    public DetailedMessage detailedMessage { get; set; }
    public Resource resource { get; set; }
    public string resourceVersion { get; set; }
    public ResourceContainers resourceContainers { get; set; }
    public DateTime createdDate { get; set; }
    public string repositoryId => resource.pullRequest?.repository.id ?? "default";
    public int? pullRequestId => resource.pullRequest?.pullRequestId;
}