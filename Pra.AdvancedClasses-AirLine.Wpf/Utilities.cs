using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Pra.AdvancedClasses_AirLine.Wpf
{
    partial class MainWindow
    {
        void MarkControl(Control controlToMark, bool isInputCorrect = true)
        {
            if (!isInputCorrect)
            {
                controlToMark.Background = Brushes.LightPink;
                controlToMark.BorderThickness = new Thickness(3);
                controlToMark.BorderBrush = Brushes.Red;
                controlToMark.Focus();
                if (controlToMark is TextBox)
                    ((TextBox)controlToMark).SelectAll();
                else if (controlToMark is PasswordBox)
                    ((PasswordBox)controlToMark).Clear();
            }
            else
            {
                controlToMark.Background = Brushes.White;
                controlToMark.BorderThickness = new Thickness(1);
                controlToMark.BorderBrush = Brushes.Gray;
            }
        }

        void ShowFeedback(string feedback, TextBlock textBlock, bool isCorrect = false)
        {
            textBlock.Visibility = Visibility.Visible;
            textBlock.Text = feedback;
            textBlock.Background = (isCorrect) ? Brushes.Green : Brushes.Red;
        }

        bool IsValidInteger(string number)
        {
            bool isValid = true;
            try
            {
                int.Parse(number);
            }
            catch (Exception)
            {
                isValid = false;
            }
            return isValid;
        }

        void ClearPanel(Panel toClear)
        {

            foreach (object control in toClear.Children)
            {
                Debug.WriteLine(control.ToString());
                // Als het control van de class TextBox is, 
                //cast het naar TexBox en sla het op in de variabele castedTextBox
                if (control is TextBox castedTextBox)
                    castedTextBox.Text = string.Empty;
                else if (control is DatePicker castedDatePicker)
                    castedDatePicker.SelectedDate = DateTime.Now;
                else if (control is PasswordBox castedPasswordBox)
                    castedPasswordBox.Password = string.Empty;
                else if (control is Selector castedSelector)
                    castedSelector.SelectedIndex = -1;
                else if (control is Slider castedSlider)
                    castedSlider.Value = castedSlider.Minimum;
                else if (control is CheckBox castedCheckBox)
                    castedCheckBox.IsChecked = false;
                else if (control is Label castedLabel)
                        if (castedLabel.Name.Length > 0) castedLabel.Content = "";
                else if (control is TextBlock castedTextBlock)
                        if (castedTextBlock.Name.Length > 0) castedTextBlock.Text = "";
            }
        }
    }
}
