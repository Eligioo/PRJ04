using Xamarin.Forms;
using System;

namespace XamarinForms
{
    public class StartScreen : ContentPage
    {
        public StartScreen()
        {
            Title = "Start Screen";
            this.Content = new StackLayout {
                BackgroundColor = Color.White,
                Padding = new Thickness(50,50,50,50),
                Children = {
                    new Image { Source = Device.OnPlatform<string>(string.Empty, "hr.png", "Assets/hr.png") }
                }
            };
        }
    }
}