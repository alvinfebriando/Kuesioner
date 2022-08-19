using Kuesioner.Application.Lexicalization;
using Kuesioner.Application.Message;
using Kuesioner.Domain.Entities;

namespace Kuesioner.Application.Spec;

public class AdviceSpec: ISpec
{
    public AdviceSpec(string lecturer, Point badPoint, IList<string> structure)
    {
        Lecturer = lecturer;
        BadPoint = badPoint;
        Structure = structure;
        Lex = new Lexicalization.Lexicalization();
    }

    public IList<IMessage> Order { get; set; } = new List<IMessage>();
    public IList<string> Sentences { get; set; } = new List<string>();
    public string Lecturer { get; set; }
    public Point BadPoint { get; set; }
    public IList<string> Structure { get; set; }
    private IList<IMessage> Advices { get; set; } = new List<IMessage>();
    private ILexicalization Lex { get; set; }
    private void Transform()
    {
        if (Structure[4] == "no bad")
        {
            Advices.Add(new NoAdviceMessage(Lecturer, BadPoint.Min.Question.Advices, Lex));
        }
        foreach (var answer in BadPoint.Bad)
        {
            Advices.Add(new AdviceMessage(Lecturer, answer.Question.Advices, Lex));
        }
    }
    public void Ordering()
    {
        Order.Add(Advices[0]);
    }

    public void Aggregate()
    {
        Sentences.Add(Order[0].Core);
        Sentences.Add(Order[1].Core);
    }

    public IList<string> Build()
    {
        Transform();
        Ordering();
        Aggregate();
        return Sentences;
    }
}