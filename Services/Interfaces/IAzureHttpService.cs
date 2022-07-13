namespace DevOps.AutomatedActions.Api.Services.Interfaces;

public interface IAzureHttpFactory
{
    public HttpClient CreateAzureClientPatAuth(string pat);
}