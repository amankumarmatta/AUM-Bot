using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

class Program
{
    private DiscordSocketClient _client;

    public static async Task Main(string[] args) => await new Program().RunBotAsync();

    public async Task RunBotAsync()
    {
        _client = new DiscordSocketClient();

        // Subscribe to events
        _client.Log += Log;

        // Replace "Your-Bot-Token" with your actual bot token
        string botToken = "MTMwODAyNTA0NDM3MDQ1NjYyNg.GEmeUn.hlL_LLVrL9fNy9A6b9lgg8Bg_qO8QhBM10tJOo";

        // Login and start the bot
        await _client.LoginAsync(TokenType.Bot, botToken);
        await _client.StartAsync();

        // Hook to handle messages
        _client.MessageReceived += HandleMessageAsync;

        // Keep the bot running
        await Task.Delay(-1);
    }

    private Task Log(LogMessage log)
    {
        Console.WriteLine(log.ToString());
        return Task.CompletedTask;
    }

    private async Task HandleMessageAsync(SocketMessage message)
    {
        // Ignore system messages and messages from the bot itself
        if (message.Author.IsBot) return;

        if (message.Content == "!ping")
        {
            await message.Channel.SendMessageAsync("Pong!");
        }
    }
}
