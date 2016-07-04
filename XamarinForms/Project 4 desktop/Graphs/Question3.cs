using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeDataModels;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace Project_4_desktop.Graphs
{
    public class Question3 : PlotModel
    {
        public Question3()
        {
            var picker = new Question3NeighborhoodPicker(this);
            picker.Show();
        }

        internal void RefreshData(CombinationofTheftTrommelAreaMonth input)
        {

        }
    }
}
