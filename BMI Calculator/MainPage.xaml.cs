using Microsoft.Maui.Controls;
using System;

namespace BMICalculator
{
    public partial class MainPage : ContentPage
    {
        private string _selectedGender;

        public MainPage()
        {
            InitializeComponent();
            // defaults
            _selectedGender = "Male";
            MaleFrame.BorderColor = Colors.Blue;
            MaleFrame.Opacity = 0.8;
            FemaleFrame.BorderColor = Colors.Transparent;
            FemaleFrame.Opacity = 1.0;
        }

        private void OnGenderSelected(object sender, TappedEventArgs e) //gender selection method
        {
            if (sender is Image image && image.GestureRecognizers.FirstOrDefault() is TapGestureRecognizer tap &&
                tap.CommandParameter is string gender)
            {
                _selectedGender = gender;

                MaleFrame.BorderColor = Colors.Transparent;
                FemaleFrame.BorderColor = Colors.Transparent;
                MaleFrame.Opacity = 1.0;
                FemaleFrame.Opacity = 1.0;

                if (_selectedGender == "Male")
                {
                    MaleFrame.BorderColor = Colors.Blue;
                    MaleFrame.Opacity = 0.8;
                }
                else
                {
                    FemaleFrame.BorderColor = Colors.Pink;
                    FemaleFrame.Opacity = 0.8;
                }
            }
        }


        private async void OnCalculateClicked(object sender, EventArgs e)
        {
            double weight = WeightSlider.Value;
            double height = HeightSlider.Value;

            if (height == 0)
            {
                await DisplayAlert("Input Error", "Please enter a valid height.", "OK");
                return;
            }

            // To BMIResultsPage with parameters
            await Navigation.PushAsync(new BMIResultsPage(weight, height, _selectedGender));
        }
    }
}