using Kuesioner.Application.Message;

namespace Kuesioner.Application.Spec;

public interface ISpec
{
    public IList<IMessage> Order { get; set; }
    public IList<string> Sentences { get; set; }
    public void Ordering();
    public void Aggregate();
    public IList<string> Build();
}