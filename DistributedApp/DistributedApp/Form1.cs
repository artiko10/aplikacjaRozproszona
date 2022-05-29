using SuperSimpleTcp;
using System.Text;

namespace DistributedApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SimpleTcpClient client;
        private void Form1_Load(object sender, EventArgs e)
        {
            client = new(textBoxServer.Text);
            client.Events.DataReceived += Events_DataReceived;
            client.Events.Connected += Events_Connected;
            client.Events.Disconnected += Events_Disconnected;
            buttonSend.Enabled = false;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                client.Connect();
                buttonSend.Enabled = true;
                buttonConnect.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (client.IsConnected)
            {
                if (!string.IsNullOrEmpty(textBoxMessage.Text))
                {
                    client.Send(textBoxMessage.Text);
                    textBoxList.Text += $"Me: {textBoxMessage.Text}{Environment.NewLine}";
                    textBoxMessage.Text = string.Empty;
                }
            }
        }

        private void Events_DataReceived(object? sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                textBoxList.Text += $"S: {Encoding.UTF8.GetString(e.Data)}{Environment.NewLine}";
            });
        }

        private void Events_Connected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                textBoxList.Text += $"Server connected.{Environment.NewLine}";
            });
        }

        private void Events_Disconnected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                textBoxList.Text += $"Server disconnected.{Environment.NewLine}";
            });
        }

    }
}