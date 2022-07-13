using System.Net.Http.Headers;
using DevOps.AutomatedActions.Api.Services.Interfaces;

namespace DevOps.AutomatedActions.Api.Services;

public class AzureHttpFactory: IAzureHttpFactory
{
    private readonly IHttpClientFactory _httpClientFactory;
    
    public AzureHttpFactory(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    public HttpClient CreateAzureClientPatAuth(string pat)
    {
        var httpClient = _httpClientFactory.CreateClient();
        
        httpClient.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
            Convert.ToBase64String(
                System.Text.ASCIIEncoding.ASCII.GetBytes(
                    string.Format("{0}:{1}", "", pat))));

        return httpClient;
    }
    
    
    
}