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

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string data;
        int x;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = "Eray ATAK";
            label2.Visible = false;
            textBox1.Visible = false;
            
            button2.Enabled = false;
            button3.Enabled = false;
            string[] portlar = SerialPort.GetPortNames();
            foreach (string item in portlar)
            {
                comboBox1.Items.Add(item);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBox1.SelectedItem.ToString();

        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            data = serialPort1.ReadLine();
            this.Invoke(new EventHandler(deger));
        }
        private void deger(object sender, EventArgs e)
        {
            textBox1.Text = data;

           
            x = Convert.ToInt32(textBox1.Text);
            if (x < 500)
            {
                
                
         
                label1.Text = "Somun Var";
                button2.BackColor = Color.Green;
                button3.BackColor = Color.Green;
            }
            else
            {
                label1.Text = "Somun Yok";
                button2.BackColor = Color.Red;
                button3.BackColor = Color.Red;
            }

            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!serialPort1.IsOpen) serialPort1.Open();
            label2.Visible = false;

        }

        private void DURDUR_Click(object sender, EventArgs e)
        {
            if(serialPort1.IsOpen) serialPort1.Close();
            textBox1.Clear();
            label2.Visible = true;
        }
    }

}
