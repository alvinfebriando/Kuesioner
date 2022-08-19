using Kuesioner.Application.Spec;
using Kuesioner.Domain.Entities;

namespace Kuesioner.Application.MicroPlanning;

public interface IMicroPlanning
{
    public IList<ISpec> CreateMPlan(DPlan dPlan);
}