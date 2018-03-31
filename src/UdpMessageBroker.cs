using System;
using System.IO;
using System.Net.Sockets;
using ProtoBuf;

namespace snode
{
    public class UdpMessageBroker
    {
        public void RecievedMessage(UdpReceiveResult udpResult) {
            Console.WriteLine("RecievedMessage 1");
            Console.WriteLine(udpResult.RemoteEndPoint.ToString());
            Console.WriteLine(udpResult.Buffer.Length.ToString());
            MemoryStream stream = new MemoryStream(udpResult.Buffer);
            Console.WriteLine("RecievedMessage 2");
            IMessage message = Serializer.Deserialize<Message>(stream);
            Console.WriteLine("RecievedMessage 3");
            Console.WriteLine(message.MessageData);
            Console.WriteLine("receive message " + message.MessageData);
        }

        public void SendMessage() {
            
        }
    }
}