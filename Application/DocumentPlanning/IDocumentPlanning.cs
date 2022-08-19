using Kuesioner.Application.Rule;
using Kuesioner.Domain.Entities;

namespace Kuesioner.Application.DocumentPlanning;

public interface IDocumentPlanning
{
    public DPlan CreateDPlan(string lecturer, int respondentCount, IList<Answer> answers);
    public Content DetermineContent(string lecturer, int respondentCount, IList<Answer> answers, IPointRule rule);
    public IList<string> DetermineStructure(Content content, IStructureRule rule);
}