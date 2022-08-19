namespace Kuesioner.Domain.Entities;

public class Question
{
    public Question(string title, List<string> advices)
    {
        Title = title;
        Advices = advices;
    }

    public string Title { get; set; }
    public List<string> Advices { get; set; }
}