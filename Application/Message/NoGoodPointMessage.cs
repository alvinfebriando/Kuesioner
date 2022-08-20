using Kuesioner.Application.Lexicalization;
using Kuesioner.Domain.Entities;

namespace Kuesioner.Application.Message;

public class NoGoodPointMessage : IMessage, IPointMessage
{
    public NoGoodPointMessage(string lecturer, Answer answer, ILexicalization lex)
    {
        Lecturer = lecturer;
        Answer = answer;
        Lex = lex;
    }

    private ILexicalization Lex { get; }

    public string Core { get; set; } = "";
    public IList<string> Complement { get; set; } = new List<string> { "" };
    public IList<string> Sentences { get; set; } = new List<string>();

    public void Lexicalization()
    {
        Sentences = new List<string>
        {
            $"{Lecturer} belum mencapai performa yang diinginkan, dari pertanyaan yang diajukan, {Lex.RndNilai()} {Lex.RndTertinggi()} hanya sebesar {Answer.Score} untuk pertanyaan {Answer.Question.Title}",
            $"{Lecturer} belum mencatatkan hasil yang baik, dengan {Lex.RndNilai()} {Lex.RndTertinggi()} dicatatkan untuk pertanyaan {Answer.Question.Title} senilai {Answer.Score}"
        };
        Core = Util.GetRandom(Sentences);
    }

    public void EmbedComplement(Option option)
    {
        if (option.Desc == "bad")
            Complement[0] = Util.GetRandom(new List<string> { "serta", "dan juga" });
        else if (option.Desc == "no bad")
            Complement[0] = Util.GetRandom(new List<string> { "walaupun demikian", "meskipun demikian" });
    }

    public string Lecturer { get; set; }
    public Answer Answer { get; set; }
}