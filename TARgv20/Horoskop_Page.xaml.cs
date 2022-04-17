using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv20
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Horoskop_Page : ContentPage
    {
        Entry zodiacEntry;
        DatePicker zodiacDatePicker;
        Image zodiacImage;
        Label header, zodiacDescribe;
        ScrollView scrollView;
        public char[] charsToTrim = { '$', '*', ' ', '\'', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ',', '.', ':', ';', '-', '+', '#', '!', '/', '¤', '%', '&', '(', ')', '=', '?', '`', '[', ']', '{', '}', '<', '>'};
        public Horoskop_Page()
        {
            // DatePicker
            zodiacDatePicker = new DatePicker
            {
                //Format = "dd/MM/YYYY",
                //Date = DateTime.Now,
                WidthRequest = 10,
                //BackgroundColor = Color.Black,
                //TextColor = Color.GhostWhite
                //MaximumDate = DateTime.Now.AddDays(5), // +5 days
                //MinimumDate = DateTime.Now.AddDays(-5) // +5 days
            };
            zodiacDatePicker.DateSelected += datePicker_DateSelected;

            // Image
            zodiacImage = new Image
            {
                Source = ""
            };

            // Describe
            zodiacDescribe = new Label
            {
                Text = "Info leidmiseks valige päev või otsige sodiaagimärgi järgi!!",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };

            // Zodiaac signs Picker
            zodiacEntry = new Entry
            {
                Placeholder = "Otsi soodiagimärke",
                //PlaceholderColor = Color.LightGray,
                WidthRequest = 10,
                MaxLength = 10,
                ClearButtonVisibility = ClearButtonVisibility.WhileEditing, // кнопка полной очистки поля // field clear button
                //Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeSentence), // Заглавные буквы // Capital letters
                Keyboard = Keyboard.Text, // клавиатура только для поля // field-only keyboard
                ReturnType = ReturnType.Search, // отображает в клавиатуре иконку лупы // displays a magnifying glass icon in the keyboard
                //BackgroundColor = Color.Black,
                //TextColor = Color.GhostWhite,
            };
            zodiacEntry.Completed += Entry_Completed;

            //grid
            Grid grid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(0.5, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
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
                        Text = "Sodiaagimärgid",
                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
                    }, 0, 0 // column, row
                );
            Grid.SetColumnSpan(header, 2);

            // 2 row
            grid.Children.Add
                (
                    zodiacDatePicker, 0, 1 // column, row
                );
            grid.Children.Add
                (
                    zodiacEntry, 0, 2 // column, row
                );

            // 2 column, 1+2 row
            grid.Children.Add
                (
                    zodiacImage, 1, 1 // column, row
                );
            Grid.SetRowSpan(zodiacImage, 2);

            // 4 row
            grid.Children.Add
                (
                    scrollView = new ScrollView { Content = zodiacDescribe }, 0, 3 // column, row
                );
            Grid.SetColumnSpan(scrollView, 2);

            Content = grid;
        }

        private void datePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            var year = e.NewDate.Year; // year
            //string i = zodiacDatePicker.Date.ToString();
            if (new DateTime(year, 04, 14) <= e.NewDate && e.NewDate  <= new DateTime(year, 05, 14)) //YYYY MM DD - вне зависимости, какой год поставят // no matter what year
            {
                jaarZodiac();
                zodiacEntry.Text = "Jäär";
            }
            else if (new DateTime(year, 05, 15) <= e.NewDate && e.NewDate <= new DateTime(year, 06, 14))
            {
                sonnZodiac();
                zodiacEntry.Text = "Sõnn";
            }
            else if (new DateTime(year, 06, 15) <= e.NewDate && e.NewDate <= new DateTime(year, 07, 16))
            {
                kaksikudZodiac();
                zodiacEntry.Text = "Kaksikud";
            }
            else if (new DateTime(year, 07, 17) <= e.NewDate && e.NewDate <= new DateTime(year, 08, 16))
            {
                vahkZodiac();
                zodiacEntry.Text = "Vähk";
            }
            else if (new DateTime(year, 08, 17) <= e.NewDate && e.NewDate <= new DateTime(year, 09, 16))
            {
                loviZodiac();
                zodiacEntry.Text = "Lõvi";
            }
            else if (new DateTime(year, 09, 17) <= e.NewDate && e.NewDate <= new DateTime(year, 10, 17))
            {
                neitsiZodiac();
                zodiacEntry.Text = "Neitsi";
            }
            else if (new DateTime(year, 10, 18) <= e.NewDate && e.NewDate <= new DateTime(year, 11, 16))
            {
                kaaludZodiac();
                zodiacEntry.Text = "Kaalud";
            }
            else if (new DateTime(year, 11, 17) <= e.NewDate && e.NewDate <= new DateTime(year, 12, 15))
            {
                skorpionZodiac();
                zodiacEntry.Text = "Skorpion";
            }
            else if (new DateTime(year, 12, 16) <= e.NewDate || e.NewDate <= new DateTime(year, 01, 14)) // problem ||
            {
                amburZodiac();
                zodiacEntry.Text = "Ambur";
            }
            else if (new DateTime(year, 01, 15) <= e.NewDate && e.NewDate <= new DateTime(year, 02, 12))
            {
                kaljukitsZodiac();
                zodiacEntry.Text = "Kaljukits";
            }
            else if (new DateTime(year, 02, 13) <= e.NewDate && e.NewDate <= new DateTime(year, 03, 14))
            {
                veevalajaZodiac();
                zodiacEntry.Text = "Veevalaja";
            }
            else if (new DateTime(year, 03, 15) <= e.NewDate && e.NewDate <= new DateTime(year, 04, 13))
            {
                kaladZodiac();
                zodiacEntry.Text = "Kalad";
            }
            else
            {
                tyhiZodiac();
                zodiacEntry.Text = "";
            }

            header.Text = "Valisite: " + e.NewDate.ToString("dd/MM/yyyy");
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            string zodiacEntryText = zodiacEntry.Text.ToLower().Trim(charsToTrim);
            if (zodiacEntryText == "jäär" || zodiacEntryText == "jaar")
            {
                jaarZodiac();
            }
            else if (zodiacEntryText == "sõnn" || zodiacEntryText == "sonn" || zodiacEntryText == "synn")
            {
                sonnZodiac();
            }
            else if (zodiacEntryText == "kaksikud")
            {
                kaksikudZodiac();
            }
            else if (zodiacEntryText == "vähk" || zodiacEntryText == "vahk")
            {
                vahkZodiac();
            }
            else if (zodiacEntryText == "lõvi" || zodiacEntryText == "lovi" || zodiacEntryText == "lyvi")
            {
                loviZodiac();
            }
            else if (zodiacEntryText == "neitsi")
            {
                neitsiZodiac();
            }
            else if (zodiacEntryText == "kaalud")
            {
                kaaludZodiac();
            }
            else if (zodiacEntryText == "skorpion")
            {
                skorpionZodiac();
            }
            else if (zodiacEntryText == "ambur")
            {
                amburZodiac();
            }
            else if (zodiacEntryText == "kaljukits")
            {
                kaljukitsZodiac();
            }
            else if (zodiacEntryText == "veevalaja")
            {
                veevalajaZodiac();
            }
            else if (zodiacEntryText == "kalad")
            {
                kaladZodiac();
            }
            else
            {
                tyhiZodiac();
            }

            header.Text = "Otsite: " + zodiacEntry.Text;
        }

        public void jaarZodiac() // Овен // Aries
        {
            zodiacImage.Source = "jaar.png";
            zodiacDescribe.Text = "Jäära märgi sümboolika tuleneb asjaolust, " +
                "et see on sodiaagi esimene märk. Inimest, kelle sünnikaardis asub Päike Jäära märgis, peetakse julgeks, " +
                "sageli hulljulgeks (ei arvesta eelnevaid kogemusi ega teiste inimeste arvamust), tegutsemisele orienteerituks, " +
                "otsekoheseks ja puhtsüdamlikuks. Tema nõrk külg on koostööoskuse ja diplomaatia puudumine. " +
                "Ka oma tegevuse etteplaneerimine ja tagajärgedele mõtlemine ei ole Jäära tugevaim omadus.";
        }

        public void sonnZodiac() // Телец // Taurus
        {
            zodiacImage.Source = "sonn.png";
            zodiacDescribe.Text = "Sõnn on ürgse elujõu, enesesäilitamise sümbol, kes on loodud jätkama Jäära poolt alustatut. " +
                "Sõnnis asuv Päike osutab rahulikule, kannatlikule inimtüübile, kes hoiab kangekaelselt oma harjumustest kinni ega tõtta uuega kaasa jooksma. " +
                "Kogub nii asju kui emotsioone, hoiab truult talle väärtuslikke inimsuhteid. Maa elemendi märgina oskab ta materiaalse tasandiga hästi ümber käia, " +
                "suutes ajada äri, väärtustada oma keha, armastades mugavust ja saades suurepäraselt hakkama taimede kasvatamisega. " +
                "Sageli väga tundliku kompimismeelega ja kunstiandega. Negatiivse poole pealt on Sõnn kangekaelne, laisavõitu ja väga pika vihaga.";
        }

        public void kaksikudZodiac() // Близнецы // Twins
        {
            zodiacImage.Source = "kaksikud.png";
            zodiacDescribe.Text = "Infole orienteeritud Kaksikute märk on sodiaagi esimene mentaalne märk. " +
                "Kaksikute Päikesega inimene vahendab objektiivselt mõtteid ja fakte, eelistamata neist ühtki ja kiindumata oma seisukohtadesse. " +
                "Ta on paindlik ja vajadusel võimeline oma arvamust muutma, sageli ei kujunda ta seda üldse välja, eelistades teiste arvamuste vahendamist. " +
                "Kaksikute Päikesega inimene on uudishimulik, ratsionaalne, objektiivne, suudab olukordi analüüsida emotsioonidevabalt. " +
                "Ta on enamasti hea kõneleja ja kirjamees ning loeb palju, õppides sageli elu jooksul selgeks mitu ametit. " +
                "Verbaalsetele võimetele lisandub tihti käeline osavus. Negatiivse poole pealt võivad Kaksikud olla liiga püsimatud, " +
                "kergesti tüdinevad ega suuda oma ettevõtmisi lõpule viia. Sõnaosavust võib ta kasutada ka omakasupüüdlikel eesmärkidel.";
        }

        public void vahkZodiac() // Рак // Cancer
        {
            zodiacImage.Source = "vahk.png";
            zodiacDescribe.Text = "Vähk on energiline ja ettevõtlik nagu kõik pööripäevast algavad märgid, " +
                "ent nendest kõige ettevaatlikum ja alalhoidlikum. Inimene, kel on Päike Vähi märgis, on sügava empaatiavõimega, " +
                "ühtaegu turvalisust sisendav ja vajav ning väga emotsionaalne. Ta on majandusliku mõtlemisega, pigem kogub kui annab välja (kogub tihti ka vanu esemeid) " +
                "ja näitab teiste suhtes üles hoolitsust nii tunde- kui praktilisel tasandil. Peretraditsioonid ja mälestused on talle olulised, " +
                "emotsionaalne mälu on hästi arenenud. Negatiivse poole pealt on inimene tujukas, subjektiivne, väga kergesti haavatav ning peab solvanguid kaua meeles.";
        }

        public void loviZodiac() // Лев // Lion
        {
            zodiacImage.Source = "lovi.png";
            zodiacDescribe.Text = "Südasuve sümbol, elurõõmust pakatav Lõvi märk tähistab ehedat loomiskirge.Inimene, kel on Päike Lõvis, on energiline, " +
                "rõõmsameelne, vajab palju komplimente ja oskab neid ka teistele teha.Tema ülesanne on soojendada oma kiirguse ja positiivsusega ka neid, " +
                "kellel on vähem energiat ja mängulusti.Kuna Lõvi on harjunud rambivalguses särama, siis pimedas istuv publik ei paista talle hästi kätte " +
                "ja nii on ta pahatahtlike poolt üsna haavatav. Sageli tegeleb Lõvi kas tööalaselt või vabal ajal lastega, draamakunstiga, meelelahutusega. " +
                "Lõvi on kõigist sodiaagimärkidest suurim romantik. Negatiivse poole pealt kipub pidevalt aplausi ootama, on edev, väga uhke, " +
                "jäik oma põhimõtete järgimisel ja kergesti haavuv.";
        }

        public void neitsiZodiac() // Дева // Virgo
        {
            zodiacImage.Source = "neitsi.png";
            zodiacDescribe.Text = "Neitsi on suve viimane märk, ta teeb sümboolselt kokkuvõtteid, korrastab, toob saadud kogemustest välja olulise. " +
                "Neitsi Päikesega inimene on samuti analüütiline, kriitiline, ülimalt ratsionaalne ja süstemaatiline, oskab keskenduda detailidele. " +
                "Ta on töökas ja kannatlik ning ta põhivajadus on olla kasulik. Sarnaselt Kaksikutega on Neitsidel sageli osavad käed. " +
                "Muutliku maamärgina oskab just Neitsi kõige paremini kõrvaldada materiaalse tasandi ebakõlasid: põetada haigeid, parandada katkisi esemeid jne. " +
                "Ta pöörab palju tähelepanu ka enda tervisele ja toitumisele. Negatiivse poole pealt võib Neitsi pedantsus muutuda ülikriitilisuseks, " +
                "mis omakorda kahandab tema eneseusku ja halvendab tervist. Neitsi võib olla üsna ahne nagu kõik maa elemendi märgid.";
        }

        public void kaaludZodiac() // Весы // Libra
        {
            zodiacImage.Source = "kaalud.png";
            zodiacDescribe.Text = "Jäära vastasmärk Kaalud, mis algab sügisesest pöörihetkest, kehastab harmooniatunnetust, diplomaatiat, suhtlusoskust, " +
                "olles sama ettevõtlik nagu kõik pööripäevast algavad märgid. Inimene, kel on Päike Kaaludes, omab enamasti kunstiandeid või vähemalt head stiilitaju, " +
                "armastab suhtlemist ja seltskonda. Ta on objektiivne ja suudab otsuste langetamisel tunded kõrvale jätta nagu teisedki õhu elemendi märgid (Kaksikud ja Veevalaja). " +
                "Kuna ta ei taha olla üksi, võib end vahel siduda sobimatute kaaslastega. Teine negatiivne joon on otsustusvõimetus: " +
                "Kaalud püüab alati langetada parimat võimalikku otsust ja võib seetõttu kaua kaaluda.";
        }

        public void skorpionZodiac() // Скорпион // Scorpion
        {
            zodiacImage.Source = "skorpion.png";
            zodiacDescribe.Text = "Vee elemendi märk Skorpion on orienteeritud hingele ja sellele, mis on pealispinna all, silmaga nähtamatu. " +
                "See, kel Päike Skorpioni märgis, on huvitatud sünni ja surma saladustest, inimese energeetilistest protsessidest ja suurematest rahavoogudest. " +
                "Sageli tegutseb ta ka psühholoogia vallas, salateenistustes või politseis, kus saab kasutada oma läbinägelikkust ja uurida varjatut. " +
                "Ta on tahtejõuline ja otsekohene, kuid tunneb end turvalisemalt, kui saab oma tegevust varjata. Väga vitaalse märgina ei saa Skorpion elada ainult iseendale, " +
                "vaid peaks tegutsema ühiskondlikult. Negatiivsel juhul võib ta olla teiste suhtes liiga kahtlustav ja otsida varjatud motiive, " +
                "samuti võib probleemiks olla liigne omandiinstinkt ja võimuiha";
        }

        public void amburZodiac() // Стрелец // Sagittarius
        {
            zodiacImage.Source = "ambur.png";
            zodiacDescribe.Text = "Amburi märk on seotud ühismõtte, suurte religioonide ja filosoofiatega. Inimene, kel on Päike Amburis, " +
                "väärtustab teadmisi nagu vastasmärk Kaksikud, kuid siia lisandub kollektiivsuse mõõde. Amburi Päikesega inimene loeb, arutleb, " +
                "reisib meelsasti, teda saadab kustumatu tung harida nii iseennast kui ka teisi. Ta võib olla seotud reisibüroode, matkamise, juura, " +
                "kõrghariduse, võõrkeelte, teoloogiaga. Sageli eelistab elada maal, sest seal on rohkem avarust. " +
                "Tema pilk on suunatud kaugele tulevikku ja ta ei pruugi märgata maiseid pisiasju, kuid komistades aitab teda üles tema optimism " +
                "ja soov aina edasi minna. Ambur armastab tõde ja võib seetõttu olla kuni taktitundetuseni otsekohene.";
        }

        public void kaljukitsZodiac() // Козерог // Capricorn
        {
            zodiacImage.Source = "kaljukits.png";
            zodiacDescribe.Text = "Talvisel pööripäeval talve algushetkel läheb Päike astroloogiliselt Kaljukitse märki. " +
                "Kaljukitse Päikesega inimene on energiline ja ettevõtlik nagu kõik pööripäevast algavad märgid, ta on auahne, " +
                "seotud struktuuride loomise ja vundamentide rajamisega. Kaljukits oskab teistest märkidest paremini planeerida oma tegevust mitu käiku ette " +
                "ja suudab ära oodata oma pingutuste tulemused. Ta on töökas ja hindab ainult isikliku tööga saavutatut. " +
                "Kaljukits võib vanuse kasvades tunda end aina paremini, sest selle märgi omadused sobivad paremini kokku küpsema eaga. " +
                "Negatiivse poole pealt võib ta kahelda oma väärtuses ja arvata, et ka armastus tuleb tööga välja teenida";
        }

        public void veevalajaZodiac() // Водолей // Aquarius
        {
            zodiacImage.Source = "veevalaja.png";
            zodiacDescribe.Text = "Õhumärk Veevalaja on seotud ühiste energiaväljadega, nii ühiste tegude kui mõtetega. " +
                "Inimene, kel Päike Veevalajas, on enamasti ratsionaalne ja objektiivne, suudab olukordi hinnata tundeid kõrvale jättes ning kriisihetkel väga kiiresti reageerida. " +
                "Sõbrad ja mõttekaaslased võivad talle olla tähtsamad oma perest ning sageli on ta ühiskondlikult väga aktiivne. " +
                "Ta on ülikiire mõtlemisega, seisab uuenduste eest ega väärtusta enamasti traditsioone. " +
                "Sageli peetakse Veevalajat revolutsionääri võrdkujuks. Negatiivse poole pealt on ta pahatihti empaatiavõimetu. " +
                "Samuti on ta üsna jäiga mõtlemisega, pidades oma ideid ainuõigeiks.";
        }

        public void kaladZodiac() // Рыбы // Pisces
        {
            zodiacImage.Source = "kalad.png";
            zodiacDescribe.Text = "Sodiaagi viimane märk võtab kokku kõigi eelmiste märkide kogemused. Kalade Päikesega inimesel on teiste märkide esindajaist tugevam tervikutaju, " +
                "ta ei tähtsusta detaile üle, halvemal juhul võib neile isegi liiga vähe tähelepanu pöörata. " +
                "Kalasid iseloomustab hea fantaasia, tundlikkus, altruism, sageli on nad looma- ja loodusesõbrad või omavad kunstiandeid. Intuitsioon on neil tugev. " +
                "Neil ei pruugi olla palju energiat, sest nad kipuvad enda peale võtma ka võõraid muresid, sageli globaalseid probleeme. " +
                "Tugeva tervikutaju tõttu on neil raskem tajuda piiri iseenda ja teiste vahel. Negatiivse poole pealt kalduvad Kalad teistest sagedamini mõnuaineid tarvitama " +
                "ning probleemide eest põgenema";
        }

        public void tyhiZodiac() // nothing
        {
            zodiacImage.Source = "tyhi.png";
            zodiacDescribe.Text = "Andmed puuduvad";
        }
    }
}