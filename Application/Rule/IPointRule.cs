using Kuesioner.Domain.Entities;

namespace Kuesioner.Application.Rule;

public interface IPointRule
{
    public Point Rule(IList<Answer> answers);
}