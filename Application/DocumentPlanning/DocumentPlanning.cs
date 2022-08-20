using Kuesioner.Application.Rule;
using Kuesioner.Domain.Entities;

namespace Kuesioner.Application.DocumentPlanning;

public class DocumentPlanning : IDocumentPlanning
{
    public DPlan CreateDPlan(string lecturer, int respondentCount, IList<Answer> answers)
    {
        PointRule pointRule = new();
        StructureRule structureRule = new();
        var content = DetermineContent(lecturer, respondentCount, answers, pointRule);
        var structure = DetermineStructure(content, structureRule);
        return new DPlan(content, structure);
    }

    public Content DetermineContent(string lecturer, int respondentCount, IList<Answer> answers, IPointRule rule)
    {
        var point = rule.Rule(answers);
        var averageScore = answers.Select(x => x.Score).Average();
        return new Content(lecturer, averageScore, respondentCount, point);
    }

    public IList<string> DetermineStructure(Content content, IStructureRule rule)
    {
        return rule.Rule(content.Point);
    }
}