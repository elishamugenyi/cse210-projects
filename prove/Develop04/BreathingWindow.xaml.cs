using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Develop04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class BreathingWindow : Window
    {
        public BreathingWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            int inhaleDuration, exhaleDuration;

            if (int.TryParse(inhaleDuration.Text, out inhaleDuration) &&
                int.TryParse(exhaleDuration.Text, out exhaleDuration) &&
                inhaleDuration >= 1 && inhaleDuration <= 3 &&
                exhaleDuration >= 1 && exhaleDuration <= 3)
            {
                // Create the Breathing instance
                Breathing breathing = new Breathing(inhaleDuration, exhaleDuration);
                Close(); // Close the BreathingWindow
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter valid numbers between 1 and 3 seconds.", "Error");
            }
        }
    }
}
