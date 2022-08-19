namespace Kuesioner.Application.Message;

public interface IMultiLexicalizationMessage
{
    public void Lexicalization(List<IPointMessage> messages);
}