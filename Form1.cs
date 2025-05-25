using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Threading.Tasks;
namespace gui_testing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void RunSimulator()
        {
            Random rnd = new Random();
            int sum = 0;
            bool stats = false;
            int win = 0;

            List<int> win_list = new List<int>();
            List<int> chance_list = new List<int>();
            List<int> sum_list = new List<int>();

            for (int i = 0; i < 5; i++)
            {
                while (!stats)
                {
                    int randomNumber1 = rnd.Next(1, 1000);
                    int randomNumber2 = rnd.Next(1, 1000);
                    sum++;

                    if (randomNumber1 == randomNumber2)
                    {
                        double chance = Math.Pow(0.999, sum) * 100;

                        this.Invoke((MethodInvoker)(() =>
                        {
                            label7.Text = $"Numbers are equal: {randomNumber1}";
                            label8.Text = $"Sum: {sum}";
                            label9.Text = $"Chance: {chance:F2}";
                        }));

                        stats = true;
                        win++;
                        win_list.Add(win);
                        chance_list.Add((int)chance);
                        sum_list.Add(sum);
                    }
                }

                stats = false;
                sum = 0;
            }

            this.Invoke((MethodInvoker)(() =>
            {
                label1.Text = $"Max chance: {chance_list.Max()}";
                label2.Text = $"Max sum: {sum_list.Max()}";
                label3.Text = $"Min chance: {chance_list.Min()}";
                label4.Text = $"Min sum: {sum_list.Min()}";
                label5.Text = $"Average chance: {(int)chance_list.Average()}";
                label6.Text = $"Average sum: {(int)sum_list.Average()}";
            }));
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await Task.Run(() => RunSimulator());
        }
    }
}