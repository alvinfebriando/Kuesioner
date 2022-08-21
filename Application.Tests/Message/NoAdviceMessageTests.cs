using Kuesioner.Application.Lexicalization;
using Kuesioner.Application.Message;

namespace Application.Tests.Message;

public class NoAdviceMessageTests
{
    private readonly NoAdviceMessage _sut;

    public NoAdviceMessageTests()
    {
        const string lecturer = "pak alvin";
        var advices = new List<string> { "advice1", "advice2", "advice3" };
        var lex = new Lexicalization();
        _sut = new NoAdviceMessage(lecturer, advices, lex);
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
}