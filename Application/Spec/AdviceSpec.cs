using Kuesioner.Application.Lexicalization;
using Kuesioner.Application.Message;
using Kuesioner.Domain.Entities;

namespace Kuesioner.Application.Spec;

public class AdviceSpec : ISpec
{
    public AdviceSpec(string lecturer, Point point, IList<string> structure)
    {
        Lecturer = lecturer;
        Point = point;
        Structure = structure;
        Lex = new Lexicalization.Lexicalization();
    }

    public string Lecturer { get; set; }
    public Point Point { get; set; }
    public IList<string> Structure { get; set; }
    private IList<IMessage> Advices { get; } = new List<IMessage>();
    private ILexicalization Lex { get; }

    public IList<IMessage> Order { get; set; } = new List<IMessage>();
    public IList<string> Sentences { get; set; } = new List<string>();

    public void Ordering()
    {
        Order.Add(Advices[0]);
    }

    public void Aggregate()
    {
        if (Advices.Count > 1)
        {
            var multi = (IMultiLexicalizationMessage)Order[0];
            var a = Advices.Cast<IPointMessage>().ToList();
            multi.Lexicalization(a);
            Order[0] = (IMessage)multi;
        }
        else
        {
            Order[0].Lexicalization();
        }

        Sentences.Add(Order[0].Core);
    }

    public IList<string> Build()
    {
        Transform();
        Ordering();
        Aggregate();
        return Sentences;
    }

    private void Transform()
    {
        if (Structure[4] == "no advice") Advices.Add(new NoAdviceMessage(Lecturer, Point.Min.Question.Advices, Lex));
        foreach (var answer in Point.Bad) Advices.Add(new AdviceMessage(Lecturer, answer.Question.Advices, Lex));
    }
}