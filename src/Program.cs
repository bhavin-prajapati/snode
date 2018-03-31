using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using ProtoBuf;

namespace snode
{
  class Program
  {
    static void Main(string[] args)
    {
      int port = 3030;
      Console.WriteLine("Smart Node Starting...");
      UdpServer server = new UdpServer(port);
      Console.WriteLine("Server Initializing...");
      
      server.Listen();
      Console.WriteLine("Server Listening on port " + port + "...");

      // Stops program from stopping
      while(true) {
        string key = Console.ReadKey().ToString(); 

        var message = new Message {
            MessageType = MessageType.Discover,
            MessageData = "Blah"
        };
        server.SendUdp(IPAddress.Loopback, message);
      }
    }
  }
}
