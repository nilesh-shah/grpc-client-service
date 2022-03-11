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

            while (true)
            {
                Console.WriteLine("Provide your user name to get basic handshake");
                string userName = Console.ReadLine();

                try
                {
                    var welcomeMessage = client.WelcomeUserAsync(new RequestMessage()
                    {
                        UserName = userName
                    });

                    Console.WriteLine(welcomeMessage.ResponseAsync.Result.HelloMessage);

                    Console.WriteLine("Press ENTER to get your details ...");
                    Console.ReadLine();

                    var replyMessage = client.GetUserDetailsAsync(new RequestMessage()
                    {
                        UserName = userName
                    });

                    var response = replyMessage.ResponseAsync.Result;

                    if (!string.IsNullOrWhiteSpace(response.FirstName))
                    {
                        Console.WriteLine("Your First Name is: " + replyMessage.ResponseAsync.Result.FirstName);
                        Console.WriteLine("Your Last Name is: " + replyMessage.ResponseAsync.Result.LastName);
                        Console.WriteLine("Your Address is: " + replyMessage.ResponseAsync.Result.Address);
                        Console.WriteLine("Your Phone is: " + replyMessage.ResponseAsync.Result.Phone);
                    }
                    else
                        Console.WriteLine("User not found ...");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occured" + ex.Message);
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                    break;
                }

                Console.WriteLine("Press any key to continue... OR press CTRC + C to exit");
                Console.ReadKey();
            }
        }
    }
}