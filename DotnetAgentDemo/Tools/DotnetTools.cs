using System.ComponentModel;
using System.Diagnostics;

namespace DotnetAgentDemo.Tools;

public sealed class DotnetTools
{
    [Description("Gets the installed .NET SDK version.")]
    public async Task<string> GetDotnetVersion()
    {
        Console.WriteLine("[TOOL] GetDotnetVersion");

        var process = Process.Start(new ProcessStartInfo
        {
            FileName = "dotnet",
            Arguments = "--version",
            RedirectStandardOutput = true,
            UseShellExecute = false
        });

        if (process is null)
            return "Não foi possível consultar o .NET.";

        var version = await process.StandardOutput.ReadToEndAsync();

        return version.Trim();
    }
}
