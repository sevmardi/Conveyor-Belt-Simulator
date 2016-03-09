using System;
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

        static bool Check(int res, string function)
        {
            if (res != 0)
            {
                if (res < 0)
                    Console.WriteLine(function + " - Snap7 Library Error");
                else
                    Console.WriteLine(function + " - " + client.ErrorText(res));
            }
            return res == 0;
        }


        static void Main(string[] args)
        {
            S7Client client = new S7Client();
            int res = client.ConnectTo(args[0], 0, 1);
            int error = client.ConnectTo("192.168.0.10", 0, 2);
            if(Check(res,"Connect to"))
            {
                byte[] buffer = new byte[30];
                byte[] E = new byte[200];
                int size = 10;
                S7Client.S7DataItem[] items = new S7Client.S7DataItem[2];

             

               // res = client.MBRead(1, 4, buffer);
                //res = client.DBGet(1, buffer, ref size);
                res = client.ReadArea(8, 18, 0, S7Client.S7WLBit, buffer);
                Check(res, "MBRead");
                //  https://sourceforge.net/p/snap7/discussion/general/thread/6e232d36/
              //  https://sourceforge.net/p/snap7/discussion/general/thread/e958097d/?limit=25
            }
        }
    }
}
