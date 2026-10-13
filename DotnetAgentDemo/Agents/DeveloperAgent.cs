using DotnetAgentDemo.Tools;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

namespace DotnetAgentDemo.Agents;

public static class DeveloperAgent
{
    public static AIAgent Create(
        IChatClient chatClient,
        DotnetTools tools)
    {
        return chatClient.AsAIAgent(
            name: "DeveloperAgent",
            instructions: "Você é um desenvolvedor .NET.",
            tools:
            [
                AIFunctionFactory.Create(tools.GetDotnetVersion)
            ]);
    }
}