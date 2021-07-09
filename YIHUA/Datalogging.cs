using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YIHUA
{
    public partial class Datalogging : Form
    {
        public Datalogging()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = (int)numericUpDown1.Value*1000;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        { 
            int i = listBox1.SelectedIndex;
            listBox1.Items.RemoveAt(i);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listBox1.Items.Add("V: " + Dejvis.Voltage + " A:" + Dejvis.Current);
            listBox1.SelectedIndex = listBox1.Items.Count; //možná na konec dopsat -1
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
                
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "csv file (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter file = new StreamWriter(saveFileDialog1.FileName);
                file.WriteLine("U [V];I [A]");
                foreach (var item in listBox1.Items)
                {
                    string line = item.ToString();
                    line = line.Replace("V", "");
                    line = line.Replace(":", "");
                    line = line.Replace(" ", "");
                   
                    line = line.Split('A')[0] + ";" + line.Split('A')[1];
                    file.WriteLine(line);
                }

                file.Close();

            }
            

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
