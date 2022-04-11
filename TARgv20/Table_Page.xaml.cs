using Plugin.Messaging;
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
    public partial class Table_Page : ContentPage
    {
        public TableView tabelview;
        SwitchCell sc;
        ImageCell ic;
        TableSection fotosection;
        ViewCell vc;
        Button sms_btn, call_btn, email_btn;
        StackLayout stack;
        string phoneNumber, emailSend;
        EntryCell TelefoneCell = new EntryCell
        {
            Label = "Telefon",
            Placeholder = "Sisesta tel.number",
            Keyboard = Keyboard.Telephone,
            Text = ""
        };
        EntryCell EmailCell = new EntryCell
        {
            Label = "Email",
            Placeholder = "Sisesta email",
            Keyboard = Keyboard.Email,
            Text = ""
        };
        public Table_Page()
        {
            call_btn = new Button { Text = "Helista"};
            sms_btn = new Button { Text = "Saada sms" };
            email_btn = new Button { Text = "Saada email" };

            stack = new StackLayout 
            {
                Children = {call_btn, sms_btn, email_btn},
                Orientation = StackOrientation.Horizontal
            };

            call_btn.Clicked += PhoneCallClick;
            sms_btn.Clicked += MessengSendClick;
            email_btn.Clicked += EmailSendClick;

            vc = new ViewCell();
            vc.View = stack;

            sc = new SwitchCell { Text = "Näita veel" };
            sc.OnChanged += Sc_OnChanged;
            ic = new ImageCell
            {
                ImageSource = ImageSource.FromFile("ben.png"),
                Text = "Foto nimetus",
                Detail = "Foto kirjeldus"
            };
            fotosection = new TableSection();

            tabelview = new TableView
            {
                Intent = TableIntent.Form, //Могут быть ещё Menu, Data, Settings
                Root = new TableRoot("Andmete sisestamine")
                {
                    new TableSection("Põhiandmed: ")
                    {
                        new EntryCell
                        {
                            Label = "Nimi",
                            Placeholder = "Sisesta oma sõbra nimi",
                            Keyboard = Keyboard.Default
                        }
                    },
                    new TableSection("Kontaktandmed: ")
                    {
                        TelefoneCell,
                        EmailCell,
                        sc
                    },

                    fotosection,

                    new TableSection()
                    {
                        vc
                    }
                }
            };
            Content = tabelview;
        }

        private void PhoneCallClick(object sender, EventArgs e)
        {
            tableData();
            var phoneDialer = CrossMessaging.Current.PhoneDialer;
            if (phoneDialer.CanMakePhoneCall)
            {
                phoneDialer.MakePhoneCall(phoneNumber);
            };
        }

        private void MessengSendClick(object sender, EventArgs e)
        {
            //
            tableData();
            var smsMessenger = CrossMessaging.Current.SmsMessenger;
            if (smsMessenger.CanSendSms)
            {
                smsMessenger.SendSms(phoneNumber, "Tere! \n");
            };
        }

        private void EmailSendClick(object sender, EventArgs e)
        {
            //
            tableData();
            var emailMessenger = CrossMessaging.Current.EmailMessenger;
            if (emailMessenger.CanSendEmail)
            {
                emailMessenger.SendEmail(emailSend, "Teema", "Tere! \n");
            };
        }

        private void Sc_OnChanged(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                fotosection.Title = "Foto: ";
                fotosection.Add(ic);
                sc.Text = "Peida";
            }
            else
            {
                fotosection.Title = "";
                fotosection.Remove(ic);
                sc.Text = "Näita veel";
            }
        }

       public void tableData()
        {
            //if (TelefoneCell.Text.Int32() < 7)
            //{

            //}
            phoneNumber = "+372" + TelefoneCell.Text.ToString();
            emailSend = EmailCell.Text.ToString();
        }

    }
}