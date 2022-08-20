using Kuesioner.Domain.Entities;

namespace Kuesioner.Infrastructure;

public class Data
{
    public static readonly Dictionary<string, double[]> Weight = new()
    {
        { "mostly1", new[] { 0.75, 0.1, 0.075, 0.05, 0.025 } },
        { "mostly1n2v1", new[] { 0.35, 0.25, 0.2, 0.15, 0.05 } },
        { "mostly1n2v2", new[] { 0.3, 0.3, 0.2, 0.15, 0.05 } },
        { "mostly1n2v3", new[] { 0.25, 0.35, 0.2, 0.15, 0.05 } },
        { "mostly1n3v1", new[] { 0.35, 0.2, 0.25, 0.15, 0.05 } },
        { "mostly1n3v2", new[] { 0.3, 0.2, 0.3, 0.15, 0.05 } },
        { "mostly1n3v3", new[] { 0.25, 0.2, 0.35, 0.15, 0.05 } },
        { "mostly1n4v1", new[] { 0.35, 0.15, 0.15, 0.25, 0.1 } },
        { "mostly1n4v2", new[] { 0.3, 0.15, 0.15, 0.3, 0.1 } },
        { "mostly1n4v3", new[] { 0.25, 0.15, 0.15, 0.35, 0.1 } },
        { "mostly1n5v1", new[] { 0.35, 0.15, 0.15, 0.1, 0.25 } },
        { "mostly1n5v2", new[] { 0.3, 0.15, 0.15, 0.1, 0.3 } },
        { "mostly1n5v3", new[] { 0.25, 0.15, 0.15, 0.1, 0.35 } },
        { "mostly2", new[] { 0.1, 0.75, 0.075, 0.05, 0.025 } },
        { "mostly2n3v1", new[] { 0.2, 0.35, 0.25, 0.15, 0.05 } },
        { "mostly2n3v2", new[] { 0.2, 0.3, 0.3, 0.15, 0.05 } },
        { "mostly2n3v3", new[] { 0.2, 0.25, 0.35, 0.15, 0.05 } },
        { "mostly2n4v1", new[] { 0.15, 0.35, 0.2, 0.25, 0.05 } },
        { "mostly2n4v2", new[] { 0.15, 0.3, 0.2, 0.3, 0.05 } },
        { "mostly2n4v3", new[] { 0.15, 0.25, 0.2, 0.35, 0.05 } },
        { "mostly2n5v1", new[] { 0.05, 0.35, 0.15, 0.2, 0.25 } },
        { "mostly2n5v2", new[] { 0.05, 0.3, 0.15, 0.2, 0.3 } },
        { "mostly2n5v3", new[] { 0.05, 0.25, 0.15, 0.2, 0.35 } },
        { "mostly3", new[] { 0.025, 0.05, 0.75, 0.1, 0.075 } },
        { "mostly3n4v1", new[] { 0.05, 0.15, 0.35, 0.25, 0.2 } },
        { "mostly3n4v2", new[] { 0.05, 0.15, 0.3, 0.3, 0.2 } },
        { "mostly3n4v3", new[] { 0.05, 0.15, 0.25, 0.35, 0.2 } },
        { "mostly3n5v1", new[] { 0.05, 0.15, 0.35, 0.2, 0.25 } },
        { "mostly3n5v2", new[] { 0.05, 0.15, 0.3, 0.2, 0.3 } },
        { "mostly3n5v3", new[] { 0.05, 0.15, 0.25, 0.2, 0.35 } },
        { "mostly4", new[] { 0.025, 0.05, 0.075, 0.75, 0.1 } },
        { "mostly4n5v1", new[] { 0.05, 0.15, 0.2, 0.35, 0.25 } },
        { "mostly4n5v2", new[] { 0.05, 0.15, 0.2, 0.3, 0.3 } },
        { "mostly4n5v3", new[] { 0.05, 0.15, 0, 0.25, 0.35 } },
        { "mostly5", new[] { 0.025, 0.05, 0.075, 0.1, 0.75 } }
    };


    public static List<Question> Questions { get; } = new()
    {
        new Question("rencana kontrak kuliah", new List<string>
        {
            "menyampaikan materi sesuai dengan rencana pembelajaran",
            "membuat kontrak perkuliahan"
        }),
        new Question("kesempatan bertanya", new List<string>
        {
            "memberikan kesempatan bertanya baik di awal maupun di akhir sesi perkuliahan"
        }),
        new Question("feedback transparansi nilai", new List<string>
        {
            "memberikan nilai secara transparan",
            "memberikan pembahasan untuk beberapa pertanyaan yang sulit"
        }),
        new Question("kedisiplinan waktu", new List<string>
        {
            "tepat waktu saat masuk perkuliahan",
            "waktu perkuliahan tidak melebihi sesi yang ada"
        }),
        new Question("penguasaan materi", new List<string>
        {
            "melakukan review materi terlebih dahulu",
            "mencari referensi terkit materi yang diajarkan"
        }),
        new Question("penguasaan elearning", new List<string>
        {
            "menggunakan video conference untuk pertemuan daring",
            "menggunakan fitur forum untuk sesi diskusi",
            "memberikan tugas atau ujian dengan fitur quiz",
            "membagikan file materi dengan sharing file"
        })
    };
}