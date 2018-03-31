using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using ProtoBuf;
using snode.util;

namespace snode
{
  public class UdpServer
  {
    private int port;
    private UdpClient udpServer;
    private TcpClient tcpServer;
    private UdpMessageBroker messageBroker;

    public UdpServer(int port)
    {
      this.port = port;
      udpServer = new UdpClient(port);
      tcpServer = new TcpClient();
      messageBroker = new UdpMessageBroker();
    }
    public async Task Listen()
    {
      while (true)
      {
        Console.WriteLine("Listen 1");
        var remoteEP = new IPEndPoint(IPAddress.Any, port);
        Console.WriteLine("Listen 2");
        var data = await udpServer.ReceiveAsync();
        Console.WriteLine("Listen 3");
        messageBroker.RecievedMessage(data);
        Console.WriteLine("Listen 4");
      }
    }

    public void SendUdp(IPAddress iPAddress, Message message)
    {
      Console.WriteLine("SendUdp 1");
      var remoteEP = new IPEndPoint(iPAddress, port);
      MemoryStream ms = new System.IO.MemoryStream();
      Serializer.Serialize<Message>(ms, message);
      Console.WriteLine("SendUdp " + ms.Length);
      byte[] b = ms.ToArray();
      Console.WriteLine("SendUdp " + b.Length);
      udpServer.SendAsync(b, b.Length, remoteEP);
    }

    public void SendTcp(IPAddress iPAddress, IMessage message)
    {
      // var remoteEP = new IPEndPoint(iPAddress, port);
      // tcpServer.Client.Send(message.ToByteArray(), message.ToByteArray().Length, SocketFlags.None);
    }
  }
}