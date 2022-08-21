using Kuesioner.Application.Lexicalization;
using Kuesioner.Application.Message;
using Kuesioner.Domain.Entities;
using Kuesioner.Infrastructure;

namespace Application.Tests.Message;

public class GoodPointMessageTests
{
    private readonly GoodPointMessage _sut;

    public GoodPointMessageTests()
    {
        const string lecturer = "pak alvin";
        var lex = new Lexicalization();
        var answer = new Answer(4.1, Data.Questions[0]);
        _sut = new GoodPointMessage(lecturer, answer, lex);
    }

    [Theory]
    [InlineData("bad")]
    [InlineData("no bad")]
    public void EmbedComplement_Option_ChangeComplementValue(string desc)
    {
        // Arrange
        var option = new Option(desc);
        const string notExpected = "";

        // Act
        _sut.EmbedComplement(option);

        // Assert
        Assert.NotEqual(notExpected, _sut.Complement[0]);
    }

    [Fact]
    public void Lexicalization_NoArgument_ChangeCoreValue()
    {
        // Arrange
        var expected = _sut.Lecturer;

        // Act
        _sut.Lexicalization();

        // Assert
        Assert.Contains(expected, _sut.Core);
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Lexicalization_MultiMessages_ChangeCoreValue(string expected, IList<IPointMessage> messages)
    {
        // Act
        _sut.Lexicalization(messages);

        // Assert
        Assert.Contains(expected, _sut.Core);
    }

    public static IEnumerable<object[]> TestData()
    {
        const string lecturer = "pak alvin";
        var lex = new Lexicalization();
        var answer1 = new Answer(4.5, Data.Questions[0]);
        var answer2 = new Answer(4, Data.Questions[1]);
        var answer3 = new Answer(4.4, Data.Questions[2]);
        var answer4 = new Answer(3.8, Data.Questions[3]);
        var message1 = new GoodPointMessage(lecturer, answer1, lex);
        var message2 = new GoodPointMessage(lecturer, answer2, lex);
        var message3 = new GoodPointMessage(lecturer, answer3, lex);
        var message4 = new GoodPointMessage(lecturer, answer4, lex);
        yield return new object[] { answer2.Question.Title, new List<IPointMessage> { message1, message2 } };
        yield return new object[] { answer3.Question.Title, new List<IPointMessage> { message1, message2, message3 } };
        yield return new object[]
            { answer3.Question.Title, new List<IPointMessage> { message1, message2, message3, message4 } };
    }
}