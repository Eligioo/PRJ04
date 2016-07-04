using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinForms
{
    public class MasterMenu: ContentPage
    {
        public ListView ListView { get; }
        public MasterMenu()
        {
            var MasterMenuItems = new List<MasterMenuItem>
            {
                new MasterMenuItem
                {
                    Title = "Start",
                    TargetType = typeof(StartScreen)
                }
            };

            if(Device.OS == TargetPlatform.Android)
            {
                MasterMenuItems.Add(new MasterMenuItem
                {
                    Title = "buurten met meeste fietscontainers",
                    TargetType = typeof(Question1)
                });
                MasterMenuItems.Add(new MasterMenuItem
                {
                    Title = "gestolen fietsen per maand",
                    TargetType = typeof(Question2)
                });
                MasterMenuItems.Add(new MasterMenuItem
                {
                    Title = "fiets trommels/diefstallen per buurt",
                    TargetType = typeof(Question3)
                });
                MasterMenuItems.Add(new MasterMenuItem
                {
                    Title = "gestolen fietsen merk/kleur",
                    TargetType = typeof(Question4)
                });
            }
            MasterMenuItems.Add(new MasterMenuItem
            {
                Title = "plan fiets ophalen",
                TargetType = typeof(Project4.Calendar.Calendar)
            });
            MasterMenuItems.Add(new MasterMenuItem
            {
                Title = "Sla locatie op",
                TargetType = typeof(SaveLocation)
            });
            MasterMenuItems.Add(new MasterMenuItem
            {
                Title = "Maps",
                TargetType = typeof(QuestionMaps)
            });
            ListView = new ListView
            {
                ItemsSource = MasterMenuItems,
                ItemTemplate = new DataTemplate(() => {
                    var textCell = new TextCell();
                    textCell.SetBinding(TextCell.TextProperty, "Title");
                    return textCell;
                }),
                VerticalOptions = LayoutOptions.FillAndExpand,
                SeparatorVisibility = SeparatorVisibility.None
            };
            Title = "HR Menu";
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { ListView }
            };
        }
    }

    internal class MasterMenuItem
    {
        public Type TargetType { get; set; }
        public string Title { get; set; }
    }
}
