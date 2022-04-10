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
    public partial class Tic_Tac_Toe_Page : ContentPage
    {
        public Tic_Tac_Toe_Page()
        {
            InitializeComponent();

            // так может добавлять
            AddigToDicData();
        }

        public Dictionary<int, Image> images = new Dictionary<int, Image>();

        // a так не может добавлять
        //{
        //    [0] = img1,
        //    [1] = img2,
        //    [2] = img3,
        //};

        public bool botOnOff = false; //флаг активации и работы бота (пока будет активен, бот будет играть)
        public string bot_pic = "";

        public string current_pic = "x.png";

        private void RefreshButton_Clicked(object sender, EventArgs e)
        {
            all_clear();
        }

        private async void VSbotButton_Clicked(object sender, EventArgs e)
        {
            var buttonText = (Button)sender;

            if (botOnOff)
            {
                botOnOff = false;
                buttonText.Text = "VS bot (Off)";
            }
            else
            {
                botOnOff = true;
                buttonText.Text = "VS bot (On)";
            }
            all_clear();
        }

        private async void RulesButton_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("RULES FOR TIC-TAC-TOE", "1. The game is played on a grid thats 3 squares by 3 squares \n2. You are X, your friend(or the computer in this case) is O \n3. The first player to get 3 of her marks in a row(up, down, across, or diagonally) is the winner \n4. When all 9 squares are full, the game is over", "Ok");
        }

        private void Change_X_and_O_Clicked(object sender, EventArgs e)
        {
            var imageSource = (Image)sender; // name in xaml
            var selectedImage = imageSource.Source as FileImageSource; // name.Source ("File: x.png") without "File: "
            all_clear();
            if (selectedImage.File == "x.png")
            {
                current_pic = "o.png";
                imageSource.Source = current_pic;
                bot_pic = "x.png";
            }
            else
            {
                current_pic = "x.png";
                imageSource.Source = current_pic;
                bot_pic = "o.png";
            }
        }

        private async void X_and_O_Button_Clicked(object sender, EventArgs e)
        {
            var imageSource = (Image)sender; // name in xaml
            var selectedImage = imageSource.Source as FileImageSource; // name.Source ("File: x.png") without "File: "

            if (current_pic == "x.png" && selectedImage.File == "tyhi.png") // || selectedImage.File == "tyhi.png"
            {
                imageSource.Source = "x.png";
                if (botOnOff)
                {
                    bot_pic = "o.png";
                    bot_rand(imageSource);
                }
                else
                {
                    current_pic = "o.png";
                    players_turn.Source = current_pic;
                }
                winner_check("x.png");
            }
            else if(current_pic == "o.png" && selectedImage.File == "tyhi.png")
            {
                imageSource.Source = "o.png";
                if (botOnOff)
                {
                    bot_pic = "x.png";
                    bot_rand(imageSource);
                }
                else
                {
                    current_pic = "x.png";
                    players_turn.Source = current_pic;
                }
                winner_check("o.png");
            }
            else
            {
                await DisplayAlert("Miss click", "Ooops! \nSa ei saa seda muuta!", "Ok");
            }
        }

        public async void winner_check(string win_win)
        {
            if (img1.Source.ToString().Substring(6) == win_win && img2.Source.ToString().Substring(6) == win_win && img3.Source.ToString().Substring(6) == win_win)
            {
                winner_alert();
            }
            else if (img1.Source.ToString().Substring(6) == win_win && img4.Source.ToString().Substring(6) == win_win && img7.Source.ToString().Substring(6) == win_win)
            {
                winner_alert();
            }
            else if (img2.Source.ToString().Substring(6) == win_win && img5.Source.ToString().Substring(6) == win_win && img8.Source.ToString().Substring(6) == win_win)
            {
                winner_alert();
            }
            else if (img3.Source.ToString().Substring(6) == win_win && img6.Source.ToString().Substring(6) == win_win && img9.Source.ToString().Substring(6) == win_win)
            {
                winner_alert();
            }
            else if (img4.Source.ToString().Substring(6) == win_win && img5.Source.ToString().Substring(6) == win_win && img6.Source.ToString().Substring(6) == win_win)
            {
                winner_alert();
            }
            else if (img7.Source.ToString().Substring(6) == win_win && img8.Source.ToString().Substring(6) == win_win && img9.Source.ToString().Substring(6) == win_win)
            {
                winner_alert();
            }
            else if (img1.Source.ToString().Substring(6) == win_win && img5.Source.ToString().Substring(6) == win_win && img9.Source.ToString().Substring(6) == win_win)
            {
                winner_alert();
            }
            else if (img3.Source.ToString().Substring(6) == win_win && img5.Source.ToString().Substring(6) == win_win && img7.Source.ToString().Substring(6) == win_win)
            {
                winner_alert();
            }
            else if (img1.Source.ToString().Substring(6) != "tyhi.png" && img2.Source.ToString().Substring(6) != "tyhi.png" && img3.Source.ToString().Substring(6) != "tyhi.png" && img4.Source.ToString().Substring(6) != "tyhi.png" && img5.Source.ToString().Substring(6) != "tyhi.png" && img6.Source.ToString().Substring(6) != "tyhi.png" && img7.Source.ToString().Substring(6) != "tyhi.png" && img8.Source.ToString().Substring(6) != "tyhi.png" && img9.Source.ToString().Substring(6) != "tyhi.png")
            {
                await DisplayAlert("Winner", "Friendship is won", "Ok");
                all_clear();
            }
        }

        public async void winner_alert()
        {
            if (botOnOff)
            {
                if (bot_pic != "x.png")
                {
                    await DisplayAlert("Winner", "Winner is X", "Ok");
                }
                else
                {
                    await DisplayAlert("Winner", "Winner is O", "Ok");
                }
            }
            else
            {
                if (current_pic != "x.png")
                {
                    await DisplayAlert("Winner", "Winner is X", "Ok");
                }
                else
                {
                    await DisplayAlert("Winner", "Winner is O", "Ok");
                }
            }
            all_clear();
        }

        public void all_clear()
        {
            images.Clear();
            AddigToDicData();
            foreach (var keyValuePair in images)
            {
                Image image = keyValuePair.Value;
                image.Source = "tyhi.png";
            }
        }

        public async void bot_rand(Image DelFromDic)
        {
            Random rnd = new Random();
            int k = images.Where(x => x.Value == DelFromDic).FirstOrDefault().Key;
            images.Remove(k);
            int DicCount = images.Count();

            //foreach (var picture in images)
            //{
            //    await DisplayAlert("Otvet", $"key: {images.Keys}  value: {images.Values}", "Ok");
            //}
            //int rImage = rnd.Next(0, DicCount); // от 0 включительно до 9 (не включая её)
            //var namePic = images[rImage];
            //while (rImage < 0 && rImage > 8 && namePic.ToString() != "tyhi.png") // || rImage < 0 && rImage > 8
            //{
            //    rImage++;
            //    namePic = images[rImage];
            //}
        }

        public void AddigToDicData()
        {
            images.Add(0, img1); //1 - ключ, 2 - значение
            images.Add(1, img2); //1 - ключ, 2 - значение
            images.Add(2, img3); //1 - ключ, 2 - значение
            images.Add(3, img4); //1 - ключ, 2 - значение
            images.Add(4, img5); //1 - ключ, 2 - значение
            images.Add(5, img6); //1 - ключ, 2 - значение
            images.Add(6, img7); //1 - ключ, 2 - значение
            images.Add(7, img8); //1 - ключ, 2 - значение
            images.Add(8, img9); //1 - ключ, 2 - значение
        }
    }
}