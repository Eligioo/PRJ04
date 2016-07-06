using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XamarinForms
{
    public class Main : MasterDetailPage
    {
        MasterMenu MasterDetailPage;
        /// <summary>
        /// Constructor for the initialisation. Loading a blank MasterMenu and a ListView for the menu-items.
        /// </summary>
        public Main()
        {
            MasterDetailPage = new MasterMenu();
            var x = new MasterMenu();
            Master = MasterDetailPage;

            MasterDetailPage.ListView.ItemSelected += OnItemSelected;
            Detail = new NavigationPage(new StartScreen());
        }

        /// <summary>
        /// Method is triggerd when a menu-item form the ListView is clicked by the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterMenuItem;
            if (item != null)
            {
                Detail = new NavigationPage(item.Construct());
                MasterDetailPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}