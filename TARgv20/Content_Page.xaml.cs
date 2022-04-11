using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv20
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Content_Page : ContentPage
    {
        public Content_Page()
        {
            Button maakonnad_btn = new Button
            {
                Text = "Maakonnad",
                TextColor = Color.White,
                BackgroundColor = Color.Black
            };
            maakonnad_btn.Clicked += Maakonnad_btn_Clicked;

            Button ajaplaan_btn = new Button
            {
                Text = "Ajaplaan",
                TextColor = Color.White,
                BackgroundColor = Color.Black
            };
            ajaplaan_btn.Clicked += Ajaplaan_btn_Clicked;

            Button horoskop_btn = new Button
            {
                Text = "Horoskop",
                TextColor = Color.White,
                BackgroundColor = Color.Black
            };
            horoskop_btn.Clicked += Horoskop_btn_Clicked;

            StackLayout st = new StackLayout
            {
                Children = { maakonnad_btn, horoskop_btn, ajaplaan_btn }
            };
            //st.BackgroundColor = Color.Beige;
            Content = st;
        }

        private async void Ajaplaan_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Ajaplaan_Page());
        }

        private async void Horoskop_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Horoskop_Page());
        }

        private async void Maakonnad_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Maakonnad_Page());
        }
    }
}