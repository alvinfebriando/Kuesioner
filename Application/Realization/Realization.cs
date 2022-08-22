using Kuesioner.Application.Spec;

namespace Kuesioner.Application.Realization;

public class Realization : IRealization
{
    public Realization(IEnumerable<ISpec> mPlan)
    {
        MPlan = mPlan;
    }

    public IEnumerable<ISpec> MPlan { get; set; }

    public string Format()
    {
        throw new NotImplementedException();
    }


    public List<string> ConvertToSentence()
    {
        var output = new List<string>();
        foreach (var spec in MPlan)
        {
            spec.Build();
            output.AddRange(spec.Sentences);
        }

        return output;
    }
}