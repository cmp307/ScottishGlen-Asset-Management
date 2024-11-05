using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Net;

namespace ScottishGlen___Asset_Management
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            getSystemInfo();
        }

        private void getSystemInfo()
        {
            // Get Computer Name
            string computerName = Environment.MachineName;

            // Get Manufacturer
            string manufacturer = "";

            //Get Model
            string model = "";

            ManagementObjectSearcher() ;

            //// Get System Type
            string systemType = "";
      
            // Get IP Address
            string ipAddress = "Not available";
            try
            {
                foreach (var address in Dns.GetHostAddresses(Dns.GetHostName()))
                {
                    if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)  // IPv4 address
                    {
                        ipAddress = address.ToString();
                        break;
                    }
                }
            }
            catch
            {
                ipAddress = "Unable to retrieve IP";
            }

            ComputerName.Text = computerName;
            Manufacturer.Text = manufacturer;
            Model.Text = model;
            SystemType.Text = systemType;
            myIPAddress.Text = ipAddress;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
