using DevOps.AutomatedActions.Api.Domain.PullRequest;
using DevOps.AutomatedActions.Api.Domain.PullRequest.Webhook;

namespace DevOps.AutomatedActions.Api.Services.Interfaces;

public interface IPullRequestService
{
    public Task AddOptionalReviewerAsync(PullRequestData pullRequestData);

    public Task GetAssociatedCommitsAsync(PullRequestData pullRequestData);

}