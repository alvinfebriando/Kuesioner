using Kuesioner.Application.Spec;
using Kuesioner.Domain.Entities;

namespace Kuesioner.Application.MicroPlanning;

public class MicroPlanning : IMicroPlanning
{
    public MicroPlanning(DPlan dPlan)
    {
        DPlan = dPlan;
    }

    public DPlan DPlan { get; set; }

    public IList<ISpec> CreateMPlan()
    {
        var content = DPlan.Content;
        var structure = DPlan.Structure;
        var overview = new OverviewSpec(content.Lecturer, content.AverageScore, content.RespondentCount, structure);
        var point = new PointSpec(content.Lecturer, content.Point, structure);
        var advice = new AdviceSpec(content.Lecturer, point.Point, structure);
        return new List<ISpec>
        {
            overview, point, advice
        };
    }
}