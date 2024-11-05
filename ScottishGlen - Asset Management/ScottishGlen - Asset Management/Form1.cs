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
using System.Data.SqlClient; // when accessing the database
using System.Data.SqlTypes; // when retrieving from database

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

        private void submitButton_Click(object sender, EventArgs e)
        {
            string SystemName = ComputerName.Text;
            string ManufacturerName = Manufacturer.Text;
            string ModelName = Model.Text;
            string SystemTypeName = SystemType.Text;
            string IPAddressName = myIPAddress.Text;
            string EmployeeIDName = EmployeeID.Text;

            SqlConnection conn; // set a connection variable
            string connString = "Data Source = tolmount.abertay.ac.uk; Initial Catalog = mssql2200492; User ID = mssql2200492; Password = W6Q5TenaMh"; // information about the server and database to connect to
            conn = new SqlConnection(connString);// initialize the connection variable with this information


            conn.Open(); // open the connection
            System.Diagnostics.Debug.WriteLine("Connection successfully established.\n");

            string query = "INSERT INTO dbo.Asset (SystemName, Manufacturer, Model, SystemType, IPAddress, EmployeeID) VALUES (@SystemName, @Manufacturer, @Model, @SystemType, @IPAddress, @EmployeeID)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    // Open the connection
                    connection.Open();

                    // Create an SQL command
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Define parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@SystemName", SystemName);
                        command.Parameters.AddWithValue("@ManufacturerName", ManufacturerName);
                        command.Parameters.AddWithValue("@ModelName", ModelName);
                        command.Parameters.AddWithValue("@SystemTypeName", SystemTypeName);
                        command.Parameters.AddWithValue("@IPAddressName", IPAddressName);
                        command.Parameters.AddWithValue("@EmployeeIDName", EmployeeIDName);


                        // Execute the command
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data submitted successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Data submission failed.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
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

        private void submitButton_Click_1(object sender, EventArgs e)
        {

            string SystemName = ComputerName.Text;
            string ManufacturerName = Manufacturer.Text;
            string ModelName = Model.Text;
            string SystemTypeName = SystemType.Text;
            string IPAddressName = myIPAddress.Text;
            int EmployeeIDName = Convert.ToInt32(EmployeeID.Text);

            SqlConnection conn; // set a connection variable
            string connString = "Data Source = tolmount.abertay.ac.uk; Initial Catalog = mssql2200492; User ID = mssql2200492; Password = W6Q5TenaMh"; // information about the server and database to connect to
            conn = new SqlConnection(connString);// initialize the connection variable with this information


            conn.Open(); // open the connection
            System.Diagnostics.Debug.WriteLine("Connection successfully established.\n");

            string query = "INSERT INTO dbo.Asset (SystemName, Manufacturer, Model, Type, IPAddress, EmployeeID) VALUES (@SystemName, @ManufacturerName, @ModelName, @SystemTypeName, @IPAddressName, @EmployeeIDName)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    // Open the connection
                    connection.Open();

                    // Create an SQL command
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Define parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@SystemName", SystemName);
                        command.Parameters.AddWithValue("@ManufacturerName", ManufacturerName);
                        command.Parameters.AddWithValue("@ModelName", ModelName);
                        command.Parameters.AddWithValue("@SystemTypeName", SystemTypeName);
                        command.Parameters.AddWithValue("@IPAddressName", IPAddressName);
                        command.Parameters.AddWithValue("@EmployeeIDName", EmployeeIDName);


                        // Execute the command
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data submitted successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Data submission failed.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }
    }
}
