namespace Kuesioner.Domain.Entities;

public class Point
{
    public Point(Answer max, Answer min)
    {
        Max = max;
        Min = min;
    }

    public Answer Max { get; set; }
    public Answer Min { get; set; }
    public IList<Answer>? Good { get; set; }
    public IList<Answer>? Bad { get; set; }
}