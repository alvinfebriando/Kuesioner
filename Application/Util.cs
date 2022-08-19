using Kuesioner.Domain.Entities;
using Numpy;

namespace Kuesioner.Application;

public class Util
{
    public static T GetRandom<T>(IList<T> ts)
    {
        Random rnd = new();
        var element = ts[rnd.Next(0, ts.Count)];
        return element;
    }

    public static int[][] GenerateScore(int question, int respondentCount, double[][] weight)
    {
        var score = new int[question][];
        for (var i = 0; i < question; i++)
        {
            var result = np.random.choice(new[] { 1, 2, 3, 4, 5 }, new[] { respondentCount }, p: weight[i]);
            score[i] = result.GetData<int>();
        }

        return Transpose(score);
    }

    public static List<Answer> Process(int[][] answerList, List<Question> questions)
    {
        answerList = Transpose(answerList);
        return answerList.Select((t, i) => new Answer(np.mean(t), questions[i])).ToList();
    }

    public static T[][] Transpose<T>(T[][] arr)
    {
        var rowCount = arr.Length;
        var columnCount = arr[0].Length;
        var transposed = new T[columnCount][];
        if (rowCount == columnCount)
        {
            transposed = (T[][])arr.Clone();
            for (var i = 1; i < rowCount; i++)
            for (var j = 0; j < i; j++)
                (transposed[i][j], transposed[j][i]) = (transposed[j][i], transposed[i][j]);
        }
        else
        {
            for (var column = 0; column < columnCount; column++)
            {
                transposed[column] = new T[rowCount];
                for (var row = 0; row < rowCount; row++) transposed[column][row] = arr[row][column];
            }
        }

        return transposed;
    }
}