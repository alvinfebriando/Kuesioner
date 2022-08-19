using Kuesioner.Application.Lexicalization;
using Kuesioner.Domain.Entities;

namespace Kuesioner.Application.Message;

public class AdviceMessage: IMessage,IMultiLexicalizationMessage
{
    public AdviceMessage(string lecturer, IList<string> advices, ILexicalization lex)
    {
        Lecturer = lecturer;
        Advices = advices;
        Lex = lex;
    }

    public string Core { get; set; } = "";
    public IList<string> Complement { get; set; } = new List<string>();
    public IList<string> Sentences { get; set; } = new List<string>();
    public string Lecturer { get; set; }
    public IList<string> Advices { get; set; }
    private ILexicalization Lex { get; set; }
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

    public void Lexicalization(IList<IPointMessage> messages)
    {
        var advice = Util.GetRandom(Advices);
        if (messages.Count == 2)
        {
            var second = Util.GetRandom(messages[1].Answer.Question.Advices);
            Sentences = new List<string>
            {
                $"Ada beberapa cara yang dapat dilakukan oleh {Lecturer} untuk meningkatkan hasil evaluasi, diantaranya adalah {advice} dan {second}",
                $"Sistem menyarankan {Lecturer} untuk melakukan {advice} dan {second} untuk hasil yang lebih optimal"
            };
            Core = Util.GetRandom(Sentences);
        }
    }
}