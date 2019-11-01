using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Grijper_UI
{
    public partial class Form1 : Form
    {
        SerialPort port;
        public Form1()
        { 
            InitializeComponent();
        }

        private void init()
        {
            port = new SerialPort();
            try
            {
                comPorts.Items.AddRange(SerialPort.GetPortNames());
            }
            catch
            {
                MessageBox.Show("No ports available", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            port.BaudRate = 9600;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            init();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                port.WriteLine("open");


            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                port.WriteLine("closed");

            }
        }

        private void ComPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            port.PortName = comPorts.SelectedItem.ToString();
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
                port.Close();

            try
            {
                port.Open();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
    }
}

