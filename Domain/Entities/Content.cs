namespace Kuesioner.Domain.Entities;

public class Content
{
    public Content(string lecturer, double averageScore, int respondentCount, Point point)
    {
        Lecturer = lecturer;
        AverageScore = averageScore;
        RespondentCount = respondentCount;
        Point = point;
    }

    public string Lecturer { get; set; }
    public double AverageScore { get; set; }
    public int RespondentCount { get; set; }
    public Point Point { get; set; }
}