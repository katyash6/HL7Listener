

namespace HL7Listener
{
  public interface IListener
  {
    void Config(string ip, int port);
    void Listen();
  }
}
