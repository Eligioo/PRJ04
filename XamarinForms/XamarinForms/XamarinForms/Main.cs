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
        public Main()
        {
            MasterDetailPage = new MasterMenu();
            Master = MasterDetailPage;

            MasterDetailPage.ListView.ItemSelected += OnItemSelected;
            Detail = new NavigationPage(new StartScreen());
        }
        public static class Settings
        {
            // code here...
        }
        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterMenuItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                MasterDetailPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}