using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

TcpListener server = null;
TcpClient clientOut = null;
Random rnd = new Random();
string[] randomId = {
"078EB2331457E8",
"887048B3B8197E",
"A3DAEC542505E8",
"EC13B557B097F7",
"8E87F2BB495740",
"B6AB66DE479B3F",
"BC15B6B4E9E7EA",
"7E505528E55299",
"373419853C8592",
"4DCB69521253A2",
"A770DD5D246454",
"AF1069ECCA0FCC",
"A725E417F17E88",
"17A3F264631074",
"6B57587B804120",
"1E30B7F2D94E15",
"EDD3856AB4E040",
"5180BD24C1C3CB",
"EF9760B65D73BD",
"187F84DEC9D2AE",
"EA0D8B27BD1BDF",
"CB1AF5CFC7133E",
"7415361704088E",
"399D4C70374494",
"53146FCFF2EFC7",
"858356E1ABA80A",
"D8A0B7EDAB6725",
"E3A7A5F8CBC0A2",
"7BFBD111411AA8",
"BFADA863D86E5B",
"DE369622BE41CA",
"9C69127005EECE",
"B951B7DBE87FD3",
"A265002E1D5DC7",
"5C2B9DB7E354FF",
"D08F291768014C",
"36A808A41805CB",
"0A18448A727CED",
"C9AE45CFDFAF9B",
"C54A249A2816A4",
"EA21541C017F43",
"6158BEFC5D5A27",
"09E57E095F8014",
"4E5B0C683A11FE",
"25DC44CCD97183",
"15CFDCAE40F6CA",
"0CA8C5CDB30C21",
"D0AFFB5B5EC079",
"3C29596DF64247",
"49394C83873045"
};

try
{
    // Set the TcpListener on port xxxx.
    Int32 portPc = 10001;
    IPAddress localAddr = IPAddress.Parse("192.168.1.145");
    // TcpListener server = new TcpListener(port);
    server = new TcpListener(localAddr, portPc);
    // Start listening for client requests.
    server.Start();


    //TcpClient client = new TcpClient(server, port);
    Int32 portReader = 8890;
    IPAddress readerAddr = IPAddress.Parse("192.168.1.101");
    clientOut = new TcpClient(readerAddr.ToString(), portReader);


    // Buffer for reading data
    Byte[] bytes = new Byte[256];
    String dataReceive = null;

    // Enter the listening loop.

    while (true)
    {
        Console.Write("Waiting for a connection... ");

        // Perform a blocking call to accept requests.
        // You could also use server.AcceptSocket() here.
        TcpClient clientIn = server.AcceptTcpClient();
        Console.WriteLine("Connected!");

        Console.WriteLine("\nHit enter to send new random ID...");
        Console.ReadLine();
        dataReceive = null;
        int index = rnd.Next(randomId.Length);
        // Translate the passed message into ASCII and store it as a Byte array.
        Byte[] data_send = System.Text.Encoding.ASCII.GetBytes(randomId[index]);

        // Get a stream object for reading and writing
        NetworkStream streamIn = clientIn.GetStream();
        NetworkStream streamOut = clientOut.GetStream();

        int i;
        // Loop to receive all the data sent by the client.
        while ((i = streamIn.Read(bytes, 0, bytes.Length)) != 0)
        {
            // Translate data bytes to a ASCII string.
            dataReceive = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
            Console.WriteLine("Received: {0}", dataReceive);

            // Send back a response.
            streamOut.Write(data_send, 0, data_send.Length);
            Console.WriteLine("Sent: {0}", System.Text.Encoding.Default.GetString(data_send));

        }

        // Shutdown and end connection
        clientIn.Close();
        streamIn.Close();
    }
   
}
catch (SocketException e)
{
    Console.WriteLine("SocketException: {0}", e);
}
finally
{
    //
}

Console.WriteLine("\nClose applikation.");
Console.Read();
