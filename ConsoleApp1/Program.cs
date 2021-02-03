using Grpc.Net.Client;
using System;
using System.Threading.Tasks;
using GrpcGreeter;
using Google.Protobuf.WellKnownTypes;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);

            var reply = await client.SayHelloAsync(new HelloRequest
            {
                FirstName = "Robert",
                LastName = "Vejvoda",
                BirthDate = Timestamp.FromDateTime(new DateTime(1975, 5, 18).ToUniversalTime())
            });
            Console.WriteLine("Message: " + reply.Message);

            Console.WriteLine("Shutting down");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
