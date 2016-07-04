using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;

namespace Project_4_desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            menuPanel.OnModelChanged += MenuPanel_OnModelChanged;
        }

        private void MenuPanel_OnModelChanged(object sender, EventArgs e)
        {
            plot1.Model = menuPanel.Model;
        }
    }
}
