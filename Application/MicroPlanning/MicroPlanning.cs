using Kuesioner.Application.Spec;
using Kuesioner.Domain.Entities;

namespace Kuesioner.Application.MicroPlanning;

public class MicroPlanning : IMicroPlanning
{
    public IList<ISpec> CreateMPlan(DPlan dPlan)
    {
        var content = dPlan.Content;
        var structure = dPlan.Structure;
        var overview = new OverviewSpec(content.Lecturer, content.AverageScore, content.RespondentCount, structure);
        var point = new PointSpec(content.Lecturer, content.Point, structure);
        return new List<ISpec>
        {
            overview, point
        };
    }
}