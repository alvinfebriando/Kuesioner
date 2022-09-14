using Kuesioner.Application.Lexicalization;
using Kuesioner.Domain.Entities;

namespace Kuesioner.Application.Message;

public class AdviceMessage : IMessage
{
    public AdviceMessage(string lecturer, IList<string> advices, ILexicalization lex)
    {
        Lecturer = lecturer;
        Advices = advices;
        Lex = lex;
    }

    public string Lecturer { get; set; }
    public IList<string> Advices { get; set; }
    private ILexicalization Lex { get; }

    public string Core { get; set; } = "";
    public IList<string> Complement { get; set; } = new List<string> { "" };
    public IList<string> Sentences { get; set; } = new List<string>();

    public void Lexicalization()
    {
        var advice = Util.GetRandom(Advices);
        Sentences = new List<string>
        {
            $"Cara yang dapat dilakukan oleh {Lecturer} untuk meningkatkan hasil evaluasi, yaitu {advice}",
            $"Sistem menyarankan {Lecturer} untuk melakukan {advice} untuk hasil yang lebih optimal"
        };
        Core = Util.GetRandom(Sentences);
    }

    public void EmbedComplement(Option option)
    {
        throw new NotImplementedException();
    }

    public void Lexicalization(IList<Answer> answers)
    {
        var advice = Util.GetRandom(Advices);
        if (answers.Count == 2)
        {
            var second = Util.GetRandom(answers[1].Question.Advices);
            Sentences = new List<string>
            {
                $"Ada beberapa cara yang dapat dilakukan oleh {Lecturer} untuk meningkatkan hasil evaluasi, diantaranya adalah {advice} dan {second}",
                $"Sistem menyarankan {Lecturer} untuk melakukan {advice} dan {second} untuk hasil yang lebih optimal"
            };
            Core = Util.GetRandom(Sentences);
        }
        else if (answers.Count >= 3)
        {
            var second = Util.GetRandom(answers[1].Question.Advices);
            var third = Util.GetRandom(answers[2].Question.Advices);
            Sentences = new List<string>
            {
                $"ada beberapa cara yang dapat dilakukan oleh {Lecturer} untuk meningkatkan hasil evaluasi, diantaranya adalah {advice}, {second}, dan {third}",
                $"sistem menyarankan {Lecturer} untuk melakukan {advice}, {second}, dan {third} untuk hasil yang lebih optimal"
            };
            Core = Util.GetRandom(Sentences);
        }
    }
}