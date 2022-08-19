using Kuesioner.Domain.Entities;

namespace Kuesioner.Application.Message;

public interface IMessage
{
    public string Core { get; set; }
    public IList<string> Complement { get; set; }
    public IList<string> Sentences { get; set; }
    public void Lexicalization();
    public void EmbedComplement(Option option);
}