namespace BMICalculator;

public partial class HealthPage : ContentPage
{
    public HealthPage(double bmi, string gender, string status)
    {
        InitializeComponent();
        RecommendationLabel.Text = GetRecommendations(gender, status);
    }

    private string GetRecommendations(string gender, string status)
    {
        return status switch
        {
            "Underweight" => "Increase calorie intake with nutrient-rich foods (e.g., nuts, lean protein, whole grains). Incorporate strength training to build muscle mass. Consult a nutritionist if needed.",
            "Normal Weight" => "Maintain a balanced diet with proteins, healthy fats, and fiber. Stay physically active with at least 150 minutes of exercise per week. Keep regular check-ups to monitor overall health.",
            "Overweight" => "Reduce processed foods and focus on portion control. Engage in regular aerobic exercises (e.g., jogging, swimming) and strength training. Drink plenty of water and track your progress.",
            "Obese" => "Consult a doctor for personalized guidance. Start with low-impact exercises (e.g., walking, cycling). Follow a structured weight-loss meal plan and consider behavioral therapy for lifestyle changes. Avoid sugary drinks and maintain a consistent sleep schedule.",
            _ => "No recommendation available."
        };
    }

    private async void OnBackToResultsClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnBackToInputClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}
