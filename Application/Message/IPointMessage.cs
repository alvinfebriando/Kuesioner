using Kuesioner.Domain.Entities;

namespace Kuesioner.Application.Message;

public interface IPointMessage
{
    public string Lecturer { get; set; }
    public Answer Answer { get; set; }
}