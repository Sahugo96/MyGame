using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace Game.Shared
{
    /// <summary>Single logging entry point with module tags.</summary>
    public static class Log
    {
        public static void Info(string tag, string message) => Debug.Log($"[{tag}] {message}");

        public static void Warn(string tag, string message) => Debug.LogWarning($"[{tag}] {message}");

        public static void Error(string tag, string message) => Debug.LogError($"[{tag}] {message}");

        // Stripped from builds without VERBOSE_LOG: zero cost in production.
        [Conditional("UNITY_EDITOR"), Conditional("VERBOSE_LOG")]
        public static void Verbose(string tag, string message) => Debug.Log($"[{tag}] {message}");
    }
}