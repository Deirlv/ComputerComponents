using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.Json;
using ComponentLibrary;
using System.Diagnostics;

namespace ComputerComponentsClient
{
    public partial class Form1 : Form
    {
        int remotePort;

        IPAddress IPAddress;

        public Form1()
        {
            //IPAddress = IPAddress.Parse("192.168.178.34");
            IPAddress = IPAddress.Parse("192.168.178.34");
            remotePort = 11000;
            InitializeComponent();
            Process.Start("ComputerComponentsServer.exe");
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            UdpClient client = new UdpClient();

            try
            {
                
                byte[] buff = Encoding.Default.GetBytes(textBoxComponent.Text);
                IPEndPoint remoteEP = new IPEndPoint(IPAddress, remotePort);

                client.Send(buff, buff.Length, remoteEP);

                byte[] received = client.Receive(ref remoteEP);

                string dataResponse = Encoding.Default.GetString(received, 0, received.Length);

                List<Component>? components = JsonSerializer.Deserialize<List<Component>>(dataResponse);

                if (components == null)
                {
                    throw new Exception("Nothing was found");
                }
                else
                {
                    gridComponents.DataSource = null;
                    gridComponents.DataSource = components;
                }

                textBoxComponent.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
            finally
            {
                client.Close();
            }
        }
    }
}
