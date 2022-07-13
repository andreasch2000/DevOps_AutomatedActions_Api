using DevOps.AutomatedActions.Api.Domain.PullRequest.Webhook;
using DevOps.AutomatedActions.Api.Services.Interfaces;

namespace DevOps.AutomatedActions.Api.Services;

/// <summary>
/// Implements the Interface and Inherits its Functions.

/// Communicates and utilizes the Azure Pull Request API.
/// </summary>
public class PullRequestService : PullRequestServiceFunctions, IPullRequestService
{
    public PullRequestService(IAzureHttpFactory azureHttpFactory) : base(azureHttpFactory) {}

    public async Task AddOptionalReviewerAsync(PullRequestData pullRequestData)
    {
        await AddReviewer(pullRequestData);
    }

    public async Task GetAssociatedCommitsAsync(PullRequestData pullRequestData)
    {
        var commits = await GetPullRequestCommits(pullRequestData);

        if (commits is null) return;
        foreach (var commit in commits.value)
        {
            //TODO Cycle commits and get Data
        }
    }
}