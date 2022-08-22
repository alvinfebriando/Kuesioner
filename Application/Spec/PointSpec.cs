using Kuesioner.Application.Lexicalization;
using Kuesioner.Application.Message;
using Kuesioner.Domain.Entities;

namespace Kuesioner.Application.Spec;

public class PointSpec : ISpec
{
    private readonly IList<IPointMessage> _badPoints = new List<IPointMessage>();
    private readonly IList<IPointMessage> _goodPoints = new List<IPointMessage>();

    public PointSpec(string lecturer, Point point, IList<string> structure)
    {
        Lecturer = lecturer;
        Point = point;
        Structure = structure;
        Lex = new Lexicalization.Lexicalization();
    }

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
            Order.Add((IMessage)_goodPoints[0]);
            Order.Add((IMessage)_badPoints[0]);
        }
        else
        {
            Order.Add((IMessage)_badPoints[0]);
            Order.Add((IMessage)_goodPoints[0]);
        }
    }

    public void Aggregate()
    {
        if (IsGnG())
        {
            if (_goodPoints.Count > 1)
            {
                var first = (IMultiLexicalizationMessage)Order[0];
                first.Lexicalization(_goodPoints);
                Order[0] = (IMessage)first;
            }
            else
            {
                Order[0].Lexicalization();
            }

            if (_badPoints.Count > 1)
            {
                var second = (IMultiLexicalizationMessage)Order[1];
                second.Lexicalization(_badPoints);
                Order[1] = (IMessage)second;
            }
            else
            {
                Order[1].Lexicalization();
            }
        }
        else
        {
            if (_badPoints.Count > 1)
            {
                var first = (IMultiLexicalizationMessage)Order[0];
                first.Lexicalization(_badPoints);
                Order[0] = (IMessage)first;
            }
            else
            {
                Order[1].Lexicalization();
            }

            if (_goodPoints.Count > 1)
            {
                var second = (IMultiLexicalizationMessage)Order[1];
                second.Lexicalization(_goodPoints);
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
        if (Structure.Contains("no good")) _goodPoints.Add(new NoGoodPointMessage(Lecturer, Point.Max, Lex));
        if (Structure.Contains("no bad")) _badPoints.Add(new NoBadPointMessage(Lecturer, Point.Min, Lex));
        foreach (var item in Point.Good) _goodPoints.Add(new GoodPointMessage(Lecturer, item, Lex));
        foreach (var item in Point.Bad) _badPoints.Add(new BadPointMessage(Lecturer, item, Lex));
    }

    private bool IsGnG()
    {
        return new List<string> { "no good", "good" }.Contains(Structure[2]);
    }
}