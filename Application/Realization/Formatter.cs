namespace Kuesioner.Application.Realization;

public class CapitalSentenceFormatter : IFormatter
{
    public string Format(string s)
    {
        return char.ToUpper(s[0]) + s[1..].ToLower();
    }
}

public class TrimFormatter : IFormatter
{
    public string Format(string s)
    {
        return s.Trim();
    }
}