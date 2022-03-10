using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace UserDetailsGrpcService
{
    public class UserDetailsService : UserDetails.UserDetailsBase
    {
        private readonly ILogger<UserDetailsService> _logger;
        public UserDetailsService(ILogger<UserDetailsService> logger)
        {
            _logger = logger;
        }

        public override Task<ResponseHello> WelcomeUser(RequestMessage request, ServerCallContext context)
        {
            _logger.LogInformation("Welcoming user over grpc async channel ...");

            System.Threading.Thread.Sleep(500); // Intentional pause
            _logger.LogInformation("sending welcome message over grpc async channel ...");

            return Task.FromResult(new ResponseHello
            {
                HelloMessage = "Welcome " + request.UserName
            });
        }

        public override Task<ResponseUserDetails> GetUserDetails(RequestMessage request, ServerCallContext context)
        {
            _logger.LogInformation("Retrieving user details over grpc async channel ...");

            ResponseUserDetails userDetails = new ResponseUserDetails
            {
                FirstName = "Nilesh",
                LastName = "Shah",
                Address = "Pune",
                Phone = "1111"
            };

            System.Threading.Thread.Sleep(500); // Intentional pause
            _logger.LogInformation("sending user details over grpc async channel ...");

            return Task.FromResult(userDetails);
        }
    }
}
