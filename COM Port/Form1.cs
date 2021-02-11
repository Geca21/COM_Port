using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COM_Port
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string[] port = System.IO.Ports.SerialPort.GetPortNames();
                comPort.Items.AddRange(port);
                comPort.SelectedIndex = 0;
                btn_Close.Enabled = false;
                labelInrfoPanel.ForeColor = Color.Black;
                if (serialPort1.IsOpen)
                {
                    labelInrfoPanel.Text = "Порт: "+ serialPort1.IsOpen.ToString();
                }
                else { labelInrfoPanel.Text = "Порт: " + serialPort1.IsOpen.ToString(); }

                }
            catch (Exception ex)
            {
                labelInrfoPanel.Text = ex.Message;
                labelInrfoPanel.ForeColor = Color.DarkRed;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            btnOpen.Enabled = false;
            btn_Close.Enabled = true;
            try
            {
                serialPort1.PortName = comPort.Text;
                serialPort1.Open();
                labelInrfoPanel.Text = "Порт: " + serialPort1.IsOpen.ToString();
            }
            catch(Exception ex)
            {
                labelInrfoPanel.Text = ex.Message;
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            btnOpen.Enabled = true;
            btn_Close.Enabled = false;
            try
            {
                serialPort1.PortName = comPort.Text;
                serialPort1.Close();
            }
            catch (Exception ex)
            {
                labelInrfoPanel.Text = ex.Message;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if(serialPort1.IsOpen)
                {
                    serialPort1.WriteLine(txtSend.Text + Environment.NewLine);
                    txtSend.Clear();
                }
            }
            catch (Exception ex)
            {
                labelInrfoPanel.Text = ex.Message;
            }
        }

        

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
                serialPort1.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                txtRec.Text = serialPort1.ReadExisting();
            }
            catch (Exception ex)
            {
                labelInrfoPanel.Text = ex.Message;
            }
        }

        private void btnRec_Click(object sender, EventArgs e)
        {
            try
            {
                txtRec.Text = serialPort1.ReadExisting();
            }
            catch (Exception ex)
            {
                labelInrfoPanel.Text = ex.Message;
            }
        }
    }
}
