namespace DevOps.AutomatedActions.Api.Domain.PullRequest.Reviewers;

public class Reviewer
{
    public string reviewerUrl { get; set; }
    public int vote { get; set; }
    public bool hasDeclined { get; set; }
    public bool isFlagged { get; set; }
    public string displayName { get; set; }
    public string url { get; set; }
    public Links _links { get; set; }
    public string id { get; set; }
    public string uniqueName { get; set; }
    public string imageUrl { get; set; }
}