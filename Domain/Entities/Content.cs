namespace Kuesioner.Domain.Entities;

public class Content
{
    public string Lecturer { get; set; }
    public double AverageScore { get; set; }
    public int RespondentCount { get; set; }
    public Point Point { get; set; }
}