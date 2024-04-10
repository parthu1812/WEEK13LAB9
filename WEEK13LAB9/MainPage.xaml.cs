using Microsoft.Maui.Controls;
using System;

namespace WEEK13LAB9
{
    public partial class MainPage : ContentPage
    {
        double currentNumber = 0;
        string currentOperation = "";
        bool isOperationClicked = false;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnNumberClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (isOperationClicked || DisplayLabel.Text == "0")
            {
                DisplayLabel.Text = button.Text;
                isOperationClicked = false;
            }
            else
            {
                DisplayLabel.Text += button.Text;
            }
        }

        private void OnOperatorClicked(object sender, EventArgs e)
        {
            currentNumber = double.Parse(DisplayLabel.Text);
            currentOperation = (sender as Button).Text;
            isOperationClicked = true;
        }

        private void OnEqualsClicked(object sender, EventArgs e)
        {
            double newNumber = double.Parse(DisplayLabel.Text);
            double result = 0;
            switch (currentOperation)
            {
                case "+":
                    result = currentNumber + newNumber;
                    break;
                case "-":
                    result = currentNumber - newNumber;
                    break;
                case "*":
                    result = currentNumber * newNumber;
                    break;
                case "/":
                    if (newNumber != 0)
                    {
                        result = currentNumber / newNumber;
                    }
                    else
                    {
                        DisplayLabel.Text = "Error";
                        return;
                    }
                    break;
            }
            DisplayLabel.Text = result.ToString();
            isOperationClicked = false;
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            currentNumber = 0;
            currentOperation = "";
            DisplayLabel.Text = "0";
            isOperationClicked = false;
        }
    }
}
