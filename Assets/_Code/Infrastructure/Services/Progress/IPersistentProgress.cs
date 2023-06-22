using _Code.Data;

namespace _Code.Infrastructure.Services.Progress
{
    public interface IPersistentProgress
    {
        PlayerData Progress { get; }
    }
}