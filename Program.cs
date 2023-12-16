using Grpc.Net.Client;
using GrpcServer;
using System.Text;

namespace GrpcClient;
class Program
{
    static async Task Main(string[] args)
    {
        using var channel = GrpcChannel.ForAddress("http://localhost:5000");
        var client = new Logger.LoggerClient(channel);

        var reply = await client.GetRTAInfoAsync(new InfoRequest() { Info = "Перекресток улиц Кирова и Свердлова. " });

            using FileStream fstream = new("Output.txt", FileMode.OpenOrCreate);
            // преобразуем строку в байты
            byte[] buffer = Encoding.Default.GetBytes("Дорожное проишествие: " + reply.Defenition);
            // запись массива байтов в файл
            await fstream.WriteAsync(buffer);
            Console.WriteLine("Текст записан в файл");
        
        Console.ReadKey();
    }
}