using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Project_4_desktop
{
    public class QuestionDataLoader<TData>
    {
        public event EventHandler OnLoaded;
        public event EventHandler OnFailed;
        public TData Data { get; private set; }

        public QuestionDataLoader(string path)
        {
            loadData(path);
        }

        private async void loadData(string path)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var download = await client.GetStringAsync($"http://145.24.222.220/v2/{path}");
                    Data = await JsonConvert.DeserializeObjectAsync<TData>(download);
                    OnLoaded?.Invoke(Data, EventArgs.Empty);
                }
            }
            catch
            {
                OnFailed?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
