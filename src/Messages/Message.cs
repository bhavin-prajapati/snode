using ProtoBuf;

namespace snode
{
  [ProtoContract]
  public class Message : IMessage
  {
    [ProtoMember(1)]
    public MessageType MessageType { get; set; }
    
    [ProtoMember(2)]
    public string MessageData { get; set; }
  }
}