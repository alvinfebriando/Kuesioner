using Kuesioner.Application;
using Kuesioner.Infrastructure;

namespace Application.Tests;

public class UtilTests
{
    [Fact]
    public void GetRandom_ReturnOneOfItsMember()
    {
        // Arrange
        IList<string> lists = new List<string> { "a", "b", "c" };

        // Act
        var result = Util.GetRandom(lists);

        // Assert
        Assert.Contains(result, lists);
    }

    [Theory]
    [MemberData(nameof(TransposeTestData))]
    public void TransposeShouldTransposeJaggedArray(int[][] arr, int[][] expected)
    {
        // Act
        var result = Util.Transpose(arr);

        // Assert
        Assert.Equal(expected, result);
    }

    public static IEnumerable<object[]> TransposeTestData()
    {
        var arr = new[]
        {
            new[] { 0, 1 },
            new[] { 2, 3 },
            new[] { 4, 5 }
        };
        var arr2 = new[]
        {
            new[] { 0, 1 },
            new[] { 2, 3 }
        };

        var transposed = new[]
        {
            new[] { 0, 2, 4 },
            new[] { 1, 3, 5 }
        };
        var transposed2 = new[]
        {
            new[] { 0, 2 },
            new[] { 1, 3 }
        };

        yield return new object[] { arr, transposed };
        yield return new object[] { arr2, transposed2 };
    }

    [Theory]
    [InlineData(6, 10)]
    [InlineData(5, 5)]
    public void GenerateScoreShouldReturnAnRespondentCountXQuestionSizeScoreArray(int question, int respondentCount)
    {
        // Arrange
        var weights = new[]
        {
            Data.Weight["mostly1"],
            Data.Weight["mostly1"],
            Data.Weight["mostly1"],
            Data.Weight["mostly1"],
            Data.Weight["mostly1"],
            Data.Weight["mostly1"]
        };

        // Act
        var result = Util.GenerateScore(question, respondentCount, weights);

        // Assert
        Assert.Equal(respondentCount, result.Length);
        Assert.Equal(question, result[0].Length);
    }

    [Fact]
    public void ProcessShouldReturnAnArrayOfAverageValue()
    {
        // Arrange
        var answers = new[]
        {
            new[] { 1, 3, 5 },
            new[] { 3, 5, 7 }
        };

        // Act
        var result = Util.Process(answers, Data.Questions);

        // Assert
        Assert.Equal(2, result[0].Score);
        Assert.Equal(4, result[1].Score);
        Assert.Equal(6, result[2].Score);
    }
}