using Kuesioner.Application.Spec;
using Kuesioner.Domain.Entities;

namespace Kuesioner.Application.MicroPlanning;

public interface IMicroPlanning
{
    public DPlan DPlan { get; set; }
    public IList<ISpec> CreateMPlan();
}