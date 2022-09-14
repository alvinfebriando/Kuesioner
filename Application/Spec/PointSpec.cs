using Kuesioner.Application.Lexicalization;
using Kuesioner.Application.Message;
using Kuesioner.Domain.Entities;

namespace Kuesioner.Application.Spec;

public class PointSpec : ISpec
{
    public PointSpec(string lecturer, Point point, IList<string> structure)
    {
        Lecturer = lecturer;
        Point = point;
        Structure = structure;
        Lex = new Lexicalization.Lexicalization();
    }

    public IList<IPointMessage> BadPoints { get; set; } = new List<IPointMessage>();
    public IList<IPointMessage> GoodPoints { get; set; } = new List<IPointMessage>();

    public string Lecturer { get; set; }
    public Point Point { get; set; }
    public IList<string> Structure { get; set; }
    private ILexicalization Lex { get; }
    public IList<IMessage> Order { get; set; } = new List<IMessage>();
    public IList<string> Sentences { get; set; } = new List<string>();

    public void Ordering()
    {
        if (IsGnG())
        {
            Order.Add((IMessage)GoodPoints[0]);
            Order.Add((IMessage)BadPoints[0]);
        }
        else
        {
            Order.Add((IMessage)BadPoints[0]);
            Order.Add((IMessage)GoodPoints[0]);
        }
    }

    public void Aggregate()
    {
        if (IsGnG())
        {
            if (GoodPoints.Count > 1)
            {
                var first = (IMultiLexicalizationMessage)Order[0];
                first.Lexicalization(GoodPoints);
                Order[0] = (IMessage)first;
            }
            else
            {
                Order[0].Lexicalization();
            }

            if (BadPoints.Count > 1)
            {
                var second = (IMultiLexicalizationMessage)Order[1];
                second.Lexicalization(BadPoints);
                Order[1] = (IMessage)second;
            }
            else
            {
                Order[1].Lexicalization();
            }
        }
        else
        {
            if (BadPoints.Count > 1)
            {
                var first = (IMultiLexicalizationMessage)Order[0];
                first.Lexicalization(BadPoints);
                Order[0] = (IMessage)first;
            }
            else
            {
                Order[1].Lexicalization();
            }

            if (GoodPoints.Count > 1)
            {
                var second = (IMultiLexicalizationMessage)Order[1];
                second.Lexicalization(GoodPoints);
                Order[1] = (IMessage)second;
            }
            else
            {
                Order[0].Lexicalization();
            }
        }


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

    private void Transform()
    {
        if (Structure.Contains("no good")) GoodPoints.Add(new NoGoodPointMessage(Lecturer, Point.Max, Lex));
        if (Structure.Contains("no bad")) BadPoints.Add(new NoBadPointMessage(Lecturer, Point.Min, Lex));
        foreach (var item in Point.Good) GoodPoints.Add(new GoodPointMessage(Lecturer, item, Lex));
        foreach (var item in Point.Bad) BadPoints.Add(new BadPointMessage(Lecturer, item, Lex));
    }

    private bool IsGnG()
    {
        return new List<string> { "no good", "good" }.Contains(Structure[2]);
    }
}