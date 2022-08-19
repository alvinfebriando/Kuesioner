namespace Kuesioner.Domain.Entities;

public class Option
{
    public Option(string desc)
    {
        Desc = desc;
    }

    public string Desc { get; set; }
}