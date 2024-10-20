using System;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ElapsedTimeToExam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Elapsed Time to Exam: 5.05.2025 9:00";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = (int)(stop - start).TotalDays;
        }

        private int step = 0;
        readonly private DateTime stop = new DateTime(2025, 05, 05, 09, 00, 00);
        readonly private DateTime start = new DateTime(2024, 09, 02, 09, 00, 00);
        readonly private DateTime startupTime = DateTime.Now;


        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime cur = DateTime.Now;
            DateTime current = cur.AddMinutes(step);
            TimeSpan ts = (stop - cur);

            label1.Text = "startup time: " + startupTime.ToString("g");
            label2.Text = "current time: " + current.ToString("g");

            label3.Text = "remaining time: " + TimeSpan.FromSeconds(step).ToString();
            label4.Text = "elapsed time: " + TimeSpan.FromSeconds((int)ts.TotalSeconds).ToString();
            
            
            int per = (int)(cur - start).TotalDays;
            int all = (int)(stop - start).TotalDays;
            progressBar1.Value = per;
            int percent = (int)(100 * per / all);

            using (Graphics graphics = progressBar1.CreateGraphics())
            {
                graphics.DrawString(percent.ToString() + "%", SystemFonts.DefaultFont, Brushes.Black,
                    new PointF(progressBar1.Width / 2 - (graphics.MeasureString(percent.ToString() + "%",
                SystemFonts.DefaultFont).Width / 2.0F),
                    progressBar1.Height / 2 - (graphics.MeasureString(percent.ToString() + "%",
                    SystemFonts.DefaultFont).Height / 2.0F)));
            }
            step++;
        }



        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            timer1.Stop();
            Application.Restart();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            timer1.Stop();
            Application.Exit();

        }

    }
}

