using System;

namespace _Code.Infrastructure.Services
{
    public interface IMatchResult
    {
        bool IsEnded { get; }
        Action OnMatchLose { get; }
        Action MatchWon { get; }
    }
}