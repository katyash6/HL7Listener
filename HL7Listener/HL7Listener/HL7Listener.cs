using System;
using System.Net.Sockets;
using System.Text;
using System.Net;

namespace HL7Listener
{

  public class HL7Listener : IListener
  {
    private IPAddress _ip;
    private int _port;

    public void Config(string ip, int port)
    {
      _ip = IPAddress.Parse(ip);
      _port = port;
    }

    public void Listen()
    { 
      TcpListener listener = new TcpListener(_ip, _port);
      listener.Start();
      try
      {
        while (true)
        {
          TcpClient client = listener.AcceptTcpClient();
          while (true)
          {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[client.ReceiveBufferSize];
            int bytesRead = stream.Read(buffer, 0, client.ReceiveBufferSize);
            string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            //start = dataReceived.IndexOf((char)0x0b);
            //end = dataReceived.IndexOf((char)0x1c);
            Console.WriteLine(dataReceived);
          }
          client.Close();
        }
        listener.Stop();
        Console.ReadLine();
      }
      catch (Exception e)
      {
        Console.WriteLine("Exception catched: " + e.StackTrace);
      }
    }
  }
}
