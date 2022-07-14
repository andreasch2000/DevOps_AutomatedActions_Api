using DevOps.AutomatedActions.Api.Domain.Branches;

namespace DevOps.AutomatedActions.Api.Services.Interfaces;

public interface IBranchService
{
    public Task<List<BranchesData>> GetAllAsync();
}