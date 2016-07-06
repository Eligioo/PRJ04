using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Project_4_desktop
{
    /// <summary>
    /// resposible for loading and parsing of the data
    /// </summary>
    /// <typeparam name="TData">return type of the loaded data</typeparam>
    public class QuestionDataLoader<TData>
    {
        public event EventHandler OnLoaded;
        public event EventHandler OnFailed;

        private static TData cache;
        private static bool cached = false;

        public TData Data => QuestionDataLoader<TData>.cache;

        /// <summary>
        /// path to load
        /// </summary>
        /// <param name="path"></param>
        public QuestionDataLoader(string path)
        {
            loadData(path);
        }

        /// <summary>
        /// load data in the background
        /// </summary>
        /// <param name="path"></param>
        private async void loadData(string path)
        {
            if(cached)
            {
                // hack otherwise eventhandlers are not atached
                await Task.Delay(10);
                OnLoaded?.Invoke(Data, EventArgs.Empty);
                return;
            }
            try
            {
                using (var client = new HttpClient())
                {
                    var download = await client.GetStringAsync($"http://145.24.222.220/v2/{path}");
                    cache = JsonConvert.DeserializeObject<TData>(download);
                    OnLoaded?.Invoke(Data, EventArgs.Empty);
                    cached = true;
                }
            }
            catch
            {
                OnFailed?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
