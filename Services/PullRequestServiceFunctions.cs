using System.Text;
using System.Text.Json;
using DevOps.AutomatedActions.Api.Domain.PullRequest;
using DevOps.AutomatedActions.Api.Domain.PullRequest.Commits;
using DevOps.AutomatedActions.Api.Domain.PullRequest.Webhook;
using DevOps.AutomatedActions.Api.Services.Interfaces;

namespace DevOps.AutomatedActions.Api.Services;

/// <summary>
/// Contains all protected or private Functions of the Service, not defined by the Interface 
/// </summary>
public class PullRequestServiceFunctions
{
    private readonly JsonSerializerOptions _options;
    private readonly HttpClient _httpClient;

    //TODO Move to Config or DB (Start with Config in v1)
    private const string PersonalAuthenticationToken = "o3h73d3zbmpyrpqi2bkqf5zpqzawqkyq5fcp2trbuncry3xh755q";
    private const string Organization = "testakos";
    private const string Project = "DevOps%20Status%20Server";
    private const string Reviewer = "7ae05727-6728-65dd-99f3-828e5a5b88f3";

    protected PullRequestServiceFunctions(IAzureHttpFactory azureHttpFactory)
    {
        _options = new JsonSerializerOptions {PropertyNameCaseInsensitive = true};
        _httpClient = azureHttpFactory.
            CreateAzureClientPatAuth(PersonalAuthenticationToken);
    }

    protected async Task AddReviewer(PullRequestData pullRequestData)
    {
        var vote = JsonSerializer.
            Serialize(new PrCommentMsg { vote = 0 });
        var requestUri =
            $"https://dev.azure.com/{Organization}/{Project}/_apis/git/repositories/{pullRequestData.repositoryId}/pullRequests/{pullRequestData.pullRequestId}/reviewers/{Reviewer}?api-version=6.0";

        using var response = await _httpClient.
            PutAsync(requestUri, new StringContent(vote, Encoding.UTF8, "application/json"));
        response.
            EnsureSuccessStatusCode();
        var stream = await response.Content.
            ReadAsStreamAsync();
        var reviewer = await JsonSerializer.
            DeserializeAsync<Reviewer>(stream, _options);
    }

    protected async Task<Commits?> GetPullRequestCommits(PullRequestData pullRequestData)
    {
        var requestUri =
            $"https://dev.azure.com/{Organization}/{Project}/_apis/git/repositories/{pullRequestData.repositoryId}/pullRequests/{pullRequestData.pullRequestId}/commits?api-version=6.0";

        using var response = await _httpClient.
            GetAsync(requestUri);
        response.
            EnsureSuccessStatusCode();
        var stream = await response.Content.
            ReadAsStreamAsync();
        var commits = await JsonSerializer.
            DeserializeAsync<Commits>(stream, _options);
        
        return commits;
    }
}


// using var response =
//     await httpClient.PutAsync(requestUri, new StringContent(vote, Encoding.UTF8, "application/json"));
// var responseBody = await response.Content.ReadAsStringAsync();
// Console.WriteLine(responseBody);
