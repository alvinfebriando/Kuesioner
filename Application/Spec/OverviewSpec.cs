using Kuesioner.Application.Lexicalization;
using Kuesioner.Application.Message;
using Kuesioner.Domain.Entities;

namespace Kuesioner.Application.Spec;

public class OverviewSpec : ISpec
{
    public OverviewSpec(string lecturer, double averageScore, int respondentCount, IList<string> structure)
    {
        Lecturer = lecturer;
        AverageScore = averageScore;
        RespondentCount = respondentCount;
        Structure = structure;
        Lex = new Lexicalization.Lexicalization();
    }

    public string Lecturer { get; set; }
    public double AverageScore { get; set; }
    public int RespondentCount { get; set; }
    public IList<string> Structure { get; set; }
    private ILexicalization Lex { get; }

    public IList<IMessage> Order { get; set; } = new List<IMessage>();
    public IList<string> Sentences { get; set; } = new List<string>();

    public void Ordering()
    {
        var scoreMsg = new ScoreRespondentMessage(Lecturer, AverageScore, RespondentCount, Lex);
        var performanceMsg = new PerformanceStatusMessage(Lecturer, AverageScore, Lex);
        Order = Structure[0] == "score"
            ? new List<IMessage> { scoreMsg, performanceMsg }
            : new List<IMessage> { performanceMsg, scoreMsg };
    }

    public void Aggregate()
    {
        if (Structure[0] == "score")
        {
            Order[0].EmbedComplement(new Option("first"));
            Order[1].EmbedComplement(new Option("second"));
        }
        else
        {
            Order[1].EmbedComplement(new Option("second"));
        }

        foreach (var item in Order) item.Lexicalization();
        Sentences.Add(Order[0].Core);
        Sentences.Add(Order[1].Core);
    }

    public IList<string> Build()
    {
        Ordering();
        Aggregate();
        return Sentences;
    }
}