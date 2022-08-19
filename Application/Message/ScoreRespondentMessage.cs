using Kuesioner.Application.Lexicalization;
using Kuesioner.Domain.Entities;

namespace Kuesioner.Application.Message;

public class ScoreRespondentMessage : IMessage
{
    public ScoreRespondentMessage(string lecturer, double averageScore, int respondentCount, ILexicalization lex)
    {
        Lecturer = lecturer;
        AverageScore = averageScore;
        RespondentCount = respondentCount;
        Lex = lex;
    }

    public string Lecturer { get; set; }
    public double AverageScore { get; set; }
    public int RespondentCount { get; set; }
    private ILexicalization Lex { get; }

    public string Core { get; set; } = "";
    public IList<string> Complement { get; set; } = new List<string>();
    public IList<string> Sentences { get; set; } = new List<string>();

    public void Lexicalization()
    {
        Sentences = new List<string>
        {
            $"{Lecturer} {Lex.RndMendapat()} rata-rata {Lex.RndNilai()} total sebesar {AverageScore} dari {RespondentCount} {Lex.RndResponden()}",
            $"{Complement[0]} dari {RespondentCount} {Lex.RndResponden()} {Lecturer} {Lex.RndMendapat()} {Lex.RndNilai()} total sebesar {AverageScore}"
        };
        Core = Util.GetRandom(Sentences);
    }

    public void EmbedComplement(Option option)
    {
        switch (option.Desc)
        {
            case "first":
                Complement[0] = "berdasarkan jawaban kuesioner";
                break;
            case "second":
                Lecturer = "beliau";
                break;
        }
    }
}