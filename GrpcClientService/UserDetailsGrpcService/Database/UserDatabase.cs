using System.Collections.Generic;

namespace UserDetailsGrpcService.Database
{
    public static class UserDatabase
    {
        private static Dictionary<string, UserDetails> userDatabase = new();

        public static UserDetails GetUserDetails(string userName)
        {
            if (userDatabase.ContainsKey(userName))
            {
                return userDatabase[userName];
            }

            return null;
        }

        public static void SeedUsers()
        {
            if (userDatabase == null)
                userDatabase = new Dictionary<string, UserDetails>();

            userDatabase.Add("nilesh", new UserDetails()
            {
                UserName = "nilesh",
                FirstName = "Nilesh",
                LastName = "Shah",
                Address = "Pune",
                Phone = "Dummy Phone",
                Active = true
            });

            userDatabase.Add("grpcclient", new UserDetails()
            {
                UserName = "grpcclient",
                FirstName = "GRPC",
                LastName = "Client Application",
                Address = "GitHub",
                Phone = "client 123",
                Active = true
            });

            userDatabase.Add("grpcserver", new UserDetails()
            {
                UserName = "grpcserver",
                FirstName = "GRPC",
                LastName = "Server Application",
                Address = "GitHub",
                Phone = "Server 123",
                Active = true
            });

            userDatabase.Add("propeller", new UserDetails()
            {
                UserName = "propeller",
                FirstName = "Propeller",
                LastName = "Propeller",
                Address = "MS Teams",
                Phone = "Propeller 123",
                Active = true
            });
        }
    }
}
