using DotnetAgentDemo.Agents;
using DotnetAgentDemo.Tools;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using OpenAI;

var configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var apiKey = configuration["AI:ApiKey"]
    ?? throw new Exception("API Key não configurada.");

var chatClient = new OpenAIClient(apiKey)
    .GetChatClient("gpt-4o-mini")
    .AsIChatClient();

var agent = DeveloperAgent.Create(
    chatClient,
    new DotnetTools());

Console.Write("Digite sua pergunta: ");
var question = Console.ReadLine();

if (string.IsNullOrWhiteSpace(question))
{
    Console.WriteLine("Nenhuma pergunta foi informada.");
    return;
}

var response = await agent.RunAsync(question);

Console.WriteLine(response.Text);