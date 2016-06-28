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

            if(Device.OS == TargetPlatform.Android || Device.OS == TargetPlatform.WinPhone)
            {
                MasterMenuItems.Add(new MasterMenuItem
                {
                    Title = "Vraag 1",
                    TargetType = typeof(Question1)
                });
                MasterMenuItems.Add(new MasterMenuItem
                {
                    Title = "Vraag 2",
                    TargetType = typeof(Question2)
                });
                MasterMenuItems.Add(new MasterMenuItem
                {
                    Title = "Vraag 3",
                    TargetType = typeof(Question1)
                });
                MasterMenuItems.Add(new MasterMenuItem
                {
                    Title = "Vraag 4",
                    TargetType = typeof(Question1)
                });
                MasterMenuItems.Add(new MasterMenuItem
                {
                    Title = "Vraag 5",
                    TargetType = typeof(Question1)
                });
                MasterMenuItems.Add(new MasterMenuItem
                {
                    Title = "Vraag 6",
                    TargetType = typeof(Question1)
                });
                MasterMenuItems.Add(new MasterMenuItem
                {
                    Title = "test Calendar",
                    TargetType = typeof(Project4.Calendar.CalendarTestPage)
                });
            }

            MasterMenuItems.Add(new MasterMenuItem
            {
                Title = "Save location",
                TargetType = typeof(SaveLocation)
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
