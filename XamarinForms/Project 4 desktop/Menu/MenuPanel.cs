using Project_4_desktop.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;

namespace Project_4_desktop.Menu
{
    public class MenuPanel : Panel
    {
        public event EventHandler OnModelChanged;

        List<MenuPanelItem> menuItems = new List<MenuPanelItem>
        {
            new MenuPanelItem
            {
                Construct = () => new Question1(),
                Title = "vraag 1"
            },new MenuPanelItem
            {
                Construct = () => new Question2(),
                Title = "vraag 2"
            }
        };

        public PlotModel Model { get; private set; }


        public MenuPanel()
        {
            for (int i = 0; i < menuItems.Count; i++)
            {
                var item = menuItems[i];
                var newButton = new Button
                {
                    Text = item.Title,
                    Top = 20 + 50 * i,
                    Left = 20
                };
                newButton.Click += (sender, e) =>
                    {
                        this.Model = item.Construct();
                        OnModelChanged?.Invoke(this.Model, EventArgs.Empty);
                    };
                Controls.Add(newButton);
            }
        }

        
    }


}
