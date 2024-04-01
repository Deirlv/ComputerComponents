using ComponentLibrary;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace ComputerComponentsServer
{
    public partial class Form1 : Form
    {
        int remotePort;

        IPAddress IPAddress;

        Task? receiver;

        public Form1()
        {
            IPAddress = IPAddress.Parse("192.168.178.34");
            remotePort = 11000;
            InitializeComponent();
        }

        private async void buttonStart_Click(object sender, EventArgs e)
        {
            if (receiver != null) { return; }

            receiver = Task.Run(async () =>
            {
                UdpClient listener = new UdpClient(new IPEndPoint(IPAddress, remotePort));               
                try
                {
                   while(true) 
                    {
                        UdpReceiveResult resultReceive = await listener.ReceiveAsync();

                        byte[] buff = resultReceive.Buffer;
                        string received = Encoding.Default.GetString(buff);

                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.AppendLine($"{buff.Length} received from {resultReceive.RemoteEndPoint}");
                        stringBuilder.AppendLine($"Component: {received}");

                        

                        List<Component>? components = new List<Component>();
                        string? jsonData = null;

                        using (StreamReader reader = new StreamReader("components.json", Encoding.Default))
                        {
                            jsonData = await reader.ReadToEndAsync();
                        }

                        stringBuilder.AppendLine($"Json : \n{jsonData}");

                        if (jsonData != null)
                        {
                            components = JsonSerializer.Deserialize<List<Component>>(jsonData);
                        }

                        if (components != null)
                        {
                            List<Component>? foundComponents = components.Where(c => c.Manufacturer == received).ToList();

                            string jsonSend = JsonSerializer.Serialize<List<Component>>(foundComponents);

                            byte[] bufferResponse = Encoding.Default.GetBytes(jsonSend);

                            if (foundComponents.Count == 0)
                            {
                                stringBuilder.AppendLine("The component was NOT found");
                            }

                            //IPEndPoint remoteEP = new IPEndPoint(IPAddress, remotePort);
                            await listener.SendAsync(bufferResponse, bufferResponse.Length, resultReceive.RemoteEndPoint);

                            stringBuilder.AppendLine($"{bufferResponse.Length} bytes send to: {resultReceive.RemoteEndPoint}");
                        }

                        textBoxLog.BeginInvoke(new Action<string>(AddText), stringBuilder.ToString());
                    };
                }
                catch (SystemException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                finally
                {
                    listener.Close();
                }

            });
            Text = "Server is working...";
        }

        private void AddText(string str)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(str);

            textBoxLog.Text = stringBuilder.ToString();
        }
    }
}
