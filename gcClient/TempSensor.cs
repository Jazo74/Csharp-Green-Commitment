using System;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace gcClient
{
    public class TempSensor
    {
        Random rnd = new Random();
        private string name;
        private int timing;
        public TempSensor(string name, int timing)
        {
            this.name = name;
            this.timing = timing;
        }
        public void start()
        {
            while (true)
            {
                long since = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                float temp = 20 + rnd.Next(101) / (float)10;
                Console.WriteLine(name + ":" + since + ":" + temp.ToString());
                Thread.Sleep(timing);
            }
        }
    }
}
