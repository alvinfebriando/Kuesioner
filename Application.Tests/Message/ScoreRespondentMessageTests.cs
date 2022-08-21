using Kuesioner.Application.Lexicalization;
using Kuesioner.Application.Message;
using Kuesioner.Domain.Entities;

namespace Application.Tests.Message;

public class ScoreRespondentMessageTests
{
    private readonly ScoreRespondentMessage _sut;

    public ScoreRespondentMessageTests()
    {
        const string lecturer = "pak alvin";
        const double averageScore = 3.5;
        const int respondentCount = 20;
        var lex = new Lexicalization();
        _sut = new ScoreRespondentMessage(lecturer, averageScore, respondentCount, lex);
    }

    [Fact]
    public void EmbedComplement_OptionFirst_ChangeComplementValue()
    {
        // Arrange
        var option = new Option("first");
        const string expected = "berdasarkan jawaban kuesioner";

        // Act
        _sut.EmbedComplement(option);

        // Assert
        Assert.Equal(expected, _sut.Complement[0]);
    }

    [Fact]
    public void EmbedComplement_OptionSecond_ChangeLecturerValue()
    {
        // Arrange
        var option = new Option("second");
        const string expected = "beliau";

        // Act
        _sut.EmbedComplement(option);

        // Assert
        Assert.Equal(expected, _sut.Lecturer);
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
}