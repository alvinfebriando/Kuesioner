namespace Kuesioner.Application.Realization;

public class CapitalSentenceFormatter : IFormatter
{
    public string Format(string s)
    {
        return char.ToUpper(s[0]) + s[1..];
    }
}

public class TrimFormatter : IFormatter
{
    public string Format(string s)
    {
        return s.Trim();
    }
}

public class LecturerFormatter : IFormatter
{
    public LecturerFormatter(string lecturer)
    {
        Lecturer = lecturer;
    }

    public string Lecturer { get; set; }

    public string Format(string s)
    {
        var x = Lecturer.Split(" ");
        x[1] = char.ToUpper(x[1][0]) + x[1][1..];
        return s.Replace(Lecturer, string.Join(" ", x));
    }
}