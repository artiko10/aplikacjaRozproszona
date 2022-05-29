using SuperSimpleTcp;
using System.Text;

namespace Serwer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SimpleTcpServer server;

        private void buttonStart_Click(object sender, EventArgs e)
        {
            server.Start();
            textBoxList.Text += $"Connecting...{Environment.NewLine}";
            buttonStart.Enabled = false;
            buttonSend.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buttonSend.Enabled = false;
            server = new SimpleTcpServer(textBoxServer.Text);
            server.Events.DataReceived += Events_DataReceived;
            server.Events.ClientDisconnected += Events_CLientDisconnected;
            server.Events.ClientConnected += Events_ClientConnected;
        }

        private void Events_ClientConnected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                textBoxList.Text += $"{e.IpPort} join.{Environment.NewLine}";
                listBoxClient.Items.Add(e.IpPort);
            });

        }

        private void Events_CLientDisconnected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                textBoxList.Text += $"{e.IpPort} disconnected.{Environment.NewLine}";
                listBoxClient.Items.Remove(e.IpPort);
            });
        }
            private void Events_DataReceived(object? sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                textBoxList.Text += $"{e.IpPort}: {Encoding.UTF8.GetString(e.Data)}{Environment.NewLine}";
            });
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (server.IsListening)
            {
                if (!string.IsNullOrEmpty(textBoxMessage.Text) && listBoxClient.SelectedItem != null)
                {
                    server.Send(listBoxClient.SelectedItem.ToString(), textBoxMessage.Text);
                    textBoxList.Text += $"Server: {textBoxMessage.Text}{Environment.NewLine}";
                    textBoxMessage.Text = string.Empty;
                }
            }
        }
    }
}