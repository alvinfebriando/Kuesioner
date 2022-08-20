using Kuesioner.Application.Lexicalization;
using Kuesioner.Domain.Entities;

namespace Kuesioner.Application.Message;

public class GoodPointMessage : IMessage, IPointMessage, IMultiLexicalizationMessage
{
    public GoodPointMessage(string lecturer, Answer answer, ILexicalization lex)
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
            $"{Complement[0]} {Lecturer} sukses dalam hal {Answer.Question.Title}, hal ini dapat dilihat dari {Lex.RndNilai()} rata-rata sebesar {Answer.Score}",
            $"{Complement[0]} untuk bagian {Answer.Question.Title}, {Lecturer} sudah menjalankannya dengan baik, adapun nilai yang didapatkan adalah {Answer.Score}"
        };
        Core = Util.GetRandom(Sentences);
    }

    public void EmbedComplement(Option option)
    {
        if (option.Desc == "bad")
            Complement[0] = Util.GetRandom(new List<string> { "walaupun demikian", "meskipun demikian" });
        if (option.Desc == "no bad")
            Complement[0] = Util.GetRandom(new List<string> { "dan juga", "serta" });
    }

    public void Lexicalization(IList<IPointMessage> messages)
    {
        if (messages.Count == 2)
        {
            var second = messages[1];
            Sentences = new List<string>
            {
                $"{Complement[0]} {Lecturer} sukses dalam hal {Answer.Question.Title} dan {second.Answer.Question.Title}, hal ini dapat dilihat dari {Lex.RndNilai()} rata-rata masing-masingnya  sebesar {Answer.Score} dan {second.Answer.Score}",
                $"{Complement[0]} untuk bagian {Answer.Question.Title} dan {second.Answer.Question.Title}, {Lecturer} sudah menjalankannya dengan baik, adapun nilai yang didapatkan masing-masingnya adalah {Answer.Score} dan {second.Answer.Score}"
            };
        }
        else if (messages.Count >= 3)
        {
            var second = messages[1];
            var third = messages[2];
            Sentences = new List<string>
            {
                $"{Complement[0]} {Lecturer} sukses dalam hal {Answer.Question.Title}, {second.Answer.Question.Title}, dan {third.Answer.Question.Title}, hal ini dapat dilihat dari {Lex.RndNilai()} rata-rata masing-masingnya  sebesar {Answer.Score}, {second.Answer.Score}, dan {third.Answer.Score}",
                $"{Complement[0]} untuk bagian {Answer.Question.Title},  {second.Answer.Question.Title}, dan {third.Answer.Question.Title}, {Lecturer} sudah menjalankannya dengan baik, adapun nilai yang didapatkan masing-masingnya adalah {Answer.Score}, {second.Answer.Score}, dan {third.Answer.Score}"
            };
        }

        Core = Util.GetRandom(Sentences);
    }

    public string Lecturer { get; set; }
    public Answer Answer { get; set; }
}