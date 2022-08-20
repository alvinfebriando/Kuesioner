using Kuesioner.Domain.Entities;

namespace Kuesioner.Application.Rule;

public interface IStructureRule
{
    public IList<string> Rule(Point point);
}