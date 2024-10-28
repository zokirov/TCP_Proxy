using System.Net.Sockets;
using System.Net;
using System.Text;

namespace TCP_Proxy
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        TcpListener server;

        private void b_startserver_Click(object sender, EventArgs e)
        {
            int port = int.Parse(tb_port.Text);
            server = new TcpListener(IPAddress.Any, port); // Listen on any interface, port 8888
            server.Start();

            rb_log.AppendText("Server started on port " + port + "\n");

            Thread waitThread = new Thread(WaitClient);
            waitThread.Start(server);
        }

        public void WaitClient(object server)
        {
            while (true)
            {
                TcpClient client = ((TcpListener)server).AcceptTcpClient();  // Block and wait for a client

                IPEndPoint clientEndPoint = (IPEndPoint)client.Client.RemoteEndPoint;

                InvokeUI(() =>
                {
                    rb_log.AppendText("Client connected from:" + clientEndPoint.Address.ToString() + ".\n");
                    rb_log.AppendText("======================================================\n");
                });

                // Handle the client communication in a separate thread
                Thread clientThread = new Thread(HandleClient);
                clientThread.Start(client);
            }
        }

        public void InvokeUI(Action action)
        {
            Invoke(action);
        }

        public void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;
            NetworkStream stream = client.GetStream();

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

            client.Close();

            InvokeUI(() =>
            {
                rb_log.AppendText("Client disconnected.\n");
            });
        }

        TcpClient client;

        private void b_connect_Click(object sender, EventArgs e)
        {
            client = new TcpClient();

            string server = tb_server.Text;
            int port = int.Parse(tb_port.Text);

            try
            {
                client.Connect(server, port); // Connect to localhost on port 8888
                rb_log.AppendText("Connected to server.\n");

                NetworkStream stream = client.GetStream();
                string message = tb_message.Text;
                byte[] data = Encoding.ASCII.GetBytes(message);
                stream.Write(data, 0, data.Length);

                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    rb_log.AppendText("Server: " + response + "\n");
                    break;
                }
            }
            catch (Exception ex)
            {
                rb_log.AppendText("Error: " + ex.Message + "\n");
            }
            finally
            {
                client.Close();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (server != null)
                server.Stop();
        }

        private void b_send_Click(object sender, EventArgs e)
        {
            // Send the message to the client
            try
            {
                rb_log.AppendText("Send to server.\n");

                NetworkStream stream = client.GetStream();
                string message = tb_message.Text;
                byte[] data = Encoding.ASCII.GetBytes(message);
                stream.Write(data, 0, data.Length);

                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    rb_log.AppendText("Server: " + response + "\n");
                    break;
                }
            }
            catch (Exception ex)
            {
                rb_log.AppendText("Error: " + ex.Message + "\n");
            }
            finally
            {
                client.Close();
            }
        }
    }
}
