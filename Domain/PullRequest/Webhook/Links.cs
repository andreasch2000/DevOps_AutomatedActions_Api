namespace DevOps.AutomatedActions.Api.Domain.PullRequest.Webhook;

public class Links
{
    public Self? self { get; set; }
    public Repository? repository { get; set; }
    public Threads? threads { get; set; }
    public Web? web { get; set; }
    public Statuses? statuses { get; set; }
}