using ProtoBuf;

namespace snode
{
  [ProtoContract]
  class Discover {
      [ProtoMember(1)]
      public int Id {get;set;}
      [ProtoMember(2)]
      public string Name {get;set;}
  }
}