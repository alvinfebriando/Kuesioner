using Kuesioner.Application.Lexicalization;
using Kuesioner.Domain.Entities;

namespace Kuesioner.Application.Message;

public class NoBadPointMessage : IMessage, IPointMessage
{
    public NoBadPointMessage(string lecturer, Answer answer, ILexicalization lex)
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
            $"{Complement[0]} tidak ada bagian yang dinilai kurang memuaskan dengan {Lex.RndNilai()} {Lex.RndTerendah()} sebesar {Answer.Score} untuk pertanyaan {Answer.Question.Title}",
            $"{Complement[0]} {Lecturer} sukses menjaga {Lex.RndNilai()} yang didapatkan tidak kurang dari standar dengan {Lex.RndNilai()} {Lex.RndTerendah()} sebesar {Answer.Score} untuk bagian {Answer.Question.Title}"
        };
        Core = Util.GetRandom(Sentences);
    }

    public void EmbedComplement(Option option)
    {
        if (option.Desc == "good")
            Complement[0] = Util.GetRandom(new List<string> { "serta", "dan juga" });
        else if (option.Desc == "no good")
            Complement[0] = Util.GetRandom(new List<string> { "walaupun demikian", "meskipun demikian" });
    }

    public string Lecturer { get; set; }
    public Answer Answer { get; set; }
}