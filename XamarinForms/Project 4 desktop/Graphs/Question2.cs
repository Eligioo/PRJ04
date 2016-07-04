using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_4_desktop.Graphs
{
    public class Question2 : PlotModel
    {
        public Question2()
        {
            Title = "question 2";
            Series.Add(new FunctionSeries(Math.Cos, 0, 20, 0.1, "cos(x)"));
        }
    }
}
