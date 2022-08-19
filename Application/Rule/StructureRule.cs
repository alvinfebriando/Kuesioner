using Kuesioner.Domain.Entities;

namespace Kuesioner.Application.Rule;

public class StructureRule: IStructureRule
{
    public IList<string> Rule(Point point)
    {
        var output = new List<string>();
        if (Util.GetRandom(new List<int> { 0, 1 }) == 0)
        {
            output.Add("score");
            output.Add("performance");
        }
        else
        {
            output.Add("performance");
            output.Add("score");
        }
        
        if (IsGoodEmpty(point) && IsBadEmpty(point))
        {
            if (IsGoodFirst())
            {
                output.Add("no good");
                output.Add("no bad");
            }
            else
            {
                output.Add("no bad");
                output.Add("no good");
            }

            output.Add("no advice");
        }
        else if (IsGoodEmpty(point) && !IsBadEmpty(point))
        {
            if (IsGoodFirst())
            {
                output.Add("no good");
                output.Add("bad");
            }
            else
            {
                output.Add("bad");
                output.Add("no good");
            }

            output.Add("advice");
        }
        else if (!IsGoodEmpty(point) && IsBadEmpty(point))
        {
            if (IsGoodFirst())
            {
                output.Add("good");
                output.Add("no bad");
            }
            else
            {
                output.Add("no bad");
                output.Add("good");
            }

            output.Add("no advice");
        }
        else
        {
            if (IsGoodFirst())
            {
                output.Add("good");
                output.Add("bad");
            }
            else
            {
                output.Add("bad");
                output.Add("good");
            }

            output.Add("advice");
        }

        return output;
    }
    
    private static bool IsGoodFirst()
    {
        return Util.GetRandom(new List<int> { 0, 1 }) == 0;
    }

    private static bool IsGoodEmpty(Point point)
    {
        return point.Good.Count == 0;
    }

    private static bool IsBadEmpty(Point point)
    {
        return point.Bad.Count == 0;
    }
}