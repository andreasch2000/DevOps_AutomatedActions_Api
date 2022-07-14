using System.Net;
using System.Text.Json;
using DevOps.AutomatedActions.Api.Domain.Branches;
using DevOps.AutomatedActions.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevOps.AutomatedActions.Api.Services;

public class BranchServiceFunctions
{
    private readonly JsonSerializerOptions _options;
    private readonly HttpClient _httpClient;

    private const string PersonalAuthenticationToken = "o3h73d3zbmpyrpqi2bkqf5zpqzawqkyq5fcp2trbuncry3xh755q";
    private const string Organization = "testakos";
    private const string Project = "DevOps%20Status%20Server";

    protected BranchServiceFunctions(IAzureHttpFactory azureHttpFactory)
    {
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        _httpClient = azureHttpFactory.CreateAzureClientPatAuth(PersonalAuthenticationToken);
    }


    protected async Task<List<BranchesData>?> GetAll()
    {
        var requestUri = $"https://dev.azure.com/{Organization}/{Project}/_apis/tfvc/branches?api-version=6.0";
        using var response = await _httpClient.GetAsync(requestUri);
        response.EnsureSuccessStatusCode();
        var stream = await response.Content.ReadAsStreamAsync();
        var commits = await JsonSerializer.DeserializeAsync<List<BranchesData>>(stream, _options);
        return commits;
    }
}