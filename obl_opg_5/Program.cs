using System.Net.Sockets;
using System.Net;
using obl_opg_5;

Console.WriteLine("TCP Server:");

int port = 8;
TcpListener listener = new TcpListener(IPAddress.Any, port);
listener.Start();

while (true)
{
    TcpClient client = listener.AcceptTcpClient();
    //Console.WriteLine(client.Client.RemoteEndPoint);
    Task.Run(() => ClientHandler.HandleClient(client));

}

listener.Stop();