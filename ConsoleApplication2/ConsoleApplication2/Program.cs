﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snap7;


namespace ConsoleApplication2
{   

    class Program
    {
        static S7Client client = null;

        static void Main(string[] args)
        {
                 S7Client client = new S7Client();
                int res = client.ConnectTo("192.168.2.16", 0, 0);
         
                byte[] buffer = new byte[1];
                           
                res = client.WriteArea(S7Client.S7AreaPA, 0, 8, 1, S7Client.S7WLBit, buffer);
        }
    }
}
