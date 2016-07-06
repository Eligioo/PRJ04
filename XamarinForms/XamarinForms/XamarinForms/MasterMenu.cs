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
            Icon = "hamburger.png";
            var MasterMenuItems = new List<MasterMenuItem>
            {
                new MasterMenuItem
                {
                    Title = "Start",
                    Construct = () => new StartScreen()
                }
            };
            //only on android visible
            if(Device.OS == TargetPlatform.Android)
            {
                MasterMenuItems.Add(new MasterMenuItem
                {
                    Title = "buurten met meeste fietscontainers",
                    Construct = () => new Question1()
                });
                MasterMenuItems.Add(new MasterMenuItem
                {
                    Title = "gestolen fietsen per maand",
                    Construct = () => new Question2()
                });
                MasterMenuItems.Add(new MasterMenuItem
                {
                    Title = "fiets trommels/diefstallen per buurt",
                    Construct = () => new Question3()
                });
                MasterMenuItems.Add(new MasterMenuItem
                {
                    Title = "gestolen fietsen merk/kleur",
                    Construct = () => new Question4()
                });
            }
            MasterMenuItems.Add(new MasterMenuItem
            {
                Title = "plan fiets ophalen",
                Construct = () => new Project4.Calendar.Calendar()
            });
            MasterMenuItems.Add(new MasterMenuItem
            {
                Title = "Sla fiets locatie op",
                Construct = () => new SaveLocation()
            });
            MasterMenuItems.Add(new MasterMenuItem
            {
                Title = "Dichtst bijzijnde fiets trommel",
                Construct = () => new QuestionMaps()
            });
            MasterMenuItems.Add(new MasterMenuItem
            {
                Title = "Mijn Fiets is gestolen!",
                Construct = () => new StolenBikePage() //change this to appropriate
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

    /// <summary>
    /// simple factory for creating new pages
    /// </summary>
    internal class MasterMenuItem
    {
        public Func<Page> Construct { get; set; }
        public string Title { get; set; }
    }
}
