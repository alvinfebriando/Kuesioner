using Kuesioner.Application.Spec;

namespace Kuesioner.Application.Realization;

public interface IRealization
{
    public IEnumerable<ISpec> MPlan { get; set; }
    public List<string> ConvertToSentence();
    public string Format();
}