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
    public partial class List_Page : ContentPage
    {
        public class Telefon
        {
            public string Nimetus { get; set; }
            public string Tootja { get; set; }
            public int Hind { get; set; }
            public string Pilt { get; set; }
        }
        public ObservableCollection<Telefon> telefons { get; set; }
        Label lbl_list;
        ListView list;
        //Button lisa, kustuta;
        public List_Page()
        {
            Button lisa = new Button { Text = "Lisa telefon" };
            lisa.Clicked += Lisa_Clicked;

            Button kustuta = new Button { Text = "Kustuta telefon" };
            kustuta.Clicked += Kustuta_Clicked;

            telefons = new ObservableCollection<Telefon> 
            {
                new Telefon {Nimetus="Samsung Galaxy S22 Ultra", Tootja="Samsung", Hind=1349, Pilt = "samsung_s22_ultra.webp"},
                new Telefon {Nimetus="Xiaomi Mi 11 Lite 5G NE", Tootja="Xiaomi", Hind=399, Pilt = "xiaomi_mi_11_lite_5g_ne.png"},
                new Telefon {Nimetus="Xiaomi Mi 11 Lite 5G", Tootja="Xiaomi", Hind=339, Pilt = "xiaomi_mi_11_lite_5g.png"},
                new Telefon {Nimetus="iPhone 13", Tootja="Apple", Hind=1179, Pilt = "iphone_13.png"}
            };
            lbl_list = new Label
            {
                Text = "Telefonide loetelu",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            list = new ListView 
            {
                
                SeparatorColor = Color.AliceBlue,
                Header = "Minu oma kollektsioon:",
                Footer = DateTime.Now.ToString("T"),

                HasUnevenRows = true,
                ItemsSource = telefons,
                ItemTemplate = new DataTemplate(() =>
                {
                    ImageCell imageCell = new ImageCell { TextColor = Color.Red, DetailColor = Color.Green};
                    imageCell.SetBinding(ImageCell.TextProperty, "Nimetus");
                    Binding companyBinding = new Binding { Path = "Tootja", StringFormat = "Telefon firmalt {0}" };
                    imageCell.SetBinding(ImageCell.DetailProperty, companyBinding);
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "Pilt");
                    return imageCell;

                    //Label nimetus = new Label (){ FontSize = 20 };
                    //nimetus.SetBinding(Label.TextProperty, "Nimetus");

                    //Label tootja = new Label();
                    //tootja.SetBinding(Label.TextProperty, "Tootja");

                    //Label hind = new Label();
                    //hind.SetBinding(Label.TextProperty, "Hind");

                    //return new ViewCell 
                    //{
                    //    View = new StackLayout 
                    //    {
                    //        Padding = new Thickness(0, 5),
                    //        Orientation = StackOrientation.Vertical,
                    //        Children = {nimetus, tootja, hind}
                    //    }
                    //};
                })
            };
            list.ItemTapped += List_ItemTapped;
            this.Content = new StackLayout { Children = { lbl_list, list, lisa, kustuta } };
        }

        private void Kustuta_Clicked(object sender, EventArgs e)
        {
            Telefon phone = list.SelectedItem as Telefon;
            if (phone != null)
            {
                telefons.Remove(phone);
                list.SelectedItem = null;
            }
        }

        private void Lisa_Clicked(object sender, EventArgs e)
        {
            telefons.Add(new Telefon {Nimetus = "Telefoni nimi", Tootja = "Telefoni tootja", Hind = 1, Pilt = "" });
        }

        private async void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Telefon selectedPhone = e.Item as Telefon;
            if (selectedPhone != null)
            {
                await DisplayAlert("Выбранная модель", $"{selectedPhone.Nimetus}\n{selectedPhone.Tootja}\n{selectedPhone.Hind}", "Ok");
                lbl_list.Text = selectedPhone.Nimetus;
            }
        }
    }
}