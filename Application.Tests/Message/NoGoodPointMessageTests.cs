using Kuesioner.Application.Lexicalization;
using Kuesioner.Application.Message;
using Kuesioner.Domain.Entities;
using Kuesioner.Infrastructure;

namespace Application.Tests.Message;

public class NoGoodPointMessageTests
{
    private readonly NoGoodPointMessage _sut;

    public NoGoodPointMessageTests()
    {
        const string lecturer = "pak alvin";
        var lex = new Lexicalization();
        var answer = new Answer(2.9, Data.Questions[0]);
        _sut = new NoGoodPointMessage(lecturer, answer, lex);
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
        var expected = _sut.Answer.Question.Title;

        // Act
        _sut.Lexicalization();

        // Assert
        Assert.Contains(expected, _sut.Core);
    }
}