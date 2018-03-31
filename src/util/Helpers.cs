using System.IO;

namespace snode.util
{
  public class Helpers
  {
    public static byte[] ReadFully(Stream input)
    {
      using (MemoryStream ms = new MemoryStream())
      {
        input.CopyTo(ms);
        return ms.ToArray();
      }
    }
  }
}