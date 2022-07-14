using DevOps.AutomatedActions.Api.Domain.Branches;
using DevOps.AutomatedActions.Api.Services.Interfaces;

namespace DevOps.AutomatedActions.Api.Services;

/// <summary>
/// Implements the Interface and Inherits its Functions.
/// Communicates and utilizes the Azure  Get Branches API.
/// </summary>
public class BranchService : BranchServiceFunctions, IBranchService
{
    public BranchService(IAzureHttpFactory azureHttpFactory) : base(azureHttpFactory)   {}

    public async Task<List<BranchesData>> GetAllAsync()
    {
        var branches = await GetAll();
        return branches;
    }
}