﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HL7Client
{
  class Program
  {

    static void Main(string[] args)
    {
      TcpClient client = new TcpClient("127.0.0.1", 9999);
      while (true)
      {
        string textToSend = @"MSH|^~\&|SENDING_APPLICATION|SENDING_FACILITY|RECEIVING_APPLICATION|RECEIVING_FACILITY|20110613061611||SIU^S12|24916560|
        P|2.3||||||SCH | 10345 ^ 10345 | 2196178 ^ 2196178 ||| 10345 | OFFICE ^ Office visit | reason for the appointment| OFFICE | 60 | m |^^ 60 ^ 20110617084500 ^ 20110617093000 ||||| 9 ^ DENT ^ ARTHUR ^|||| 9 ^ DENT ^ ARTHUR ^||||| Scheduled
                PID | 1 || 42 || BEEBLEBROX ^ ZAPHOD || 19781012 | M ||| 1 Heart of Gold ave ^^ Fort Wayne ^ IN ^ 46804 || (260)555 - 1234 ||| S || 999999999 |||||||||||||||||||||
                PV1 | 1 | O ||||| 1 ^ Adams ^ Douglas ^ A ^ MD ^^^^| 2 ^ Colfer ^ Eoin ^ D ^ MD ^^^^|||||||||||||||||||||||||||||||||||||||||| 99158 ||
                RGS | 1 | A
                AIG | 1 | A | 1 ^ Adams, Douglas | D ^^
                AIL | 1 | A | OFFICE ^^^ OFFICE |^ Main Office || 20110614084500 ||| 45 | m ^ Minutes || Scheduled
                AIP | 1 | A | 1 ^ Adams ^ Douglas ^ A ^ MD ^^^^| D ^ Adams, Douglas || 20110614084500 ||| 45 | m ^ Minutes || Scheduled";       
        NetworkStream stream = client.GetStream();
        byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);
        Console.WriteLine(textToSend);
        stream.Write(bytesToSend, 0, bytesToSend.Length);
        Thread.Sleep(6000);
      }
      client.Close();
    }
  }
}