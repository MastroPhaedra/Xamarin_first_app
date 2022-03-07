using System;
using Xamarin.Forms;

namespace TARgv20
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
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

            StackLayout st = new StackLayout
            {
                Children = { box_btn, entry_btn }
            };
            st.BackgroundColor = Color.Beige;
            Content = st;
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
