﻿using System;
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
"RSM2HOTS292TPD",
"PPOV3DBSI2VMJZ",
"V3VH13A5FZP3WZ",
"OHPLRAJRZZ8YEY",
"46FVIC6MQJC0UT",
"Y6LORWICNWR2OZ",
"SNM6MPYPEP34YH",
"WD6L96JK1CATIF",
"IXGUVDNWZ3CKWK",
"84QL8O62NPABO6",
"UTNUREF6HWNLQF",
"PUWBSY3TM1BO62",
"EK8L8V5IQP8GOA",
"KD9ER6QEEOGGVJ",
"04JW81P19WU73P",
"BG6UHN0A5MDRA4",
"8PFRJ85ALFWF16",
"QBVZDIZ7AN3I1U",
"ENQJZQM55ECW9W",
"E8YHEDR172N3HB",
"7N4LXVXJ3FNG7H",
"GQ7Z7NIFS24X5S",
"T2RTEX7W5VB78A",
"LP3ZDA9SD739QR",
"WCHD6OPPM3FVQW",
"DTR8UCS9SWWE9D",
"22TA4M4JBF9B0Q",
"8U8IG1KDY3BOYM",
"JVQVUSF59KOPF6",
"1DL2K0LJ02XB9K",
"G0TE52FG3RO9HQ",
"4TMUY8NBEBI3JP",
"HVZQPSQ9A6259F",
"LY9D2G5XE48KX9",
"HN8CZGGLULXJMY",
"O829CQVXZNCEKU",
"JCBGBL49Q8EVSC",
"YRJ0DLGR6HIJDL",
"TV0EE85BEF0E7Y",
"B6JGJRS3WFJL92",
"STIRAERZO5ZQ0M",
"Z390WVMCPZUINQ",
"00MW72N715MX7S",
"BLX9OCLQ4FTJ09",
"7C1868SO557HDE"
};

try
{
    //TcpClient client = new TcpClient(server, port);
    Int32 portReader = 8890;
    IPAddress readerAddr = IPAddress.Parse("192.168.178.101");
    clientOut = new TcpClient(readerAddr.ToString(), portReader);

    // Buffer for reading data
    Byte[] bytes = new Byte[256];
    // Get a stream object for reading and writing
    NetworkStream streamOut = clientOut.GetStream();
    // Enter the listening loop.
    while (true)
    {
        Console.WriteLine("\nHit enter to send new random ID...");
        Console.ReadLine();
        // Select random ID
        int index = rnd.Next(randomId.Length);
        // Translate the passed message into ASCII and store it as a Byte array.
        Byte[] data_send = System.Text.Encoding.ASCII.GetBytes(randomId[index]);

        // Send back a response.
        streamOut.Write(data_send, 0, data_send.Length);

        Console.WriteLine("Sent: {0}", System.Text.Encoding.Default.GetString(data_send));

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

Console.WriteLine("\nYou reached the end...");
Console.Read();
