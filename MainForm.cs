using System.Net.Sockets;
using System.Net;
using System.Text;

namespace TCP_Proxy;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void startServer(object sender, EventArgs e)
    {
        hostname = "server";
        var port = int.Parse(tb_port.Text);

        Thread serverThread = new(() => StartServer(port));
        serverThread.Start();
    }

    private void connect(object sender, EventArgs e)
    {
        hostname = "client";
        string server = tb_server.Text;
        int port = int.Parse(tb_port.Text);
        Connect(server, port);
    }

    private void sendMessage(object sender, EventArgs e)
    {
        // Send the message to the client
        SendMessage(hostname, client, tb_message.Text);
    }

    private void formClosing(object sender, FormClosingEventArgs e)
    {
        if (server != null)
            server.Stop();
    }


    public void InvokeUI(Action action)
    {
        Invoke(action);
    }
}
