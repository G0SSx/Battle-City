using _Code.Data;

namespace _Code.Infrastructure.Services.Progress
{
    public class PersistentProgress : IPersistentProgress
    {
        public PlayerData Progress { get; }

        public PersistentProgress() => 
            Progress = new();
    }
}