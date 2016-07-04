using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_4_desktop.Menu
{
    public class MenuPanelItem
    {
        public Func<PlotModel> Construct { get; set; }
        public string Title { get; set; }
    }
}
