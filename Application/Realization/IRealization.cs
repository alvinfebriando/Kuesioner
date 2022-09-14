using Kuesioner.Application.Spec;

namespace Kuesioner.Application.Realization;

public interface IRealization
{
    public IList<IFormatter> Formatters { get; set; }
    public IEnumerable<ISpec> MPlan { get; set; }
    public List<string> ConvertToSentence();
    public void AddFormatter();
}