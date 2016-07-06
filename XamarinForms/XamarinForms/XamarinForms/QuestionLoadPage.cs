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

        /// <summary>
        /// get the cache of type you want
        /// </summary>
        protected static TCache Cache => cache;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">last part of the url for the richt api end point</param>
        /// <param name="reload">refresh data</param>
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

        /// <summary>
        /// show loading circle during data loading
        /// </summary>
        private void showLoading()
        {
            Content = new ActivityIndicator { HorizontalOptions = LayoutOptions.CenterAndExpand, Color = Color.White, IsVisible = true, IsRunning = true };
        }

        /// <summary>
        /// load data and deserialize object in the background
        /// </summary>
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

        /// <summary>
        /// called after loaded data
        /// </summary>
        protected abstract void OnCacheLoaded();
        /// <summary>
        /// called after loadind failed with an exception
        /// </summary>
        protected virtual void OnCacheLoadedFailed() { }
    }
}
