using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv20
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EU_Riigid_Page : ContentPage
    {
        // hide switchcell xamarin forms
        // https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/tableview
        // form in popup xamarin forms
        public class Country
        {
            public string Riigi_Nimi { get; set; }
            public string Pealinn { get; set; }
            public int Rahvaarv { get; set; }
            public int Pindala { get; set; }
            public string Lipp { get; set; }
        }

        Label lbl_list;
        ListView list;
        ObservableCollection<Country> countries;
        //Button lisa, kustuta;
        public EU_Riigid_Page()
        {
            Button lisa = new Button { Text = "Lisa riik" };
            lisa.Clicked += Lisa_Clicked;

            Button kustuta = new Button { Text = "Kustuta riik" };
            kustuta.Clicked += Kustuta_Clicked;

            Button varskenda = new Button { Text = "Värskenda riigi infot" };
            varskenda.Clicked += Varskenda_Clicked;

            countries = new ObservableCollection<Country>
            {
                new Country {Riigi_Nimi="Eesti", Pealinn="Tallinn", Rahvaarv=1331796, Pindala = 45339, Lipp = "Flag_of_Estonia.webp"},
                new Country {Riigi_Nimi="Ameerika Uhendriigid", Pealinn="Washington", Rahvaarv=328239523, Pindala = 9826675, Lipp = "Flag_of_the_USA.webp"},
                new Country {Riigi_Nimi="Ukraina", Pealinn="Kiiev", Rahvaarv=41588354, Pindala = 603550, Lipp = "Flag_of_Ukraine.webp"},
                new Country {Riigi_Nimi="Nigeeria", Pealinn="Abuja", Rahvaarv=211400708, Pindala = 923768, Lipp = "Flag_of_Nigeria.webp"}
            };

            lbl_list = new Label
            {
                Text = "Riigide loetelu",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };

            list = new ListView
            {
                SeparatorColor = Color.AliceBlue,
                Header = "Riigid:",
                Footer = "Eestis praegu: " + DateTime.Now.ToString("T"),

                HasUnevenRows = true,
                ItemsSource = countries, //countries

                //IsGroupingEnabled = true,
                //GroupHeaderTemplate = new DataTemplate(() =>
                //{
                //    Label tootja = new Label();
                //    tootja.SetBinding(Label.TextProperty, "Riigi_Nimi");
                //    return new ViewCell
                //    {
                //        View = new StackLayout
                //        {
                //            Padding = new Thickness(0, 5),
                //            Orientation = StackOrientation.Vertical,
                //            Children = { tootja }
                //        }
                //    };
                //}),

                ItemTemplate = new DataTemplate(() =>
                {
                    ImageCell imageCell = new ImageCell(); // { TextColor = Color.Red, DetailColor = Color.Green }
                    imageCell.SetBinding(ImageCell.TextProperty, "Riigi_Nimi");
                    //Binding companyBinding = new Binding { Path = "Pealinn", StringFormat = "Country firmalt {0}" };
                    imageCell.SetBinding(ImageCell.DetailProperty, "Pealinn"); //companyBinding
                    //imageCell.SetBinding(ImageCell.DetailProperty, "Rahvaarv");
                    //imageCell.SetBinding(ImageCell.DetailProperty, "Pindala");
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "Lipp");
                    return imageCell;

                    //Label nimetus = new Label() { FontSize = 20 };
                    //nimetus.SetBinding(Label.TextProperty, "Riigi_Nimi");

                    //Label hind = new Label();
                    //hind.SetBinding(Label.TextProperty, "Rahvaarv");

                    //return new ViewCell
                    //{
                    //    View = new StackLayout
                    //    {
                    //        Padding = new Thickness(0, 5),
                    //        Orientation = StackOrientation.Vertical,
                    //        Children = { nimetus, hind }
                    //    }
                    //};
                }),
            };
            list.ItemTapped += List_ItemTapped;
            this.Content = new StackLayout { Children = { lbl_list, list, lisa, kustuta, varskenda } };
        }

        private void Varskenda_Clicked(object sender, EventArgs e)
        {
            //Country countr = list.SelectedItem as Country;

            //var name = country.Text; //Entry field
            //if (countries.Any(x => x.Riigi_Nimi == name))
            //{
            //    DisplayAlert("Hoiatus:", "See riik on juba nimekirjas", "Ok");
            //}

            //else
            //{
            //    if (countr != null)
            //    {
            //        countries.Remove(countr);
            //        list.SelectedItem = null;
            //    }
            //    countries.Add(new Country { Riigi_Nimi = country.Text, Pealinn = capital.Text, Rahvaarv = population.Text, Lipp = imageURL.Text });
            //}
        }

        private void Kustuta_Clicked(object sender, EventArgs e)
        {
            Country phone = list.SelectedItem as Country;
            if (phone != null)
            {
                countries.Remove(phone);
                list.SelectedItem = null;
            }
        }

        private void Lisa_Clicked(object sender, EventArgs e)
        {
            countries.Add(new Country {Riigi_Nimi = "Country nimi", Pealinn = "Country pealinn", Rahvaarv = 1, Pindala = 1, Lipp = "" });
            //var name = country.Text;
            //if (countries.Any(x => x.Name == name))
            //{
            //    await DisplayAlert("Hoiatus:", "See riik on juba nimekirjas", "Ok");
            //}
            //else
            //{
            //    countries.Add(new Country { Name = country.Text, Capital = capital.Text, Population = population.Text, Flag = imageURL.Text });
            //}
        }

        private async void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Country selectedRiik = e.Item as Country;
            if (selectedRiik != null)
            {
                lbl_list.Text = selectedRiik.Riigi_Nimi;
                await DisplayAlert($"Valitud riik: {selectedRiik.Riigi_Nimi}", $"Pealinn: {selectedRiik.Pealinn}\nRahvaarv: {selectedRiik.Rahvaarv} inimest\nPindala: {selectedRiik.Pindala} km²", "Ok");
            }
        }
    }
}