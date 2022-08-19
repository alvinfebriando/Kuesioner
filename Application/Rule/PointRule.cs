using Kuesioner.Domain.Entities;

namespace Kuesioner.Application.Rule;

public class PointRule: IPointRule
{
    public Point Rule(IList<Answer> answers)
    {
        answers = answers.OrderByDescending(o => o.Score).ToList();
        Point output = new(answers[0], answers[^1]);
        foreach (var answer in answers)
        {
            if (Math.Round(answer.Score) <= 2)
                output.Bad.Add(answer);
            else if (Math.Round(answer.Score) >= 4) output.Good.Add(answer);
        }
        return output;
    }
}