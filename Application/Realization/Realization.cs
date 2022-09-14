using Kuesioner.Application.Spec;

namespace Kuesioner.Application.Realization;

public class Realization : IRealization
{
    public Realization(IEnumerable<ISpec> mPlan)
    {
        MPlan = mPlan;
        Formatters = new List<IFormatter>();
    }

    public IList<IFormatter> Formatters { get; set; }

    public IEnumerable<ISpec> MPlan { get; set; }


    public List<string> ConvertToSentence()
    {
        var output = new List<string>();
        foreach (var spec in MPlan)
        {
            spec.Build();
            output.AddRange(spec.Sentences);
        }

        foreach (var formatter in Formatters)
            for (var i = 0; i < output.Count; i++)
                output[i] = formatter.Format(output[i]);
        return output;
    }

    public void AddFormatter()
    {
        Formatters.Add(new TrimFormatter());
        Formatters.Add(new CapitalSentenceFormatter());
    }
}