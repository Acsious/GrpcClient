using Grpc.Net.Client;
using GrpcServer;

namespace GrpcClient;
class Program
{
    static async Task Main(string[] args)
    {
        using var channel = GrpcChannel.ForAddress("http://localhost:5000");
        var client = new Logger.LoggerClient(channel);

        var reply = await client.GetRTAInfoAsync(new InfoRequest() { Info = "Перекресток улиц Кирова и Свердлова. " });
        Console.WriteLine("Дорожное проишествие: " + reply.Defenition);
        Console.ReadKey();
    }
}