using Kuesioner.Application.Lexicalization;
using Kuesioner.Domain.Entities;

namespace Kuesioner.Application.Message;

public class NoAdviceMessage : IMessage
{
    public NoAdviceMessage(string lecturer, IList<string> advices, ILexicalization lex)
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
            $"{Lecturer} dapat melakukan tips berikut ini untuk mempertahankan hasil maksimal, yaitu {advice}"
        };
        Core = Util.GetRandom(Sentences);
    }

    public void EmbedComplement(Option option)
    {
        throw new NotImplementedException();
    }
}