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
            textBoxList.Text += $"Starting the server...{Environment.NewLine}";
            buttonStart.Enabled = false;
            buttonSend.Enabled = true;
            buttonStop.Enabled = true;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            server = new SimpleTcpServer(textBoxServer.Text);
            server.Events.DataReceived += Events_DataReceived;
            server.Events.ClientDisconnected += Events_CLientDisconnected;
            server.Events.ClientConnected += Events_ClientConnected;
            buttonSend.Enabled = false;
            buttonStop.Enabled = false;

        }

        private void Events_ClientConnected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                listBoxClient.Items.Add(e.IpPort);
                textBoxList.Text += $"{e.IpPort} join.{Environment.NewLine}";
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
               
            if (listBoxClient.SelectedItem != null)
                {
                    server.Send(listBoxClient.SelectedItem.ToString(), textBoxMessage.Text);
                    textBoxList.Text += $"Server: {textBoxMessage.Text}{Environment.NewLine}";
                    textBoxMessage.Text = string.Empty;
                }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            server.Stop();
            textBoxList.Text += $"Server won't let new connections...{Environment.NewLine}";
            buttonStart.Enabled = true;
            buttonSend.Enabled = true;
            buttonStop.Enabled = false;
        }
    }
}