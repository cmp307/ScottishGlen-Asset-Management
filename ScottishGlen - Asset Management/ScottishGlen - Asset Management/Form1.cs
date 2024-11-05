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
            // Get System Data
            string computerName = Environment.MachineName;
            string manufacturer = "Unknown";
            string model = "Unknown";
            string systemType = "Unknown";

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem"))
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    manufacturer = obj["Manufacturer"]?.ToString();
                    model = obj["Model"]?.ToString();
                    systemType = obj["SystemType"]?.ToString();
                }
            }

            // Get IP Address
            string ipAddress = "Not available";
            string hostName = Dns.GetHostName();
            string IP = Dns.GetHostEntry(hostName).AddressList[0].ToString();
            ipAddress = IP;


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
