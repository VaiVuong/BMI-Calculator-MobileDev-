namespace BMICalculator;

public partial class BMIResultsPage : ContentPage
{
    private double _bmi;
    private string _status;
    private string _gender;

    public BMIResultsPage(double weight, double height, string gender)
    {
        InitializeComponent();
        _gender = gender;

        _bmi = (weight * 703) / (height * height);
        BMIResultLabel.Text = $"BMI: {_bmi:F2}";

        if (gender == "Male")
        {
            if (_bmi < 18.5) _status = "Underweight";
            else if (_bmi < 25) _status = "Normal Weight";
            else if (_bmi < 30) _status = "Overweight";
            else _status = "Obese";
        }
        else //female bmi
        {
            if (_bmi < 18) _status = "Underweight";
            else if (_bmi < 24) _status = "Normal Weight";
            else if (_bmi < 29) _status = "Overweight";
            else _status = "Obese";
        }

        BMIStatusLabel.Text = _status;
    }

    private async void OnToHealthPageClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HealthPage(_bmi, _gender, _status));
    }

    private async void OnBackToInputClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}
