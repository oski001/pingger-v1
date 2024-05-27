using System;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;

namespace pinnnger
{
    public partial class pingger : Form
    {
        public pingger()
        {
            InitializeComponent();
            button1.Click += new EventHandler(button1_Click); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ipAddress = textBox1.Text;
            if (!string.IsNullOrEmpty(ipAddress))
            {
                string result = PingIp(ipAddress);
                MessageBox.Show(result, "Ping Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please enter a valid IP address.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string PingIp(string ipAddress)
        {
            StringBuilder result = new StringBuilder();
            try
            {
                Ping pingSender = new Ping();
                PingOptions options = new PingOptions
                {
                    DontFragment = true
                };

                // Create a buffer of 32 bytes of data to be transmitted.
                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 120;

                for (int i = 0; i < 10; i++)
                {
                    PingReply reply = pingSender.Send(ipAddress, timeout, buffer, options);
                    if (reply.Status == IPStatus.Success)
                    {
                        result.AppendLine($"Ping {i + 1}:");
                        result.AppendLine("Ping successful.");
                        result.AppendLine($"Address: {reply.Address}");
                        result.AppendLine($"RoundTrip time: {reply.RoundtripTime}");
                        result.AppendLine($"Time to live: {reply.Options.Ttl}");
                        result.AppendLine($"Don't fragment: {reply.Options.DontFragment}");
                        result.AppendLine($"Buffer size: {reply.Buffer.Length}");
                        result.AppendLine();
                    }
                    else
                    {
                        result.AppendLine($"Ping {i + 1}:");
                        result.AppendLine($"Ping failed. Status: {reply.Status}");
                        result.AppendLine();
                    }
                }
            }
            catch (Exception ex)
            {
                result.AppendLine($"Ping failed with exception: {ex.Message}");
            }

            return result.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pingger_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
