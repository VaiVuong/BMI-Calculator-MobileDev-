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


        private async void OnCalculateClicked(object sender, EventArgs e)//button click logic
        {
            double weight = WeightSlider.Value;
            double height = HeightSlider.Value;

            if (height == 0)
            {
                await DisplayAlert("Input Error", "Please enter a valid height.", "OK");
                return;
            }

            double bmi = (weight * 703) / (height * height);
            BMIResultLabel.Text = $"{bmi:F2}";

            string status = string.Empty;
            string recommendations = string.Empty;

            if (_selectedGender == "Male") //male specific bmi logic
            {
                if (bmi < 18.5)
                {
                    status = "Underweight";
                    recommendations = "Increase calorie intake with nutrient-rich foods (e.g., nuts, lean protein, whole grains). Incorporate strength training to build muscle mass. Consult a nutritionist if needed.";
                    BMIStatusLabel.TextColor = Colors.Orange;
                }
                else if (bmi < 25)
                {
                    status = "Normal Weight";
                    recommendations = "Maintain a balanced diet with proteins, healthy fats, and fiber. Stay physically active with at least 150 minutes of exercise per week. Keep regular check-ups to monitor overall health.";
                    BMIStatusLabel.TextColor = Colors.Green;
                }
                else if (bmi < 30)
                {
                    status = "Overweight";
                    recommendations = "Reduce processed foods and focus on portion control. Engage in regular aerobic exercises (e.g., jogging, swimming) and strength training. Drink plenty of water and track your progress.";
                    BMIStatusLabel.TextColor = Colors.OrangeRed;
                }
                else
                {
                    status = "Obese";
                    recommendations = "Consult a doctor for personalized guidance. Start with low-impact exercises (e.g., walking, cycling). Follow a structured weight-loss meal plan and consider behavioral therapy for lifestyle changes. Avoid sugary drinks and maintain a consistent sleep schedule.";
                    BMIStatusLabel.TextColor = Colors.Red;
                }
            }
            else // Female specific bmi logic
            {
                if (bmi < 18)
                {
                    status = "Underweight";
                    recommendations = "Increase calorie intake with nutrient-rich foods (e.g., nuts, lean protein, whole grains). Incorporate strength training to build muscle mass. Consult a nutritionist if needed.";
                    BMIStatusLabel.TextColor = Colors.Orange;
                }
                else if (bmi < 24)
                {
                    status = "Normal Weight";
                    recommendations = "Maintain a balanced diet with proteins, healthy fats, and fiber. Stay physically active with at least 150 minutes of exercise per week. Keep regular check-ups to monitor overall health.";
                    BMIStatusLabel.TextColor = Colors.Green;
                }
                else if (bmi < 29)
                {
                    status = "Overweight";
                    recommendations = "Reduce processed foods and focus on portion control. Engage in regular aerobic exercises (e.g., jogging, swimming) and strength training. Drink plenty of water and track your progress.";
                    BMIStatusLabel.TextColor = Colors.OrangeRed;
                }
                else
                {
                    status = "Obese";
                    recommendations = "Consult a doctor for personalized guidance. Start with low-impact exercises (e.g., walking, cycling). Follow a structured weight-loss meal plan and consider behavioral therapy for lifestyle changes. Avoid sugary drinks and maintain a consistent sleep schedule.";
                    BMIStatusLabel.TextColor = Colors.Red;
                }
            }

            BMIStatusLabel.Text = status;

            // 🔔 Display the popup message
            await DisplayAlert("Health Recommendation", recommendations, "OK");
        }
    }
}