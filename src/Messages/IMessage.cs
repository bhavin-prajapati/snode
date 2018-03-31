
using snode;

public interface IMessage
{
  MessageType MessageType
  {
    get;
    set;
  }

  string MessageData
  {
    get;
    set;
  }
}
