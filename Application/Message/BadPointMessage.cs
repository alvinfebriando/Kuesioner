using Kuesioner.Application.Lexicalization;
using Kuesioner.Domain.Entities;

namespace Kuesioner.Application.Message;

public class BadPointMessage : IMessage, IPointMessage, IMultiLexicalizationMessage
{
    public BadPointMessage(string lecturer, Answer answer, ILexicalization lex)
    {
        Lecturer = lecturer;
        Answer = answer;
        Lex = lex;
    }

    public string Core { get; set; } = "";
    public IList<string> Complement { get; set; } = new List<string>();
    public IList<string> Sentences { get; set; } = new List<string>();
    private ILexicalization Lex { get; set; }

    public void Lexicalization()
    {
        Sentences = new List<string>
        {
            $"{Lecturer} kurang sukses dalam bagian {Answer.Question.Title} dengan {Lex.RndNilai()} sebesar {Answer.Score}",
            $"untuk bagian {Answer.Question.Title}, {Lecturer} mendapat hasil yang kurang memuaskan dengan hanya {Lex.RndMendapat()} {Lex.RndNilai()}  sebesar {Answer.Score}"
        };
        Core = Util.GetRandom(Sentences);
    }

    public void EmbedComplement(Option option)
    {
        if (option.Desc == "good")
            Complement[0] = Util.GetRandom(new List<string> { "namun, tetapi" });
        else if (option.Desc == "no good") Complement[0] = Util.GetRandom(new List<string> { "dan juga", "serta" });
    }

    public void Lexicalization(List<IPointMessage> messages)
    {
        if (messages.Count == 2)
        {
            var second = messages[1];
            Sentences = new List<string>
            {
                $"{Lecturer} kurang sukses dalam bagian {Answer.Question.Title} dan {second.Answer.Question.Title} dengan {Lex.RndNilai()} masing-masingnya sebesar {Answer.Score} dan {second.Answer.Score}",
                $"untuk bagian {Answer.Question.Title} dan {second.Answer.Question.Title}, {Lecturer} mendapat hasil yang kurang memuaskan dengan hanya {Lex.RndMendapat()} {Lex.RndNilai()} sebesar {Answer.Score} dan {second.Answer.Score}"
            };
            Core = Util.GetRandom(Sentences);
        }
        else if (messages.Count == 3)
        {
            var second = messages[1];
            var third = messages[2];
            Sentences = new List<string>
            {
                $"{Lecturer} kurang sukses dalam bagian {Answer.Question.Title}, {second.Answer.Question.Title}, dan {third.Answer.Question.Title} dengan {Lex.RndNilai()} masing-masingnya sebesar {Answer.Score}, {second.Answer.Score}, dan {third.Answer.Score}",
                $"untuk bagian {Answer.Question.Title}, {second.Answer.Question.Title}, dan {third.Answer.Question.Title}, {Lecturer} mendapat hasil yang kurang memuaskan dengan hanya {Lex.RndMendapat()} {Lex.RndNilai()} sebesar {Answer.Score}, {second.Answer.Score}, dan {third.Answer.Score}"
            };
            Core = Util.GetRandom(Sentences);
        }
    }

    public string Lecturer { get; set; }
    public Answer Answer { get; set; }
}