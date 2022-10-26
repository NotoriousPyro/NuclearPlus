using System;
using System.Reflection;

internal static class Core
{
    internal static string Name => Assembly.GetCallingAssembly().GetName().Name;
    internal static string Version => Assembly.GetCallingAssembly().GetName().Version.ToString();
    internal static int VersionInt => int.Parse(Version.Replace(".", ""));
    internal static void LogWithVersion(Action<string> logger, string message) => logger($"{Core.Name}[{Core.Version}]: {message}");
}
