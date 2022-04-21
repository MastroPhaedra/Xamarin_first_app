using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv20
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ajaplaan_Page : ContentPage
    {
        TimePicker ajaplaanTimePicker;
        Image ajaplaanImage;
        Label header;
        private Button plus2HoursButton, minus2HoursButton;
        private Int16 plusOrMinusForTimeButton;
        public Ajaplaan_Page()
        {
            // TimePicker
            // https://moodle.edu.ee/mod/assign/view.php?id=1953374
            // https://docs.microsoft.com/en-us/dotnet/api/system.timespan?view=net-6.0
            // https://metanit.com/sharp/xamarin/3.10.php
            // https://www.c-sharpcorner.com/blogs/date-and-time-format-in-c-sharp-programming1
            // timelapse - https://www.youtube.com/watch?v=VTy1hhZ5uWo
            ajaplaanTimePicker = new TimePicker
            {
                Format = "HH:mm",
                Time = DateTime.Now.TimeOfDay, //            // Time = new System.TimeSpan(17, 0, 0) .ToString("HH:mm") .TimeOfDay
                //WidthRequest = 10,
                //HeightRequest = 10,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                //VerticalOptions = LayoutOptions.StartAndExpand
                //BackgroundColor = Color.Black,
                //TextColor = Color.GhostWhite
            };
            ajaplaanTimePicker.PropertyChanged += ajaplaanTimePicker_PropertyChanged;

            // Image
            ajaplaanImage = new Image
            {
                Source = "tyhi.png",
                WidthRequest = 360,
                HeightRequest = 200,
                //VerticalOptions = LayoutOptions.StartAndExpand
            };

            // +2 hours button
            plus2HoursButton = new Button 
            {
                Text = "+2 Hours",
                HorizontalOptions = LayoutOptions.EndAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            plus2HoursButton.Clicked += PlusOrMinus2HoursButton_Clicked;

            // -2 hours button
            minus2HoursButton = new Button 
            {
                Text = "-2 Hours",
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            minus2HoursButton.Clicked += PlusOrMinus2HoursButton_Clicked;

            // taps
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                DisplayAlert("Picture name",ajaplaanImage.Source.ToString().Substring(6), "Ok");
            };
            ajaplaanImage.GestureRecognizers.Add(tapGestureRecognizer);

            //grid
            Grid grid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                }
            };

            // 1 row
            grid.Children.Add
                (
                    header = new Label
                    {
                        //Text = "Ajaplaan",
                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
                    }, 0, 0 // column, row
                );
            Grid.SetColumnSpan(header, 2);

            // 1 column, 2 row
            grid.Children.Add
                (
                    ajaplaanImage, 0, 1 // column, row
                );

            // 2 row 2 column
            grid.Children.Add
                (
                    ajaplaanTimePicker, 1, 1 // column, row
                );

            // 3 row 1 column
            grid.Children.Add
                (
                    plus2HoursButton, 0, 2 // column, row
                );

            // 3 row 2 column
            grid.Children.Add
                (
                    minus2HoursButton, 1, 2 // column, row
                );

            Content = grid;
        }

        //private void Minus2HoursButton_Clicked(object sender, EventArgs e)
        //{
        //    DateTime timeForButton = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, // year (now) - month (now) - day (now)
        //        ajaplaanTimePicker.Time.Hours, ajaplaanTimePicker.Time.Minutes, ajaplaanTimePicker.Time.Seconds) // - hours (from TimePicker) - minutes (from TimePicker) - seconds (from TimePicker, but no one would not see seconds)
        //        .AddHours(-2); // adding 2 hours to date
        //    ajaplaanTimePicker.Time = TimeSpan.Parse(timeForButton.ToString("HH:mm")); // converts back new datetime (with +2 hours) to TimeSpan
        //}

        private void PlusOrMinus2HoursButton_Clicked(object sender, EventArgs e)
        {
            if (sender == plus2HoursButton)
            {
                plusOrMinusForTimeButton = 2;
            }
            else if (sender == minus2HoursButton)
            {
                plusOrMinusForTimeButton = -2;
            }
            DateTime timeForButton = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, // year (now) - month (now) - day (now)
                ajaplaanTimePicker.Time.Hours, ajaplaanTimePicker.Time.Minutes, ajaplaanTimePicker.Time.Seconds) // - hours (from TimePicker) - minutes (from TimePicker) - seconds (from TimePicker, but no one would not see seconds)
                .AddHours(plusOrMinusForTimeButton); // adding 2 hours to date
            ajaplaanTimePicker.Time = TimeSpan.Parse(timeForButton.ToString("HH:mm")); // converts back new datetime (with +2 hours) to TimeSpan
        }

        private void ajaplaanTimePicker_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            header.Text = $"Valisite: {ajaplaanTimePicker.Time:hh\\:mm}"; // works: ajaplaanTimePicker.Time.Hours + ":" + ajaplaanTimePicker.Time.Minutes; // doesnt work: .ToString("HH:mm")  TimeSpan.Parse()
            if (TimeSpan.Parse("00:00") <= ajaplaanTimePicker.Time && ajaplaanTimePicker.Time < TimeSpan.Parse("02:00"))
            {
                ajaplaanImage.Source = "AM00_02.PNG"; // in name better to use letters then numbers (or u will have errors)
            }
            else if (TimeSpan.Parse("02:00") <= ajaplaanTimePicker.Time && ajaplaanTimePicker.Time < TimeSpan.Parse("04:00"))
            {
                ajaplaanImage.Source = "AM02_04.PNG";
            }
            else if (TimeSpan.Parse("04:00") <= ajaplaanTimePicker.Time && ajaplaanTimePicker.Time < TimeSpan.Parse("06:00"))
            {
                ajaplaanImage.Source = "AM04_06.PNG";
            }
            else if (TimeSpan.Parse("06:00") <= ajaplaanTimePicker.Time && ajaplaanTimePicker.Time < TimeSpan.Parse("08:00"))
            {
                ajaplaanImage.Source = "AM06_08.PNG";
            }
            else if (TimeSpan.Parse("08:00") <= ajaplaanTimePicker.Time && ajaplaanTimePicker.Time < TimeSpan.Parse("10:00"))
            {
                ajaplaanImage.Source = "AM08_10.PNG";
            }
            else if (TimeSpan.Parse("10:00") <= ajaplaanTimePicker.Time && ajaplaanTimePicker.Time < TimeSpan.Parse("12:00"))
            {
                ajaplaanImage.Source = "AM10_12.PNG";
            }
            else if (TimeSpan.Parse("12:00") <= ajaplaanTimePicker.Time && ajaplaanTimePicker.Time < TimeSpan.Parse("14:00"))
            {
                ajaplaanImage.Source = "PM12_14.PNG";
            }
            else if (TimeSpan.Parse("14:00") <= ajaplaanTimePicker.Time && ajaplaanTimePicker.Time < TimeSpan.Parse("16:00"))
            {
                ajaplaanImage.Source = "PM14_16.PNG";
            }
            else if (TimeSpan.Parse("16:00") <= ajaplaanTimePicker.Time && ajaplaanTimePicker.Time < TimeSpan.Parse("18:00"))
            {
                ajaplaanImage.Source = "PM16_18.PNG";
            }
            else if (TimeSpan.Parse("18:00") <= ajaplaanTimePicker.Time && ajaplaanTimePicker.Time < TimeSpan.Parse("20:00"))
            {
                ajaplaanImage.Source = "PM18_20.PNG";
            }
            else if (TimeSpan.Parse("20:00") <= ajaplaanTimePicker.Time && ajaplaanTimePicker.Time < TimeSpan.Parse("22:00"))
            {
                ajaplaanImage.Source = "PM20_22.PNG";
            }
            else if (TimeSpan.Parse("22:00") <= ajaplaanTimePicker.Time) // && ajaplaanTimePicker.Time < TimeSpan.Parse("24:00")
            {
                ajaplaanImage.Source = "PM22_24.PNG";
            }
            else
            {
                ajaplaanImage.Source = "tyhi.PNG";
            }
        }
    }
}