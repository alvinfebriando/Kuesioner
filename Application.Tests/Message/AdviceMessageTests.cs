using Kuesioner.Application.Lexicalization;
using Kuesioner.Application.Message;
using Kuesioner.Domain.Entities;
using Kuesioner.Infrastructure;

namespace Application.Tests.Message;

public class AdviceMessageTests
{
    private readonly AdviceMessage _sut;

    public AdviceMessageTests()
    {
        const string lecturer = "pak alvin";
        var advices = new List<string> { "advice1", "advice2", "advice3" };
        var lex = new Lexicalization();
        _sut = new AdviceMessage(lecturer, advices, lex);
    }

    [Fact]
    public void Lexicalization_NoArgument_ChangeCoreValue()
    {
        // Arrange
        const string notExpected = "";

        // Act
        _sut.Lexicalization();

        // Assert
        Assert.NotEqual(notExpected, _sut.Core);
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Lexicalization_MultiAdvice_ChangeCoreValue(List<IPointMessage> messages)
    {
        // Arrange
        const string notExpected = "";


        // Act
        _sut.Lexicalization(messages);

        // Assert
        Assert.NotEqual(notExpected, _sut.Core);
    }

    public static IEnumerable<object[]> TestData()
    {
        var answer1 = new Answer(2.3, Data.Questions[0]);
        var answer2 = new Answer(1.7, Data.Questions[1]);
        var answer3 = new Answer(1.9, Data.Questions[2]);
        const string lecturer = "pak alvin";
        var lex = new Lexicalization();
        var message1 = new BadPointMessage(lecturer, answer1, lex);
        var message2 = new BadPointMessage(lecturer, answer2, lex);
        var message3 = new BadPointMessage(lecturer, answer3, lex);
        yield return new object[] { new List<IPointMessage> { message1, message2 } };
        yield return new object[] { new List<IPointMessage> { message1, message2, message3 } };
    }
}