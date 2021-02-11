using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SmartHouse.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private TcpClient client;
        private int byteCount = 0;
        private byte[] sendData;
        private NetworkStream stream;

        private string ipServer;
        private string port;
        private string data;
        private string isConnected;

        public string IsConnected
        {
            get { return isConnected; }
            set { isConnected = value; OnPropertyChanged(); }
        }
        public string Data
        {
            get { return data; }
            set
            {
                data = value;
                OnPropertyChanged();
            }
        }
        public string Port
        {
            get { return port; }
            set
            {
                port = value; OnPropertyChanged();
            }
        }
        public string IPServer
        {
            get { return ipServer; }
            set
            {
                ipServer = value;
                OnPropertyChanged();
            }
        }

        public ICommand Connect { get; set; }
        public ICommand Send { get; set; }


        public AboutViewModel()
        {
            Title = "Test Area";

            Connect = new Command(() => ServerConnect());
            Send = new Command(() => SendCommand());

        }

        private void SendCommand()
        {
            if (Data.Length > 0)
            {
                byteCount = Encoding.ASCII.GetByteCount(Data);
                sendData = new byte[byteCount];
                sendData = Encoding.ASCII.GetBytes(Data);
                stream.Write(sendData, 0, sendData.Length);
            }

        }

        private void ServerConnect()
        {
            if (ipServer.Length > 8)
            {
                client = new TcpClient(IPServer, Convert.ToInt32(Port));
                stream = client.GetStream();
                IsConnected = "Connected";
            }
        }
    }
}