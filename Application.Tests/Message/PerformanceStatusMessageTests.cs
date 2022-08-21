using Kuesioner.Application.Lexicalization;
using Kuesioner.Application.Message;
using Kuesioner.Domain.Entities;

namespace Application.Tests.Message;

public class PerformanceStatusMessageTests
{
    private readonly PerformanceStatusMessage _sut;

    public PerformanceStatusMessageTests()
    {
        const string lecturer = "pak alvin";
        const double averageScore = 3.5;
        var lex = new Lexicalization();
        _sut = new PerformanceStatusMessage(lecturer, averageScore, lex);
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