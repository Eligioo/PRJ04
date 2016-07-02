using BikeDataModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Project4
{
    public abstract class QuestionLoadPage<TCache> : ContentPage
    {
        private static TCache cache;
        private static bool loaded;

        protected static TCache Cache => cache;

        protected QuestionLoadPage(string path, bool reload = false)
        {
            if(!loaded || reload)
            {
                loadData(path);
                showLoading();
            }
            else
                OnCacheLoaded();
        }

        private void showLoading()
        {
            Content = new ActivityIndicator { HorizontalOptions = LayoutOptions.CenterAndExpand, Color = Color.White, IsVisible = true, IsRunning = true };
        }

        private async void loadData(string path)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string download = await client.GetStringAsync($"http://145.24.222.220/v2/{path}");
                    cache = JsonConvert.DeserializeObject<TCache>(download);
                    loaded = true;
                    OnCacheLoaded();
                }
            }
            catch
            {
                OnCacheLoadedFailed();
            }
        }

        protected abstract void OnCacheLoaded();
        protected virtual void OnCacheLoadedFailed() { }
    }
}
