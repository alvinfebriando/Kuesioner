namespace Kuesioner.Application.Message;

public interface IMultiLexicalizationMessage
{
    public void Lexicalization(IList<IPointMessage> messages);
}