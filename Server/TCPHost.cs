using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TCP_Proxy;

public partial class MainForm : Form
{

    TcpListener server;
    TcpClient client;
    string hostname;

    public void StartServer(int port)
    {
        server = new TcpListener(IPAddress.Any, port); // Listen on any interface, port 8888
        server.Start();

        InvokeUI(() =>
        {
            rb_log.AppendText("Server started on port " + port + "\n");
        });        

        while (true)
        {
            client = ((TcpListener)server).AcceptTcpClient();  // Block and wait for a client

            IPEndPoint clientEndPoint = (IPEndPoint)client.Client.RemoteEndPoint;

            InvokeUI(() =>
            {
                rb_log.AppendText("Client connected from:" + clientEndPoint.Address.ToString() + ".\n");                
            });

            // Handle the client communication in a separate thread
            Thread clientThread = new(() => HandleClient(client));
            clientThread.Start();
        }
    }


    public void HandleClient(object obj)
    {
        TcpClient clientServer = (TcpClient)obj;
        NetworkStream stream = clientServer.GetStream();

        byte[] buffer = new byte[1024];
        int bytesRead;

        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
        {
            string data = Encoding.ASCII.GetString(buffer, 0, bytesRead);

            InvokeUI(() =>
            {
                rb_log.AppendText("Received: " + data + "\n");
            });

            byte[] responseData = Encoding.ASCII.GetBytes("Echo: " + data);
            stream.Write(responseData, 0, responseData.Length);
        }
    }

    public void SendMessage(string from, TcpClient sender, string message)
    {
        TcpClient newClient = sender;
        try
        {
            NetworkStream stream = newClient.GetStream();

            byte[] data = Encoding.ASCII.GetBytes(message);
            stream.Write(data, 0, data.Length);

            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                rb_terminal.AppendText($"{from}: {response}\n");
                break;
            }
        }
        catch (Exception ex)
        {
            rb_log.AppendText("Error: " + ex.Message + "\n");
        }
    }

    public void Connect(string server, int port)
    {
        client = new TcpClient();

        try
        {
            client.Connect(server, port); // Connect to localhost on port 8888
            rb_log.AppendText("Connected to server.\n");

            NetworkStream stream = client.GetStream();
            string message = tb_message.Text;
            byte[] data = Encoding.ASCII.GetBytes(message);
            stream.Write(data, 0, data.Length);            

            Thread receiveThread = new Thread(() => ReceiveMessages(stream));
            receiveThread.Start();
            
        }
        catch (Exception ex)
        {
            rb_log.AppendText("Error: " + ex.Message + "\n");
        }
    }

    private void ReceiveMessages(NetworkStream stream)
    {
        byte[] buffer = new byte[1024];
        //int bytesRead;

        //while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
        //{
        //    string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
        //    rb_log.AppendText("Server: " + response + "\n");
        //    break;
        //}

        try
        {
            while (stream.CanRead)
            {
                int bytesRead = stream.Read(buffer, 0, buffer.Length);

                if (bytesRead == 0)
                {
                    // The server has closed the connection
                    InvokeUI(() =>
                    {
                        rb_log.AppendText("Server has closed the connection.\n");
                    });
                    break;
                }

                string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                InvokeUI(() =>
                {
                    rb_log.AppendText($"Received: {response}");
                });
            }
        }
        catch (Exception ex)
        {
            InvokeUI(() =>
            {
                rb_log.AppendText($"Receive error: {ex.Message}");
            });
        }
    }
}
