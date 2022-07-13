using DevOps.AutomatedActions.Api.Domain.PullRequest;
using DevOps.AutomatedActions.Api.Domain.PullRequest.Webhook;
using DevOps.AutomatedActions.Api.Services.Interfaces;
using MediatR;

namespace DevOps.AutomatedActions.Api.Queries;

public static class AddReviewerHandler
{
    public record Query(PullRequestData PullRequestData): IRequest<Response>;
    public record Response();

    public class Handler: IRequestHandler<Query, Response>
    {
        private readonly IPullRequestService _pullRequestService;
        public Handler(IPullRequestService pullRequestService)
        {
            _pullRequestService = pullRequestService;
        }
        
        public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
        {
           // await _pullRequestService.AddOptionalReviewerAsync(request.PullRequestData);
            await _pullRequestService.GetAssociatedCommitsAsync(request.PullRequestData);
            return new Response();
        }
    }

}