using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SendToWebAPI.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SendToWebAPI
{
    class Program
    {
        private System.Timers.Timer _aTimer;

        static void Main(string[] args)
        {
            MyTimer timer = new MyTimer();
            Console.WriteLine("Press any key to start writing...");
            Console.ReadKey();
            timer.StartWriting();
            Console.WriteLine("Started writing...");
            Console.WriteLine("Press any key to stop..");
            Console.ReadKey();
        }
    }
}
