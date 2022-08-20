using Kuesioner.Application.Lexicalization;
using Kuesioner.Domain.Entities;

namespace Kuesioner.Application.Message;

public class PerformanceStatusMessage : IMessage
{
    public PerformanceStatusMessage(string lecturer, double averageScore, ILexicalization lex)
    {
        Lecturer = lecturer;
        AverageScore = averageScore;
        Lex = lex;
        Status = Lex.GetStatus(AverageScore);
    }

    public string Lecturer { get; set; }
    public double AverageScore { get; set; }
    public string Status { get; set; }
    private ILexicalization Lex { get; }

    public string Core { get; set; } = "";
    public IList<string> Complement { get; set; } = new List<string> { "" };
    public IList<string> Sentences { get; set; } = new List<string>();

    public void Lexicalization()
    {
        Sentences = new List<string>
        {
            $"pencapaian {Lecturer} dinilai {Status}",
            $"{Lecturer} {Lex.RndMendapat()} predikat {Status}",
            $"performa {Lecturer} dalam penilaian ini adalah {Status}"
        };
        Core = Util.GetRandom(Sentences);
    }

    public void EmbedComplement(Option option)
    {
        if (option.Desc == "second") Lecturer = "beliau";
    }
}