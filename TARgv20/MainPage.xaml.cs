using System;
using Xamarin.Forms;

namespace TARgv20
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            Label label_lbl = new Label
            {
                Text = "Tervitus!",
                FontSize = 30,
                FontFamily = "Georgia",
                //HorizontalTextAlignment = "Center"
                //BackgroundColor = Color.Azure
            };

            Button box_btn = new Button
            {
                Text = "BoxView",
                BackgroundColor = Color.Azure
            };
            box_btn.Clicked += Box_btn_Clicked;

            Button entry_btn = new Button
            {
                Text = "Entry",
                BackgroundColor = Color.Azure
            };
            entry_btn.Clicked += Entry_btn_Clicked;

            Button timer_btn = new Button
            {
                Text = "Timer",
                BackgroundColor = Color.Azure
            };
            timer_btn.Clicked += Timer_btn_Clicked;

            StackLayout st = new StackLayout
            {
                Children = { label_lbl, box_btn, entry_btn, timer_btn }
            };
            st.BackgroundColor = Color.Beige;
            Content = st;
        }

        private async void Timer_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Timer_Page());
        }

        private async void Entry_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Entry_Page());
        }

        private async void Box_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Box_Page());
        }
    }
}
