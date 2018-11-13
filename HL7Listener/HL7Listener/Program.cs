using System;
using System.Net;


namespace HL7Listener
{

  class Program
  {
    const int PORT = 9999;
    const string IP = "127.0.0.1";
    const int NUMMSEC = 500;
    static void Main(string[] args)
    {
      var task = new BackgroundTask();
      task.PrintNum(NUMMSEC);
      ListenerFactory listenerFactory = new ListenerFactory();
      IListener listener = listenerFactory.getListener(ListenerType.HL7);
      listener.Config(IP, PORT);
      listener.Listen();
    }    
  }
}
