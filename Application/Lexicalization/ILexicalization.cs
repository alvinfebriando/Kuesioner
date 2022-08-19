namespace Kuesioner.Application.Lexicalization;

public interface ILexicalization
{
    public string RndResponden();
    public string RndMendapat();
    public string RndTertinggi();
    public string RndTerendah();
    public string RndNilai();
    public string GetStatus(double score);
}