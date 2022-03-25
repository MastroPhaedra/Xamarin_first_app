using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv20
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Rgb_Page : ContentPage
    {
        Random rnd = new Random();
        public Rgb_Page()
        {
            InitializeComponent();
        }

        int _sliderR, _sliderG, _sliderB;

        private void SliderR_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            _sliderR = Convert.ToInt32(SliderR.Value);
            GenerateRgbColors(_sliderR, _sliderG, _sliderB);

            RValue.Text = _sliderR.ToString();
        }


        private void SliderG_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            _sliderG = Convert.ToInt32(SliderG.Value);
            GenerateRgbColors(_sliderR, _sliderG, _sliderB);

            GValue.Text = _sliderG.ToString();
        }

        private void SliderB_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            _sliderB = Convert.ToInt32(SliderB.Value);
            GenerateRgbColors(_sliderR, _sliderG, _sliderB);

            BValue.Text = _sliderB.ToString();
        }

        private void GenerateRgbColors(int sliderR, int sliderG, int sliderB)
        {
            TxtColorPreviewer.BackgroundColor = Color.FromRgb(sliderR, sliderG, sliderB);
        }

        private void RandButton_Clicked(object sender, EventArgs e)
        {
            // задаём случайные параметры
            int value1 = rnd.Next(0, 255); //R
            int value2 = rnd.Next(0, 255); //G
            int value3 = rnd.Next(0, 255); //B

            // устанавливаем их для слайдеров
            SliderR.Value = value1;
            SliderG.Value = value2;
            SliderB.Value = value3;

            // отображаем числа
            RValue.Text = value1.ToString();
            GValue.Text = value2.ToString();
            BValue.Text = value3.ToString();

            // меняем цвет
            GenerateRgbColors(value1, value2, value3);
        }
    }
}
