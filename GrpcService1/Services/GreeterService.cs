using Grpc.Core;
using GrpcGreeter;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GrpcService1
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            var currentDate = DateTime.Now;
            var birthDate = request.BirthDate.ToDateTime();
            var daysOnEarth = (currentDate - birthDate).Days;
            var message = $"Hello {request.FirstName} {request.LastName}, you are {daysOnEarth} days on Earth.";

            _logger.LogInformation(message);

            return Task.FromResult(new HelloReply
            {
                Message = message
            }); ;
        }
    }
}
