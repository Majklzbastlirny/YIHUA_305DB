using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace YIHUA
{

    public partial class Dejvis : Form
    {
        public String received;

        public String OE = "N";
        public String CC = "H";

        public static float Current;
        public static float Voltage;

        List<int> waveform_time = new List<int>();
        List<double> waveform_current = new List<double>();
        List<double> waveform_voltage = new List<double>();
        int waveform_index = 0;

        public double time = 60;

        public Dejvis()
        {
            InitializeComponent();

            chart1.ChartAreas[0].AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "";
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "";
            chart1.ChartAreas[0].AxisY.LabelStyle.IsEndLabelVisible = true;

            chart1.ChartAreas[0].AxisX.Maximum = 60;
            chart1.ChartAreas[0].AxisY.Maximum = 0.5;

            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Interval = 10;

            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;

            chart1.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = true;

            chart1.ChartAreas[0].AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;

            // chart1.ChartAreas[0].AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            //chart1.ChartAreas[0].AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;

            chart1.Series[0].Points.AddXY(0, 0);


            chart2.ChartAreas[0].AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chart2.ChartAreas[0].AxisX.LabelStyle.Format = "";
            chart2.ChartAreas[0].AxisY.LabelStyle.Format = "";
            chart2.ChartAreas[0].AxisY.LabelStyle.IsEndLabelVisible = true;

            chart2.ChartAreas[0].AxisX.Maximum = 60;
            chart2.ChartAreas[0].AxisY.Maximum = 0.5;

            chart2.ChartAreas[0].AxisX.Minimum = 0;
            chart2.ChartAreas[0].AxisY.Minimum = 0;
            chart2.ChartAreas[0].AxisX.Interval = 10;

            chart2.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chart2.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;

            chart2.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGray;
            chart2.ChartAreas[0].AxisX.MinorGrid.Enabled = true;

            chart2.ChartAreas[0].AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;

            // chart1.ChartAreas[0].AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            //chart1.ChartAreas[0].AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;

            chart2.Series[0].Points.AddXY(0, 0);
            

            chart3.ChartAreas[0].AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chart3.ChartAreas[0].AxisX.LabelStyle.Format = "";
            chart3.ChartAreas[0].AxisY.LabelStyle.Format = "";
            chart3.ChartAreas[0].AxisY.LabelStyle.IsEndLabelVisible = true;

            chart3.ChartAreas[0].AxisX.Maximum = 60;
            chart3.ChartAreas[0].AxisY.Maximum = 0.5;

            chart3.ChartAreas[0].AxisX.Minimum = 0;
            chart3.ChartAreas[0].AxisY.Minimum = 0;
            chart3.ChartAreas[0].AxisX.Interval = 10;

            chart3.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chart3.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;

            chart3.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGray;
            chart3.ChartAreas[0].AxisX.MinorGrid.Enabled = true;

            chart3.ChartAreas[0].AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;

            // chart1.ChartAreas[0].AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            //chart1.ChartAreas[0].AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;

            chart3.Series[0].Points.AddXY(0, 0);


            chart4.ChartAreas[0].AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chart4.ChartAreas[0].AxisX.LabelStyle.Format = "";
            chart4.ChartAreas[0].AxisY.LabelStyle.Format = "";
            chart4.ChartAreas[0].AxisY.LabelStyle.IsEndLabelVisible = true;

            chart4.ChartAreas[0].AxisX.Maximum = 0.1;
            chart4.ChartAreas[0].AxisY.Maximum = 0.01;

            chart4.ChartAreas[0].AxisX.Minimum = 0;
            chart4.ChartAreas[0].AxisY.Minimum = 0;


            chart4.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chart4.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;

            chart4.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGray;
            chart4.ChartAreas[0].AxisX.MinorGrid.Enabled = true;

            chart4.ChartAreas[0].AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;

            chart4.ChartAreas[0].AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chart4.ChartAreas[0].AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;

            chart4.Series[0].Points.AddXY(0, 0);    

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String[] ports = SerialPort.GetPortNames();
            comboBox1.DataSource = ports;
            comboBox1.Text = "COM1";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                serialPort1.PortName = comboBox1.Text;
                serialPort1.Open();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            timer1.Start();
            
        }

      

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((Current > Convert.ToDouble((numericUpDown2.Value / 1000)-10)) & checkBox2.Checked)
            {
                OE = "N";
                button2.BackColor = Color.Yellow;
                button2.Text = "SW fuse";
                timer2.Stop();
            }

            //serialPort1.Write("WYHPPSU" + numericUpDown1.Value.ToString().PadLeft(4, '0') + "A" + numericUpDown2.Value.ToString("d4"));
            serialPort1.Write("YHPPSU" + numericUpDown1.Value.ToString().PadLeft(4, '0') + CC + numericUpDown2.Value.ToString().PadLeft(4, '0') + OE);

            /*Poslední znak - N vypnuto; O zapnuto
             * Znak uprostřed - C proudová pojistka; H proudový limit
             * 
             * 
             * */
             


            label3.Text = Voltage.ToString() + " V";
            label4.Text = Current.ToString() + " A";
            label5.Text = (Current*Voltage  ).ToString() + " W";

            chart1.Series[0].Points.AddXY(time, Current);
            if (Current > chart1.ChartAreas[0].AxisY.Maximum)
            {
                chart1.ChartAreas[0].AxisY.Maximum = Current;
            }

            chart2.Series[0].Points.AddXY(time, Voltage);
            if (Voltage > chart2.ChartAreas[0].AxisY.Maximum)
            {
                chart2.ChartAreas[0].AxisY.Maximum = Voltage;
            }

            chart3.Series[0].Points.AddXY(time, Voltage*Current);
            if (Voltage*Current > chart3.ChartAreas[0].AxisY.Maximum)
            {
                chart3.ChartAreas[0].AxisY.Maximum = Voltage*Current;
            }

            
            if (Voltage > chart4.ChartAreas[0].AxisX.Maximum)
            {
                chart4.ChartAreas[0].AxisX.Maximum = Voltage;
            }
            if (Current > chart4.ChartAreas[0].AxisY.Maximum)
            {
                chart4.ChartAreas[0].AxisY.Maximum = Current;
            }
            chart4.Series[0].Points.AddXY(Voltage, Current);


        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            try
            {
                String read = serialPort1.ReadTo("Y");
                read = read.Remove(0, 10);
                received = read.Replace("?", "");

                if (received.IndexOf('B') > -1)
                {

                    OE = "N";
                    button2.BackColor = Color.Yellow;
                    button2.Text = "Current fuse! ... OOF";
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"./Sounds/do_prdele.wav");
                    player.Play();

                }

                received = received.Remove(received.Length - 1);
                Current = Convert.ToInt16(received.Split('A')[1]);
                Voltage = Convert.ToInt16(received.Split('A')[0]);

                Current = Current / 1000;
                Voltage = Voltage / 100;

            }
            catch (Exception)
            {

                
            }
            
          
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                CC = "C";
            }
            else
            {
                CC = "H";
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"./Sounds/neodstoupim.wav");
                player.Play();
            }
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.Lime)
            {
                OE = "N";
                button2.BackColor = Color.Red;
                button2.Text = "Off";
                timer2.Stop();
            }
            else
            {
                OE = "O";
                button2.BackColor = Color.Lime;
                button2.Text = "On";
                timer2.Start();

            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            time = time + 0.1;
            if (time > 60)
            {
                chart1.ChartAreas[0].AxisX.IntervalOffset = 10 - time % 10;
                chart1.ChartAreas[0].AxisX.Minimum = time - 60;
                chart1.ChartAreas[0].AxisX.Maximum = time;

                chart2.ChartAreas[0].AxisX.IntervalOffset = 10 - time % 10;
                chart2.ChartAreas[0].AxisX.Minimum = time - 60;
                chart2.ChartAreas[0].AxisX.Maximum = time;

                chart3.ChartAreas[0].AxisX.IntervalOffset = 10 - time % 10;
                chart3.ChartAreas[0].AxisX.Minimum = time - 60;
                chart3.ChartAreas[0].AxisX.Maximum = time;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void chart4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            chart4.Series[0].Points.Clear();
        }

        private void otevřítWaveformToolStripMenuItem_Click(object sender, EventArgs e)
        {
            waveform_timer.Stop();
            waveform_index = 0;
            //listBox1.SelectedIndex = 0;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Title = "Open waveform";
            openFileDialog1.DefaultExt = "csv";
            openFileDialog1.Filter = "CSV table (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            openFileDialog1.ShowDialog();


            if (File.Exists(openFileDialog1.FileName))
            {
                string[] file = File.ReadAllLines(openFileDialog1.FileName);
                for (int i = 0; i < file.Length; i++)
                {
                    try
                    {
                        waveform_voltage.Add(Convert.ToDouble(file[i].Split(';')[0]));
                        waveform_current.Add(Convert.ToDouble(file[i].Split(';')[1]));
                        waveform_time.Add(Convert.ToInt32(file[i].Split(';')[2]));

                        listBox1.Items.Add("U: " + file[i].Split(';')[0] + "  I: " + file[i].Split(';')[1] + " mA, t: " + file[i].Split(';')[2] + " ms");
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("V souboru je nějaká chyba :-(");
                    }

                }
            }
            else
            {
                MessageBox.Show("Takovej soubor tu není nebo je nemocnej");
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (waveform_voltage.Count == 0)
            {
                MessageBox.Show("Co bys chtěl pustit debile");
                return;
            }
            if (waveform_index >= waveform_voltage.Count)
            {
                waveform_index = 0;

            }
            listBox1.SelectedIndex = waveform_index;
            waveform_timer.Interval = waveform_time[waveform_index];
            waveform_timer.Start();
            numericUpDown2.Value = (decimal)waveform_voltage[waveform_index];
            numericUpDown1.Value = (decimal)waveform_current[waveform_index];
            waveform_index++;

            

        }

        private void waveform_timer_Tick(object sender, EventArgs e)
        {
            if (waveform_time.Count <= waveform_index)
            {
                waveform_timer.Stop();
                return;
            }

            listBox1.SelectedIndex = waveform_index;

          
                listBox1.SelectedIndex = waveform_index;

            numericUpDown1.Value = (decimal)waveform_voltage[waveform_index];
            numericUpDown2.Value = (decimal)waveform_current[waveform_index];


            waveform_index++;


            if (waveform_time.Count <= waveform_index)
            {
                waveform_timer.Stop();
                return;
            }

            waveform_timer.Interval = waveform_time[waveform_index];
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            waveform_index = listBox1.SelectedIndex;
            waveform_timer.Interval = waveform_time[waveform_index];
            numericUpDown2.Value = (decimal)waveform_current[waveform_index];
            numericUpDown1.Value = (decimal)waveform_voltage[waveform_index];
        }
     
        private void button5_Click(object sender, EventArgs e)
        {
            waveform_timer.Stop();
        }

        private void dataloggingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Datalogging form = new Datalogging();
            form.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
