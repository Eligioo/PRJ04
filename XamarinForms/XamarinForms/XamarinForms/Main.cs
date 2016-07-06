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
        /// starting point of the multiplatform app
        /// </summary>
        public Main()
        {
            // menu page
            MasterDetailPage = new MasterMenu();
            Master = MasterDetailPage;

            MasterDetailPage.ListView.ItemSelected += OnItemSelected;
            // content pagina
            Detail = new NavigationPage(new StartScreen());
        }

        /// <summary>
        /// responsible for changing content page
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