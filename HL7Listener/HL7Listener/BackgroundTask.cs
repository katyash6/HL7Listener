using System;
using System.Threading;
using System.Threading.Tasks;

namespace HL7Listener
{
  public class BackgroundTask
  {
  
    /// <summary>
    /// Prints a running number every x ms
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public async Task PrintNum(int x)
    {
      await Task.Run(() =>
      {
        int i = 1;
        while (true)
        {
          Console.WriteLine(@"{0}", i++);
          Thread.Sleep(x);
        }
      });
    }

    
  }
}
