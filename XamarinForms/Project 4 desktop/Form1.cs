using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OxyPlot;

namespace Project_4_desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var myModel = new PlotModel { Title = "Example 1" };

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("button 1 clicked");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("button 2 clicked");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Console.WriteLine("button 3 clicked");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Console.WriteLine("button 4 clicked");
        }
    }
}
