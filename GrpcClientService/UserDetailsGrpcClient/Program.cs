using System;
using UserDetailsGrpcClient;
using Grpc.Net.Client;

namespace UserDetailsGrpc
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("GRPC Client is starting up ....");

            using var channel = GrpcChannel.ForAddress("https://localhost:7042");
            var client = new UserDetails.UserDetailsClient(channel);

            Console.WriteLine("Provide user name to get the details");
            string userName = Console.ReadLine();

            var welcomeMessage = client.WelcomeUserAsync(new RequestMessage()
            {
                UserName = userName
            });

            Console.WriteLine(welcomeMessage.ResponseAsync.Result.HelloMessage);

            Console.WriteLine("Press ENTER to get user details ...");
            Console.ReadLine();

            var replyMessage = client.GetUserDetailsAsync(new RequestMessage()
            {
                UserName = userName
            });
            
            Console.WriteLine("Your Address is: " + replyMessage.ResponseAsync.Result.Address);
            Console.WriteLine("Your Phone is: " + replyMessage.ResponseAsync.Result.Phone);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}