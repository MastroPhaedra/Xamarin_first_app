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
                HorizontalOptions = LayoutOptions.CenterAndExpand
                //HorizontalTextAlignment = "Center"
                //BackgroundColor = Color.Azure
            };

            Button box_btn = new Button
            {
                Text = "BoxView",
                TextColor = Color.White,
                BackgroundColor = Color.Black
            };
            box_btn.Clicked += Box_btn_Clicked;

            Button entry_btn = new Button
            {
                Text = "Entry",
                TextColor = Color.White,
                BackgroundColor = Color.Black
            };
            entry_btn.Clicked += Entry_btn_Clicked;

            Button timer_btn = new Button
            {
                Text = "Timer",
                TextColor = Color.White,
                BackgroundColor = Color.Black
            };
            timer_btn.Clicked += Timer_btn_Clicked;

            Button rgb_btn = new Button
            {
                Text = "RGB",
                TextColor = Color.White,
                BackgroundColor = Color.Black
            };
            rgb_btn.Clicked += Rgb_btn_Clicked;

            Button tic_btn = new Button
            {
                Text = "Tic Tac Toe",
                TextColor = Color.White,
                BackgroundColor = Color.Black
            };
            tic_btn.Clicked += Tic_btn_Clicked;

            Button picker_btn = new Button
            {
                Text = "WEB browser",
                TextColor = Color.White,
                BackgroundColor = Color.Black
            };
            picker_btn.Clicked += Picker_btn_Clicked;

            Button table_btn = new Button
            {
                Text = "Table",
                TextColor = Color.White,
                BackgroundColor = Color.Black
            };
            table_btn.Clicked += Table_btn_Clicked;

            Button content_btn = new Button
            {
                Text = "Content Page",
                TextColor = Color.White,
                BackgroundColor = Color.Black
            };
            content_btn.Clicked += Content_btn_Clicked;

            StackLayout st = new StackLayout
            {
                Children = { label_lbl, box_btn, entry_btn, timer_btn, rgb_btn, tic_btn, picker_btn, table_btn, content_btn }
            };
            //st.BackgroundColor = Color.Beige;
            Content = st;
        }

        private async void Content_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Content_Page());
        }

        private async void Table_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Table_Page());
        }

        private async void Tic_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Tic_Tac_Toe_Page());
        }

        private async void Picker_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Picker_Page());
        }

        private async void Rgb_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Rgb_Page());
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
