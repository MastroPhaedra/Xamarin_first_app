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
    public partial class Maakonnad_Page : ContentPage
    {
        Picker picker1, picker2;
        Image maakondImage;
        Label header, maakondaDescribe;
        ScrollView scrollView;
        int pickerNumber = 0;
        public Maakonnad_Page()
        {
            // Image
            maakondImage = new Image 
            {
                Source = ""
            };

            // Describe
            maakondaDescribe = new Label
            {
                Text = "Valige maakonda või pealinna ja me näitame teile infot!",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };

            // First Picker
            picker1 = new Picker
            {
                Title = "Maakond"
            };
            picker1.Items.Add("Harjumaa");
            picker1.Items.Add("Ida-Virumaa");
            picker1.Items.Add("Tartumaa");
            picker1.Items.Add("Pärnumaa");
            picker1.Items.Add("Võrumaa");
            picker1.SelectedIndexChanged += Picker_SelectedIndexChanged;

            // Second Picker
            picker2 = new Picker
            {
                Title = "Maakonna pealinn"
            };
            picker2.Items.Add("Tallinn");
            picker2.Items.Add("Jõhvi");
            picker2.Items.Add("Tartu");
            picker2.Items.Add("Pärnu");
            picker2.Items.Add("Võru");
            picker2.SelectedIndexChanged += Picker_SelectedIndexChanged;

            //grid
            Grid grid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(0.5, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = new GridLength(6, GridUnitType.Star) }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                }
            };

            // 1 row
            grid.Children.Add
                (
                    header = new Label
                    {
                        Text = "Valige maakond või maakonna pealinn",
                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
                    }, 0, 0 // column, row
                );
            Grid.SetColumnSpan(header, 2);

            // 2 row
            grid.Children.Add
                (
                    picker1, 0, 1 // column, row
                );
            grid.Children.Add
                (
                    picker2, 1, 1 // column, row
                );

            // 3 row
            grid.Children.Add
                (
                    maakondImage, 0,2 // column, row
                );
            Grid.SetColumnSpan(maakondImage, 2);

            // 4 row
            grid.Children.Add
                (
                    scrollView = new ScrollView { Content = maakondaDescribe }, 0, 3
                );
            Grid.SetColumnSpan(scrollView, 2);

            Content = grid;
        }

        private async void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker pickerDefinition = (Picker)sender; // get Picker from sender (know with / by click)
            pickerNumber = pickerDefinition.SelectedIndex;

            picker1.SelectedIndex = pickerNumber;
            picker2.SelectedIndex = pickerNumber;

            header.Text = "Valisite: " + pickerDefinition.Items[pickerNumber];

            if (pickerNumber == 0)
            {
                maakondImage.Source = "harjumaa.jpg";
                maakondaDescribe.Text = "Asub Põhja-Eestis, ulatub põhjas Keibu lahest Eru laheni ning lõunas Ellamaa, " +
                    "Haiba, Kiisa ja Saarnakõrve maile ning Tapa lähedale, piirneb Lääne-, Rapla-, Järva- ja Lääne-Virumaaga. " +
                    "Harjumaa praegused piirid kujunesid põhiliselt välja 1962, kui tollase Harju rajooniga liideti Keila rajoon, " +
                    "Kõue külanõukogu ja Aegviidu ümbrus, 1963 lisandusid neile Valgejõe-äärsed metsaalad. Harju rajooni maakonnaks " +
                    "muutmisel jäid haldusüksuse piirid endiseks.";
            }
            else if (pickerNumber == 1)
            {
                maakondImage.Source = "ida_virumaa.jpg";
                maakondaDescribe.Text = "Maakond asub Kirde-Eestis, " +
                    "paikneb Soome lahe ja Peipsi järve vahelisel alal. Hõlmab ajaloolise Virumaa idaosa, eraldus 1949 Jõhvimaana, " +
                    "1950 moodustati seal Jõhvi ja Kiviõli rajoon, mis 1960 arvati Kohtla-Järve linnapiirkonda, " +
                    "1964 moodustati selle maalisest osast Kohtla-Järve rajoon, mis muudeti 1. I 1990 haldusreformiga samanimeliseks maakonnaks ja nimetati 26. " +
                    "III 1990 Ida-Virumaaks. Aastast 1994 kuuluvad Ida-Virumaasse ka seni keskvalitsuse alluvuses olnud Kohtla-Järve, Narva ja Sillamäe linn.";
            }
            else if (pickerNumber == 2)
            {
                maakondImage.Source = "tartumaa.jpg";
                maakondaDescribe.Text = "Maakond asub Eesti ida-ja kaguosas Võrtsjärve ja Peipsi vahelisel alal mõlemal pool Emajõge. " +
                    "Nüüdne maakond on ligi pool 1939.–49. aasta Tartumaast, siis kuulusid sellesse ka Avinurme ja Lohusuu vald (nüüd Ida-Virumaa osa), " +
                    "kogu Vooremaa ja Peipsiäärne (nüüd Jõgevamaa kesk- ja idaosa), Aakre, Hellenurme ja Otepää piirkond (nüüd Valgamaa osa) " +
                    "ning Maaritsa–Vastse-Kuuste–Ahja–Rasina ümbrus (nüüd Põlvamaa osa). Varem oli Tartumaa veelgi suurem, " +
                    "kuid 1783 eraldus vastloodud Võru kreis ja 1921 liideti Valgamaaga Sangaste kihelkond. 1950 kaotati Eesti maakondlik jaotus. " +
                    "Tartumaa (ja 1949–50 olnud Jõgevamaa) alal moodustati Elva, Jõgeva, Kallaste, Mustvee ja Tartu rajoon, osa ääremaad arvati Otepää, Põltsamaa, " +
                    "Põlva ja Räpina rajooni. 1959 liideti Tartu rajooniga Kallaste rajoon ja 1962 Elva rajooni põhiosa. " +
                    "Maakond taastati 1990. 1993 arvati Tartumaasse ka Tartu linn, mis oli senini vabariiklikus alluvuses, " +
                    "ning sealtpeale on Tartumaa elanike arvu ja linnastuse poolest Eesti 3. ja Kagu-Eesti 1. maakond.";
            }
            else if (pickerNumber == 3)
            {
                maakondImage.Source = "parnumaa.jpg";
                maakondaDescribe.Text = "Asub Edela-Eestis Liivi lahe kirderannikul. " +
                    "Ajaloolisse Pärnumaasse kuulusid ka nüüdse Raplamaa Käru ja Lelle valla ala ning nüüdse Viljandimaa Halliste, " +
                    "Karksi ja Abja valla piirkond. Läänemaast liideti Pärnumaaga 1939 Mihkli ja 1961 Varbla ümbrus. " +
                    "Piirneb loodes Lääne, põhjas Rapla, kirdes Järva ja idas Viljandi maakonnaga, lõunanaabriks on Läti Salatsi, Aloja ja Mazsalaca piirkond.";
            }
            else if (pickerNumber == 4)
            {
                maakondImage.Source = "vyrumaa.jpg";
                maakondaDescribe.Text = "Maakond asub kagu-Eestis. Piirneb läänes Valga- ja põhjas Põlvamaaga, " +
                    "lõunas Läti Alūksne piirkonna ja idas Venemaa Pihkva oblasti Petseri rajooniga. " +
                    "Nüüdissuuruse sai Võrumaa (aastani 1990 Võru rajoon) 1959 (ühendati väikesed Antsla, Vastseliina ja Võru rajoon). " +
                    "Varasem Võrumaa (aastani 1950) hõlmas ka nüüdse Põlvamaa põhiosa ja Vahina ümbruse Valgamaast (v.a Visela küla ja selle lähikond). " +
                    "Omaaegsest Petserimaast liideti Võrumaaga 1922 Luhamaa piirkond ja 1945 Meremäe vald.";
            }
            else
            {
                await DisplayAlert("Error", "Ooops! \nMidagi läks valesti!", "Ok");
            }
        }
    }
}