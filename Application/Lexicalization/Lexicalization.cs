namespace Kuesioner.Application.Lexicalization;

public class Lexicalization : ILexicalization
{
    public string RndResponden()
    {
        return Util.GetRandom(new List<string> { "mahasiswa", "responden" });
    }

    public string RndMendapat()
    {
        return Util.GetRandom(new List<string> { "mendapat", "menerima", "memiliki", "memperoleh" });
    }

    public string RndTertinggi()
    {
        return Util.GetRandom(new List<string> { "tertinggi", "paling tinggi" });
    }

    public string RndTerendah()
    {
        return Util.GetRandom(new List<string> { "terendah", "paling rendah" });
    }

    public string RndNilai()
    {
        return Util.GetRandom(new List<string> { "nilai", "skor" });
    }

    public string GetStatus(double score)
    {
        if (Math.Round(score) == 1) return "sangat tidak baik";
        if (Math.Round(score) == 2) return "tidak baik";
        if (Math.Round(score) == 3) return "cukup";
        if (Math.Round(score) == 4) return "baik";
        return "sangat baik";
    }
}