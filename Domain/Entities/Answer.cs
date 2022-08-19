namespace Kuesioner.Domain.Entities;

public class Answer
{
    public Answer(double score, Question question)
    {
        Score = score;
        Question = question;
    }

    public double Score { get; set; }
    public Question Question { get; set; }
}