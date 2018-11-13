using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7Listener
{
  public enum ListenerType
  {
    HL7
  }
  public class ListenerFactory
  {
    public IListener getListener(ListenerType type)
    {
      switch (type)
      {
        case ListenerType.HL7:
          return new HL7Listener();

        default:
          throw new Exception("No such listener Type");
      }
    }

  }
}
