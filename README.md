# grpc-client-service
grpc client service application

# Introduction

This is very basic GRPC client server application developed using ASP.NET 5.0 and compatible GRPC compilers and tools. It implements basic user details service. The client handshakes with server using username and server responds with welcome message and user details. The communication happens over https using GRPC async channels

# Getting Started

This section will guide users through getting your code up and running on their own system.

**I. Running server and client **

# I. Running server and client

1. **Clone** **grpc-client-server** **Git** **Repo -** [*https://github.com/nilesh-shah/grpc-client-service**](https://github.com/nilesh-shah/grpc-client-service)\*\* \*\*
2. Ensure that **.NET 5.0** is installed on the machine (It is framework dependency as of now) 
3. Once cloned, open GrpcClientService.sln file in VS 2019. VS 2019 is not hard dependency but it is easy to compile and run the application
4. If you are opening in VS 2019, compile the solution. The build should succeed
5. Once successfully built, right click server project and say Debug -> Start new Instance
6. right click client project and say Debug -> Start new Instance
7. Once both are running, provide username on client console and follow instructions.
8. You can see logs are generated on server console to give information about GRPC calls execution

# Important inpunts

1. **nilesh**, **grpcclient**, **grpcserver** and **propeller** are valid users
2. Database is in memory (of server)
3. Sonar Analyzers are used in each client and server projects as code review tool
4. Client and Server uses appropriate GRPC and protobuf compilers