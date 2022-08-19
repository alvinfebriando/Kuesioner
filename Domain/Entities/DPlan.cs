namespace Kuesioner.Domain.Entities;

public class DPlan
{
    public DPlan(Content content, IList<string> structure)
    {
        Content = content;
        Structure = structure;
    }

    public Content Content { get; set; }
    public IList<string> Structure { get; set; }
}