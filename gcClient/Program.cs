using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace gcClient
{
    class Program
    {
        static void Main(string[] args)
        {
            long serverIP = long.Parse(args[0]);
            int serverPort = int.Parse(args[1]);

            Console.WriteLine("This is the client app");
            TempSensor tempSensor = new TempSensor("1345",1000);
            tempSensor.start();

            IPEndPoint serverEP = new IPEndPoint(serverIP, serverPort);

            // Create a TCP/IP  socket.  
            Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Connect the socket to the remote endpoint. Catch any errors.  
            sender.Connect(serverEP);

            Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());

            // Encode the data string into a byte array.  
            byte[] msg = Encoding.ASCII.GetBytes("This is a test message<EOF>");

            // Send the data through the socket.  
            int bytesSent = sender.Send(msg);
            Console.WriteLine("Sent shit: {0}", bytesSent);

            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }
    }
}
