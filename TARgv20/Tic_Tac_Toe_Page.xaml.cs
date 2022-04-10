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

            //Creating TapGestureRecognizers    
            //var tapImage = new TapGestureRecognizer();
            //Binding events    
            //tapImage.Tapped += tapImage_Tapped;
            //Associating tap events to the image buttons
            //int i = 0;
            //foreach (int i, i<10)
            //{

            //};
            //img1.GestureRecognizers.Add(tapImage);

            images.Add("0", img1); //1 - Id, 2
            images.Add("1", img2); //1 - Id, 2
            images.Add("2", img3); //1 - Id, 2
            images.Add("3", img4); //1 - Id, 2
            images.Add("4", img5); //1 - Id, 2
            images.Add("5", img6); //1 - Id, 2
            images.Add("6", img7); //1 - Id, 2
            images.Add("7", img8); //1 - Id, 2
            images.Add("8", img9); //1 - Id, 2
        }

        public Dictionary<string, Image> images = new Dictionary<string, Image>();

        public string current_pic = "x.png";
        string[,] ArrayAmountOfTyhi = new string[9,2] { { "img1", "tyhi.png" }, { "img2", "tyhi.png" }, { "img3", "tyhi.png" }, { "img4", "tyhi.png" }, { "img5", "tyhi.png" }, { "img6", "tyhi.png" }, { "img7", "tyhi.png" }, { "img8", "tyhi.png" }, { "img9", "tyhi.png" } };

        //public string[] ImageArray = new string[] {"img1", "img2", "img3", "img4", "img5", "img6", "img7", "img8", "img9" };

        private void RefreshButton_Clicked(object sender, EventArgs e)
        {
            all_clear();
        }

        private async void VSbotButton_Clicked(object sender, EventArgs e)
        {
            all_clear();
            int amTyhiLength = (ArrayAmountOfTyhi.Length)/2;
            await DisplayAlert("Miss click", "Ooops!" + amTyhiLength + "Ooops!" + ArrayAmountOfTyhi[8,1], "Ok");
            int freeTyhi = 0;
            for (int i = 0; i < amTyhiLength; i++)
            {
                if (ArrayAmountOfTyhi[i, 1] == "tyhi.png")
                {
                    freeTyhi++;
                    await DisplayAlert("Miss click", "Ooops!" + freeTyhi, "Ok");
                }
                else
                {
                    if (current_pic == "x.png")
                    {
                        winner_check("o.png");
                    }
                    else
                    {
                        winner_check("x.png");
                    }
                }
            }

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
            }
            else
            {
                current_pic = "x.png";
                imageSource.Source = current_pic;
            }
        }

        private async void X_and_O_Button_Clicked(object sender, EventArgs e)
        {
            var imageSource = (Image)sender; // name in xaml
            var selectedImage = imageSource.Source as FileImageSource; // name.Source ("File: x.png") without "File: "
            //var PISource = players_turn.Source.ToString().Substring(6); // этот метод сокращает кол-во строк, но мне не особо нравится
            //var selectedImageName = imageSource.XAMLNameValue;

            if (current_pic == "x.png" && selectedImage.File == "tyhi.png") // || selectedImage.File == "tyhi.png"
            {
                imageSource.Source = "x.png";
                current_pic = "o.png";
                players_turn.Source = current_pic;
                winner_check("x.png");
            }
            else if(current_pic == "o.png" && selectedImage.File == "tyhi.png")
            {
                imageSource.Source = "o.png";
                current_pic = "x.png";
                players_turn.Source = current_pic;
                winner_check("o.png");
            }
            else
            {
                //await DisplayAlert("Miss click", "current_pic - " + current_pic + "\n imageSource.Source - " + imageSource.Source + "\n players_turn.Source - " + players_turn.Source, "Ok");
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
            if (current_pic != "x.png")
            {
                await DisplayAlert("Winner", "Winner is X", "Ok");
                all_clear();
            }
            else
            {
                await DisplayAlert("Winner", "Winner is O", "Ok");
                all_clear();
            }
        }

        public void all_clear()
        {
            foreach (var keyValuePair in images)
            {
                var image = keyValuePair.Value;
                image.Source = "tyhi.png";
            }
        }
    }
}