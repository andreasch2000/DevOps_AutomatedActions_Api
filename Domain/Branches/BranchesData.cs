namespace DevOps.AutomatedActions.Api.Domain.Branches;

public class BranchesData
{
    public string path { get; set; }
    public Owner owner { get; set; }
    public DateTime createdDate { get; set; }
    public string url { get; set; }
    public List<RelatedBranch> relatedBranches { get; set; }
    public List<object> mappings { get; set; }
    public string description { get; set; }
    public bool? isDeleted { get; set; }
}