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
    public partial class Picker_Page : ContentPage
    {
        Picker picker;
        WebView webView;
        StackLayout st;
        Frame frame;
        Entry line;
        ImageButton home, back, favorite;
        String link;
        string[] lehed = new string[] { "https://tahvel.edu.ee", "https://moodle.edu.ee", "https://tthk.ee", "https://www.google.com", };

        public Picker_Page()
        {
            picker = new Picker
            {
                Title = "Webileht"
            };
            picker.Items.Add("Tahvel");
            picker.Items.Add("Moodle");
            picker.Items.Add("TTHK");
            picker.Items.Add("Google");
            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;

            webView = new WebView { };

            //SwipeGestureRecognizer swipe = new SwipeGestureRecognizer();
            //swipe.Swiped += Swipe_Swiped;
            //swipe.Direction = SwipeDirection.Right;

            home = new ImageButton 
            {
                Source = "home_btn.jpg"
            };
            home.Clicked += Home_Clicked;

            back = new ImageButton
            {
                Source = "back_btn.png"
            };
            back.Clicked += Back_Clicked;

            favorite = new ImageButton
            {
                Source = "favorite_btn.png"
            };
            favorite.Clicked += Favorite_Clicked;

            line = new Entry 
            { 
                Placeholder = "Otsi veebiadress",
                PlaceholderColor = Color.Black,
                BackgroundColor = Color.GhostWhite,
                TextColor = Color.Black
            };
            line.Completed += Line_Completed;

            StackLayout buttons = new StackLayout { 
                Children = { line, home, back, favorite },
                Orientation = StackOrientation.Horizontal
            };

            frame = new Frame
            {
                Content = buttons,
                BorderColor = Color.Black,
                CornerRadius = 20,
                HeightRequest = 40,
                WidthRequest = 400,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HasShadow = true
            };

            st = new StackLayout { Children = { picker, frame } };
            //frame.GestureRecognizers.Add(swipe);
            Content = st;
        }

        private async void Favorite_Clicked(object sender, EventArgs e)
        {
            int arlenght;
            link = "https://" + line.Text;
            arlenght = lehed.Length;
            //await DisplayAlert("arlenght ", "Ans "+arlenght, "OK");
            //Array.Resize(ref lehed, arlenght+1);
            lehed = lehed.Concat(new string[] { link }).ToArray();
            picker.Items.Add(link);
            //await DisplayAlert("link "+link, "arlenght "+ arlenght + "lehed " + lehed, "OK");
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            if (webView.CanGoBack)
            {
                webView.GoBack();
            }
        }

        private void Line_Completed(object sender, EventArgs e)
        {
            webView.Source = "https://" + line.Text;
        }

        private void Home_Clicked(object sender, EventArgs e)
        {
            webView.Source = new UrlWebViewSource { Url = lehed[3] };
        }

        //private void Swipe_Swiped(object sender, SwipedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (true)
            {
                st.Children.Remove(webView);
            }
            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = lehed[picker.SelectedIndex]},
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            st.Children.Add(webView);
        }
    }
}