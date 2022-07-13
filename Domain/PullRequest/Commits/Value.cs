namespace DevOps.AutomatedActions.Api.Domain.PullRequest.Commits;

public class Value
{
    public string commitId { get; set; }
    public Author author { get; set; }
    public Committer committer { get; set; }
    public string comment { get; set; }
    public string url { get; set; }
}