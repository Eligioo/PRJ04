using OxyPlot;
using OxyPlot.Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinForms.Graphs;

namespace XamarinForms
{
    public class Question1 : ContentPage
    {
        public Question1()
        {
            Title = "    Question 1";

            GraphFactory<int> graphFactory = new GraphFactory<int>();
            PlotModel plotModel = graphFactory.createGraph(GraphType.Line, new GraphEffect(), new GraphData<int>("Question1", "Xtitel", "Ytitel", new List<int>()));

            this.Content = new PlotView
            {
                BackgroundColor = Color.White,
                Model = plotModel
            };
        }
    }
}