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
                Title = "5 buurten met de meeste fietscontainers"
            },new MenuPanelItem
            {
                Construct = () => new Question2(),
                Title = "gestolen fietsen per maand"
            },new MenuPanelItem
            {
                Construct = () => new Question3(),
                Title = "Gestolen fietsen/geplaatste trommels per buurt"
            },new MenuPanelItem
            {
                Construct = () => new Question4a(),
                Title = "Meest gestolen fietsen per merk"
            },new MenuPanelItem
            {
                Construct = () => new Question4b(),
                Title = "Meest gestolen fietsen per kleur"
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
                    Left = 20,
                    Width = 250
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
